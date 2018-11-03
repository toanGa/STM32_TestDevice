using ELABO.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestImage.Protocol.Common
{

    /*enum*/
    public enum eMajorType_t
    {
        OMAP_L138_CMD,
        MSP_430_CMD,
        XPHONE_CMD,
        PC_CMD,
        MOBILE_CMD,
        NET_CMD,

        ERROR_CMD /*End CMD*/
    };

    public enum eACKType_t
    {
        NONE,
        ACK,
        NAK/*End CMD*/
    };

    public enum PKG_TYPE
    {
        ACK_PKG,
        NAK_PKG,
        VER_PKG,
        PING_PKG,
        SYNC_KEY_REQ,
        SET_AES_KEY,
        DEBUG_PKG,
        DATA_PKG,
    };

    public class L1Object
    {
        public static  int MAX_PAYLOAD_LEN = 1000;// 500
        public static  int MAX_KEY_SIZE = 16;
        public static  byte PREAMBLE = 0x23;
        public static  int PREAMBLE_OFFSET = 0;
        public static  int MAJOR_OFFSET = PREAMBLE_OFFSET + 1;
        public static  int MINOR_OFFSET = MAJOR_OFFSET + 1;
        public static  int SEQ_OFFSET = MINOR_OFFSET + 1;
        public static  int RESV_OFFSET = SEQ_OFFSET + 1;
        public static  int LEN_OFFSET = RESV_OFFSET + 1;
        public static  int HEADER_CRC_OFFSET = LEN_OFFSET + 2;
        public static  int PAYLOAD_OFFSET = HEADER_CRC_OFFSET + 1;
        public static  int HEADER_LENGTH = PAYLOAD_OFFSET;

        public static  byte DEFAULT_MAJOR_CMD = (byte)eMajorType_t.PC_CMD;
        public static  int IS_ENABLE_ENCRYPT_POS = 0;
        public static  int IS_NEED_FEEDBACK_ACK = 1;

        public static int L1Object_BuildFromData(L2Process L2Handler, byte[] u8Buff, byte eMinorCMD, byte u8Seq,ref sL1Object_t retL1Obj)
        {
            retL1Obj.u8MajorCmd = DEFAULT_MAJOR_CMD;
            retL1Obj.u8MinorCmd = eMinorCMD;
            retL1Obj.bIsNeedFeedBackACK = L2Handler.bIsNeedACK;
            retL1Obj.bIsEnableEncrypt = L2Handler.bIsEnableEncrypt;
            retL1Obj.u8Seq = u8Seq;
            retL1Obj.u16DataLen = u8Buff.Length;

            Buffer.BlockCopy(u8Buff, 0, retL1Obj.aPayLoad, 0, retL1Obj.u16DataLen);

            return 1;
        }

        public static int L1Object_BuildCMDPkg(L2Process L2Handler,
                              byte eMinorCMD,
                              byte u8Seq,
                              ref sL1Object_t retL1Obj)
        {
            //    ASSERT(retL1Obj);
            //    ASSERT(eMinorCMD == ACK_PKG || eMinorCMD == NAK_PKG || eMinorCMD == PING_PKG);

            retL1Obj.u8MajorCmd = DEFAULT_MAJOR_CMD;
            retL1Obj.u8MinorCmd = eMinorCMD;
            retL1Obj.bIsNeedFeedBackACK = L2Handler.bIsNeedACK;
            retL1Obj.bIsEnableEncrypt = L2Handler.bIsEnableEncrypt;
            retL1Obj.u8Seq = u8Seq;
            retL1Obj.u16DataLen = 0;

            return 1;
        }

        public static int L1Object_L1ObjectToArray(sL1Object_t L1Obj, ref byte[] u8RetBuff)
        {
            //ASSERT(L1Obj);
            //ASSERT(u8RetBuff);
            int ret;

            u8RetBuff[PREAMBLE_OFFSET] = PREAMBLE;
            u8RetBuff[MAJOR_OFFSET] = L1Obj.u8MajorCmd;
            u8RetBuff[MINOR_OFFSET] = L1Obj.u8MinorCmd;
            u8RetBuff[SEQ_OFFSET] = L1Obj.u8Seq;
            u8RetBuff[RESV_OFFSET] = (byte)((L1Obj.bIsEnableEncrypt << IS_ENABLE_ENCRYPT_POS) | (L1Obj.bIsNeedFeedBackACK << IS_NEED_FEEDBACK_ACK)/*| other information*/);
            u8RetBuff[LEN_OFFSET] = (byte)((L1Obj.u16DataLen >> 8) & 0xFF);
            u8RetBuff[LEN_OFFSET + 1] = (byte)(L1Obj.u16DataLen & 0xFF);
            /* Add CRC HEADER */
            ret = L1Object_AppendCRC(ref u8RetBuff, 0, HEADER_LENGTH);

            Buffer.BlockCopy(L1Obj.aPayLoad, 0, u8RetBuff, PAYLOAD_OFFSET, L1Obj.u16DataLen);

            /* Add CRC DATA */
            ret = L1Object_AppendCRC(ref u8RetBuff, PAYLOAD_OFFSET, L1Obj.u16DataLen + 1);

            return ret;
        }

        public static int L1Object_ArrayToPkg(byte[] u8Buff, int u16Len, ref sL1Object_t retObj)
        {
            //ASSERT(u8Buff);
            //ASSERT(retObj);
            //ASSERT(u16Len > HEADER_LENGTH);

            /*CRC HEADER was confirmed before*/
            /*
            if (!L1Object_CheckCRC(u8Buff, HEADER_LENGTH))
            {
                return RET_FAIL;
            }
            */
            retObj.u8MajorCmd = u8Buff[MAJOR_OFFSET];
            retObj.u8MinorCmd = u8Buff[MINOR_OFFSET];
            retObj.u8Seq = u8Buff[SEQ_OFFSET];
            retObj.bIsEnableEncrypt = (byte)((u8Buff[RESV_OFFSET] & (1 << IS_ENABLE_ENCRYPT_POS)) == 0 ? 0 : 1);
            retObj.bIsNeedFeedBackACK = (byte)((u8Buff[RESV_OFFSET] & (1 << IS_NEED_FEEDBACK_ACK)) == 0 ? 0 : 1);
            retObj.u16DataLen = (int)((u8Buff[LEN_OFFSET] << 8) + u8Buff[LEN_OFFSET + 1]);

            if (!L1Object_CheckCRC(u8Buff, PAYLOAD_OFFSET, retObj.u16DataLen + 1))
            {
                /*Wrong CRC data*/
                return 0;
            }

            if (u16Len <= HEADER_LENGTH ||
                u8Buff[PREAMBLE_OFFSET] != PREAMBLE ||
                retObj.u8MajorCmd >= (byte)eMajorType_t.ERROR_CMD ||
                retObj.u16DataLen + HEADER_LENGTH + 1/*1 bytes CRC DATA*/ != u16Len)
            {
                /*Length of data is not match value*/
                return 0;
            }
            Buffer.BlockCopy(u8Buff, PAYLOAD_OFFSET,retObj.aPayLoad, 0, retObj.u16DataLen);

            return 1;
        }

        public static bool L1Object_IsACKPkg(sL1Object_t L1Obj)
        {
            //ASSERT(L1Obj);

            return (L1Obj.u8MinorCmd == (byte)PKG_TYPE.ACK_PKG) ? true : false;
        }

        public static bool L1Object_IsNAKPkg(sL1Object_t L1Obj)
        {
            //ASSERT(L1Obj);

            return (L1Obj.u8MinorCmd == (byte)PKG_TYPE.NAK_PKG) ? true : false;
        }

        public static bool L1Object_IsPingPkg(sL1Object_t L1Obj)
        {
            //ASSERT(L1Obj);

            return (L1Obj.u8MinorCmd == (byte)PKG_TYPE.PING_PKG) ? true : false;
        }
        public static bool L1Object_IsSetAesKeyPkg(sL1Object_t L1Obj)
        {
            //ASSERT(L1Obj);

            return (L1Obj.u8MinorCmd == (byte)PKG_TYPE.SET_AES_KEY) ? true : false;
        }

        public static bool L1Object_IsSyncKeyReqPkg(sL1Object_t L1Obj)
        {
            //ASSERT(L1Obj);

            return (L1Obj.u8MinorCmd == (byte)PKG_TYPE.SYNC_KEY_REQ) ? true : false;
        }

        public static int L1Object_AppendCRC(ref byte[] u8Buff, int offset,
                                    int u16Len)
        {
            //ASSERT(u8Buff);
            //ASSERT(u16Len > 1);
            crc8 crcHandler = new crc8();

            u8Buff[offset + u16Len - 1] = crcHandler.crc_8(u8Buff, offset, u16Len - 1);

            return 1;
        }

        public static bool L1Object_CheckCRC(byte[] u8Buff, int offset,
                               int u16Len)
        {
            //ASSERT(u8Buff);
            crc8 crcHandler = new crc8();

            return (u8Buff[offset + u16Len - 1] == crcHandler.crc_8(u8Buff, offset, u16Len - 1));
        }



    }

    public class sL1Object_t
    {
        public byte u8MajorCmd;
        public byte u8MinorCmd;
        public byte u8Seq;
        public byte bIsEnableEncrypt;
        public byte bIsNeedFeedBackACK;
        public int u16DataLen;
        public byte[] aPayLoad = new byte[L1Object.MAX_PAYLOAD_LEN];
    }
}
