using ELABO.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestImage.Protocol.Common;

namespace ELABO.Communication
{
    public class L2Process : iL2Communication
    {
        public  const int MAX_QUEUE_POS              = 2000;
        private const int TIME_OUT_WAIT_TX_EVENT     = 2002; // 2s
        private const int TIME_WAIT_DEV_RESPOND      = 5000; //5s

        private ThreadsManager ThMan = ThreadsManager.GetInstance();

        private iL1Communication L1Handler;

        private crc8 crc8Handler = new crc8();

        /* L2 state */
        private L2State_E l2State = L2State_E.NORMAL_MODE;

        /* Enable anti conflict transfer data mode. This option mean that 
         * i will prevent TX and RX is taken at the same time by Delay 20ms before TX*/
        public const int DECONFLICT_TIME = 20;

        public L2State_E L2State
        {
            get { return l2State; }
            set { l2State = value; }
        }
        /* Is Reset PORT mode enable ? */
        private bool isResetEn = false;
        public bool IsResetEn
        {
            get { return isResetEn; }
            set { isResetEn = value; }
        }

        /* Call back function */
        private L2CallbackDataReceived callbackFunc;

        public L2CallbackDataReceived CallbackFunc
        {
            get { return callbackFunc; }
            set { callbackFunc = value; }
        }

        /* Check ACK package function */
        private IsACKPkg checkACKPkg;

        public IsACKPkg CheckACKPkg
        {
            get { return checkACKPkg; }
            set { checkACKPkg = value; }
        }

        public int PendingPkgInQueue
        {
            get { return TxQueue.Count; }
        }

        private ManualResetEvent ACKRespondEvent = new ManualResetEvent(false);
        private ManualResetEvent AddPkg2TxQueue = new ManualResetEvent(false);
        private Queue<L2Pkg> TxQueue = new Queue<L2Pkg>();

        private CommConfig cfg = new CommConfig();

        private Thread L2TxThread;

        #region L2DATAHandler

        ByteBuffer L1Fifo = new ByteBuffer();

        public byte u8Seq;
        public byte u8LastRecvSeq;
        public byte bIsNeedACK;
        public byte bIsEnableEncrypt;
        public byte bIsHeaderDetected;
        public eACKType_t eACK;
        //Semaphore_Handle  AckHandler;
        public byte u8NumResend;
        public sL1Object_t sObjLastCMDPkg = new sL1Object_t();
        public byte[] u8AesKey = new byte[L1Object.MAX_KEY_SIZE];
        public UInt16 u16PayloadLengthWaitting;


        #endregion


        public L2Process(CommConfig conf)
        {
            u8LastRecvSeq = 255;
            cfg = conf;
            if (conf.commType == CommType.RS232)
            {
                L1Handler = new RS232Connection(conf);
            }
            else if (conf.commType == CommType.TCPIP)
            {
                L1Handler = new TCPIPConnection(conf);
            }

            L1Handler.L1DataReceivedEvent = new L1DataReceived(L2OnRcvData);
        }
        
        public void L2Start()
        {
            try
            {
	            L2TxThread      = new Thread(new ThreadStart(TxThreadProcess));
	            L2TxThread.Name = "L2 - TX Thread" + cfg.GetName();
	
	            L1Handler.Open();
	            
	            AddPkg2TxQueue.Reset();
	            TxQueue.Clear();
	            ThMan.AddThread(L2TxThread.Name, L2TxThread);
	            L2TxThread.Start();
            }
            catch (System.Exception ex)
            {
            	if(L1Handler.IsConnected())
                {
                    L1Handler.Close();
                }
                Thread t = ThMan.RemoveThread(L2TxThread.Name);

                if(t != null)
                {
                    t.Abort();
                    t = null;
                }

                throw ex;
            }

        }

