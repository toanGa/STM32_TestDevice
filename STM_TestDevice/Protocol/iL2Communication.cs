using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELABO.Communication
{
    public delegate void L2CallbackDataReceived(object obj);

    public delegate bool IsACKPkg(object data);

    public enum L2State_E
    {
        NORMAL_MODE,
        TX_MODE,
        RX_MODE,
        WAIT_RESP_MODE,
        ERROR = 0xff
    }

    interface iL2Communication
    {
        bool IsResetEn {get;set;}

        L2CallbackDataReceived CallbackFunc { get; set; }

        IsACKPkg CheckACKPkg { get; set; }

        L2State_E L2State { get; set; }

        void L2Start();

        void L2Stop();

        bool L2TXAddPkg(byte[] sendData, bool isNeedACK, uint resend, byte cmd);

        bool L2TXAddPkg(L2Pkg pkg);

        bool IsConnected();
    }
}
