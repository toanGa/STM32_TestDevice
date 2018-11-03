using ELABO.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ELABO.Communication
{

    public class RS232Connection : iL1Communication
    {
        private ThreadsManager ThMan = ThreadsManager.GetInstance();

        private Thread ThreadCom;
        // common param
        private CommConfig config; //store all config initialize for this connection
        private bool isConnected; //indicated that connection is opened?
        private SerialPort seialPort; //serial port object
        private ByteBuffer bytesReceived = new ByteBuffer(); // store byte received from COM PORT
        private ManualResetEvent ComRecvBytes = new ManualResetEvent(false);
        private byte[] lastSendBytes;

        private L1DataReceived RS232DataReceivedEvent;

        public L1DataReceived L1DataReceivedEvent
        {
            get { return RS232DataReceivedEvent; }
            set { RS232DataReceivedEvent = value; }
        }
        
        public RS232Connection(CommConfig conf)
        {
            this.config = conf;
            isConnected = false;
        }
        #region Common Method
        public CommConfig GetConfig()
        {
            return config;
        }

        /// <summary>
        /// open connection with given config
        /// </summary>
        public virtual void Open()
        {
            try
            {
                if (seialPort != null)
                {
                    seialPort.Close();
                }
                seialPort = new SerialPort();
                seialPort.PortName = config.PortName;
                seialPort.BaudRate = config.BaudRate;
                seialPort.DataBits = config.DataBit;
                seialPort.Parity = config.parity;
                seialPort.StopBits = config.stopbit;

                // Set the read/write timeouts
                //TODO: get grom config, do not hardcode
                seialPort.ReadBufferSize = 4096;
                seialPort.WriteBufferSize = 4096;
                seialPort.ReadTimeout = 1000;
                seialPort.WriteTimeout = 1500;

                // set handler
                seialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                seialPort.Open();
                seialPort.DiscardInBuffer();
                isConnected = true;

                ThreadCom = new Thread(new ThreadStart(NotifyReceiveMessage));
                ThreadCom.Name = "Communications - Receive message. L1 " + config.GetName();

                ThMan.AddThread(ThreadCom.Name, ThreadCom);

                ThreadCom.Start();
            }
            catch (System.Exception ex)
            {
                isConnected = false;
                throw ex;
            }
        }

        /// <summary>
        /// close connection and release resources
        /// </summary>
        public virtual void Close()
        {
            try
            {
                ThreadCom.Abort();
                ThMan.RemoveThread(ThreadCom.Name);
                ThreadCom = null;

                isConnected = false;
                seialPort.DiscardOutBuffer();
                seialPort.Close();
                seialPort = null;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /************************************************************************/
        /* handle received data event from com232                               */
        /************************************************************************/
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (seialPort != null)
            {
                byte[] buff = new byte[((SerialPort)sender).BytesToRead];
                seialPort.Read(buff, 0, buff.Length);
                bytesReceived.PutByte(buff);
                ComRecvBytes.Set();
            }
            else
                throw new Exception("Have something went wrong with serial port.");
        }

        private void NotifyReceiveMessage()
        {
            while (true)
            {
                if (bytesReceived.GetLength() > 0 || ComRecvBytes.WaitOne(1111))
                {
                    ComRecvBytes.Reset();
                    //Notify Receive Message to L2
                    if (bytesReceived.GetLength() > 0 && L1DataReceivedEvent != null)
                    {
                        L1DataReceivedEvent(bytesReceived);
                    }
                }
                else
                    ComRecvBytes.Reset();
            }
        }

        /// <summary>
        /// IsConnected
        /// </summary>
        /// <returns></returns>
        public virtual bool IsConnected()
        {
            return isConnected;
        }

        /// <summary>
        /// Send byte array to COM Port
        /// </summary>
        /// <param name="data"></param>
        public virtual void Send(string data)
        {
            if ((data == null) || (data.Length <= 0))
            {
                return;
            }
            if (data.Length > seialPort.WriteBufferSize)
            {
                throw new Exception("The length of data should be less than " + seialPort.WriteBufferSize);
            }
            else
            {
                if (!isConnected)
                {
                    Open();
                }
                Write(Utils.Util.StrToByteArray(data));
            }
        }

        public virtual void Send(byte[] data)
        {
            if ((data == null) || (data.Length <= 0))
            {
                return;
            }
            if (data.Length > seialPort.WriteBufferSize)
            {
                throw new Exception("The length of data should be less than " + seialPort.WriteBufferSize);
            }
            else
            {
                if (!isConnected)
                {
                    Open();
                }
                Write(data);
            }
        }

        public void CleanRxBuffer()
        {
            bytesReceived.RetriveBytes(bytesReceived.GetLength());
        }

        private void Write(byte[] data)
        {
            if (seialPort.IsOpen)
            {
                seialPort.Write(data, 0, data.Length);
                //Trace.WriteLine("Send raw data to uart:");
                //Trace.WriteLine(data.ToString());
                lastSendBytes = data;
            }
            else
                throw new Exception("Have something went wrong with serial port.");
        }

        #endregion
    }
}