        public void L2Stop()
        {
            try
            {
                L2TxThread.Abort();
                ThMan.RemoveThread(L2TxThread.Name);
                L2TxThread = null;

                L1Handler.Close();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void TxThreadProcess()
        {
            while(true)
            {
                if(TxQueue.Count > 0 || AddPkg2TxQueue.WaitOne(TIME_OUT_WAIT_TX_EVENT))
                {
                    if(DECONFLICT_TIME > 0)
                    {
                        Thread.Sleep(DECONFLICT_TIME);
                    }

                    int count = 0;
                    while (l2State != L2State_E.NORMAL_MODE)
                    {
                        Thread.Sleep(10);
                        if (count++ > 100) // 100*10 = 1000 ms, NOTE : check again that no data package is take time longer 1s
                            break;
                    }

                    lock (TxQueue)
                    {
                        L2Pkg pkg = TxQueue.Dequeue();

                        //May be clean received buffer
                        L1Handler.CleanRxBuffer();

                        //Send data
                        L2SendPkg(pkg);
                        AddPkg2TxQueue.Reset();
                    }
                }
            }
        }

        public bool L2TXAddPkg(byte[] sendData, bool isNeedACK, uint resend, byte cmd)
        {
            if(TxQueue.Count > MAX_QUEUE_POS)
            {
                Trace.WriteLine("TxQueue is full.");
                return false;
            }
            else
            {
                lock (TxQueue)
                {
                    //Add data to queue and raise event
                    L2Pkg pkg = new L2Pkg(sendData, isNeedACK, resend, cmd);

                    TxQueue.Enqueue(pkg);

                    AddPkg2TxQueue.Set();

                    return true;
                }
            }
        }

        public bool L2TXAddPkg(L2Pkg pkg)
        {
            if (TxQueue.Count > MAX_QUEUE_POS)
            {
                return false;
            }
            else
            {
                lock (TxQueue)
                {
                    //Add data to queue and raise event
                    TxQueue.Enqueue(pkg);

                    AddPkg2TxQueue.Set();

                    return true;
                }
            }
        }

        private void L2SendPkg(L2Pkg pkg)
        {
            if (pkg.isNeededACK)
            {
                int sendTimes = (int)pkg.resend + 1;
                bool respond = false;

                //Send data and wait respond
                do
                {
                    l2State = L2State_E.TX_MODE;

                    sL1Object_t obj = new sL1Object_t();
                    L1Object.L1Object_BuildFromData(this, pkg.data, pkg.MinorCmd, u8Seq,ref obj);

                    byte[] temp = new byte[pkg.data.Length + 1 + L1Object.HEADER_LENGTH];

                    L1Object.L1Object_L1ObjectToArray(obj, ref temp);

                    L1Handler.Send(temp);

                    l2State = L2State_E.WAIT_RESP_MODE;
                    //Wait respond event
                    if (ACKRespondEvent.WaitOne(TIME_WAIT_DEV_RESPOND))
                    {
                        respond = true;
                    }
                    else
                    {
                        Trace.WriteLine("L2:Resend " + sendTimes.ToString());
                        if (IsResetEn)
                        {
                            try
                            {
                                L1Handler.Close();
                                L1Handler.Open();
                            }
                            catch (Exception ex)
                            {
                                l2State = L2State_E.ERROR;
                                Trace.WriteLine(ex.Message);
                            }
                        }
                    }

                    ACKRespondEvent.Reset();

                    sendTimes--;
                } while (respond == false && sendTimes > 0);

                if (respond == false && sendTimes <= 0)
                {
                    l2State = L2State_E.ERROR;
                }
                else
                {
                    l2State = L2State_E.NORMAL_MODE;
                }
            }
            else
            {
                l2State = L2State_E.TX_MODE;

                sL1Object_t obj = new sL1Object_t();
                L1Object.L1Object_BuildFromData(this, pkg.data, pkg.MinorCmd, u8Seq, ref obj);

                byte[] temp = new byte[pkg.data.Length + 1 + L1Object.HEADER_LENGTH];

                L1Object.L1Object_L1ObjectToArray(obj, ref temp);

                L1Handler.Send(temp);

                l2State = L2State_E.NORMAL_MODE;
            }
        }

        private void L2OnRcvData(object obj)
        {
            ByteBuffer queue = obj as ByteBuffer;
            if (l2State != L2State_E.WAIT_RESP_MODE)
            {
                l2State = L2State_E.RX_MODE;
            }
            byte u8Temp = 0;
            ByteBuffer fifo = obj as ByteBuffer;

            /*Split data to package*/
            u8Temp = fifo.GetFirstByte();

            if (u8Temp != L1Object.PREAMBLE)
            {
                do
                {
                    /*Remove the first slot in fifo*/
                    fifo.RetriveByte();
                    if (fifo.GetLength() == 0)
                    {
                        return;
                    }
                    u8Temp = fifo.GetFirstByte();
                } while ((fifo.GetLength() > 0) && (u8Temp != L1Object.PREAMBLE));
            }

            if (fifo.GetLength() > 0)
            {
                /*Wait for getting full header data*/
                if (fifo.GetLength() >= L1Object.HEADER_LENGTH)
                {
                    if (bIsHeaderDetected != 1)
                    {
                        /*Get payload length*/
                        byte[] u8Header = fifo.GetNBytes(L1Object.HEADER_LENGTH);

                        if (!L1Object.L1Object_CheckCRC(u8Header, 0, L1Object.HEADER_LENGTH))
                        {
                            /*Wrong CRC Header*/
                            fifo.RetriveBytes(L1Object.HEADER_LENGTH);
                            l2State = L2State_E.NORMAL_MODE;
                            return;
                        }

                        u16PayloadLengthWaitting = (UInt16)((u8Header[L1Object.LEN_OFFSET] << 8) + u8Header[L1Object.LEN_OFFSET + 1]);

                        bIsHeaderDetected = 1;
                    }

                    if (u16PayloadLengthWaitting > L1Object.MAX_PAYLOAD_LEN)
                    {
                        /*Length of payload is over defined maximum value*/
                        byte[] u8Buff = new byte[L1Object.HEADER_LENGTH];

                        fifo.RetriveBytes(L1Object.HEADER_LENGTH);
                        bIsHeaderDetected = 0;
                        l2State = L2State_E.NORMAL_MODE;
                        return;
                    }
                    else
                    {
                        if (fifo.GetLength() < u16PayloadLengthWaitting + L1Object.HEADER_LENGTH + 1)
                        {
                            l2State = L2State_E.NORMAL_MODE;
                            /*Do not enough data*/
                            return;
                        }
                        else
                        {
                            sL1Object_t L1Obj = new sL1Object_t();
                            //ASSERT(u8Pkg);
                            byte[] u8Pkg = fifo.RetriveBytes(u16PayloadLengthWaitting + L1Object.HEADER_LENGTH + 1);
                            bIsHeaderDetected = 0;

                            /*Check CRC DATA and build package*/
                            if (L1Object.L1Object_ArrayToPkg(u8Pkg, u16PayloadLengthWaitting + L1Object.HEADER_LENGTH + 1, ref L1Obj) == 1)
                            {
                                /*Check received sequence and set the last sequence*/
                                if (IsValidSequence(L1Obj) == 1)
                                {
                                    /*Check Minor CMD : ACK/NAK/DATA...*/
                                    if (L1Object.L1Object_IsACKPkg(L1Obj))
                                    {
                                        /*Post semaphore ACK signal*/
                                        eACK = eACKType_t.ACK;
                                        ACKRespondEvent.Set();
                                    }
                                    else if (L1Object.L1Object_IsNAKPkg(L1Obj))
                                    {
                                        /*Post semaphore NAK signal*/
                                        eACK = eACKType_t.NAK;
                                        ACKRespondEvent.Set();
                                    }
                                    else if (L1Object.L1Object_IsPingPkg(L1Obj))
                                    {
                                        /*NOTE Process PING pakage*/
                                        /*Reset sequence and sync key*/
                                        u8LastRecvSeq = 255;

                                    }
                                    else if (L1Object.L1Object_IsSetAesKeyPkg(L1Obj))
                                    {
                                        /*Process SetAesKey pakage*/
                                        //(u8AesKey, 0x00, L1Object.MAX_KEY_SIZE);

                                        /*NOTE :Decrypt data and save to Aes key*/


                                    }
                                    else if (L1Object.L1Object_IsSyncKeyReqPkg(L1Obj))
                                    {
                                        /*NOTE :Process SyncKey request pakage*/
                                        /*Be ware that here is running in receiver interrupt*/

                                    }
                                    else
                                    {
                                        /*Process data package*/
                                        /*Call up to L3*/
                                        if (callbackFunc != null)
                                        {
                                            callbackFunc(L1Obj.aPayLoad);
                                        }

                                        if (L1Obj.bIsNeedFeedBackACK != 0)
                                        {
                                            L2SendCMD((byte)PKG_TYPE.ACK_PKG);
                                        }
                                    }
                                }
                                else
                                {
                                    Trace.WriteLine("Invalid sequence!\r\n");

                                    if (L1Object.L1Object_IsPingPkg(L1Obj))
                                    {
                                        /*NOTE Process PING package*/
                                        /*Reset sequence and sync key*/
                                        u8LastRecvSeq = 255;
                                    }
                                    else if (L1Obj.bIsNeedFeedBackACK != 0)
                                    {
                                        /*Get the same package, resend the last ACK/NAK package*/
                                        L2ReSendLastCMD();
                                    }
                                    else
                                    {
                                        /*Ignore*/
                                    }

                                }/*End of check valid sequence*/
                            }
                            else
                            {
                                /*Data has wrong format*/
                                /*Send NAK if this is mode needing return ACK*/
                                if (L1Obj.bIsNeedFeedBackACK != 0)
                                {
                                    L2SendCMD((byte)PKG_TYPE.NAK_PKG);
                                }

                                l2State = L2State_E.NORMAL_MODE;
                                return;
                            }/*End check CRC data*/

                        }/*End of build package*/

                        l2State = L2State_E.NORMAL_MODE;
                        return;
                    }/*End of check length of package*/
                }/*End of check length of header*/
            }/*End of Check preamble */
            return;
        }

        public int IsValidSequence(sL1Object_t sPkg)
        {
            return 1; 

            //if (sPkg.u8Seq == u8LastRecvSeq)
            //{
            //    return 0;
            //}
            //u8LastRecvSeq++;
            //return 1;
        }

        public int L2SendCMD(byte eMinor)
        {
            sL1Object_t L1Obj = new sL1Object_t();
            if (L1Object.L1Object_BuildCMDPkg(this, eMinor, u8Seq, ref L1Obj) == 1)
            {
                byte[] tempByte = new byte[L1Obj.u16DataLen + 1 + L1Object.HEADER_LENGTH];

                L1Object.L1Object_L1ObjectToArray(L1Obj, ref tempByte);

                try
                {
                    L1Handler.Send(tempByte);
                }
                catch (System.Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                    return 0;
                }

                /*Increase sequence*/
                u8Seq++;

                Buffer.BlockCopy(L1Obj.aPayLoad, 0, sObjLastCMDPkg.aPayLoad, 0, L1Obj.u16DataLen);
                sObjLastCMDPkg.bIsEnableEncrypt = L1Obj.bIsEnableEncrypt;
                sObjLastCMDPkg.bIsNeedFeedBackACK = L1Obj.bIsNeedFeedBackACK;
                sObjLastCMDPkg.u16DataLen = L1Obj.u16DataLen;
                sObjLastCMDPkg.u8MajorCmd = L1Obj.u8MajorCmd;
                sObjLastCMDPkg.u8MinorCmd = L1Obj.u8MinorCmd;
                sObjLastCMDPkg.u8Seq = L1Obj.u8Seq;

                return 1;
            }
            else
            {
                Trace.WriteLine("Can not build package from input data./r/n");
                return 0;
            }
        }

        public int L2ReSendLastCMD()
        {
            try
            {
                byte[] tempByte = new byte[sObjLastCMDPkg.u16DataLen + 1 + L1Object.HEADER_LENGTH];

                L1Object.L1Object_L1ObjectToArray(sObjLastCMDPkg, ref tempByte);

                L1Handler.Send(tempByte);
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine("Can not send data!\r\n");
                return 0;
            }

            return 1;
        }

        public int L2SendPingSgn()
        {
            sL1Object_t L1Obj = new sL1Object_t();

            if (L1Object.L1Object_BuildCMDPkg(this, (byte)PKG_TYPE.PING_PKG, u8Seq, ref L1Obj) == 1)
            {
                try
                {
                    byte[] tempByte = new byte[L1Obj.u16DataLen + 1 + L1Object.HEADER_LENGTH];

                    L1Object.L1Object_L1ObjectToArray(L1Obj, ref tempByte);

                    L1Handler.Send(tempByte);
                }
                catch (System.Exception ex)
                {
                    Trace.WriteLine("Can not send PING package!\r\n");
                    return 0;
                }

                /*Reset sequence*/
                u8Seq = 0;
                return 1;
            }
            else
            {
                Trace.WriteLine("Can not build package from input data./r/n");
                return 0;
            }
        }


        public bool IsConnected()
        {
            return L1Handler.IsConnected();
        }


    }

    public class L2Pkg
    {
        public byte[] data;
        public uint resend    = 0;
        public bool isNeededACK = false;
        public byte MinorCmd = 0;
        public L2Pkg()
        {

        }

        public L2Pkg(byte[] data, bool isNeedACK, uint resend, byte minorCMD)
        {
            this.MinorCmd     = minorCMD;
            this.data         = data;
            this.resend       = resend;
            this.isNeededACK  = isNeedACK;
        }

        public L2Pkg(string str, bool isNeedACK, uint resend, byte minorCMD)
        {
            this.MinorCmd = minorCMD;
            this.data       = Utils.Util.StrToByteArray(str);
            this.resend     = resend;
            this.isNeededACK  = isNeedACK;
        }

        public override string ToString()
        {
            string retStr = string.Empty;
            retStr += "Bin: "    + Utils.Util.ByteArrayToStrBinary(data) + "\r\n";
            retStr += "UTF-8: "  + Utils.Util.ByteArrayToStrUTF8(data) + "\r\n";
            retStr += "ACK : "   + isNeededACK.ToString() + "\r\n";
            retStr += "Resend: " + resend.ToString();

            return retStr;
        }
    }
}
