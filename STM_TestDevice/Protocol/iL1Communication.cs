using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELABO.Communication
{
    public delegate void L1DataReceived(object obj);

    interface iL1Communication
    {
        L1DataReceived L1DataReceivedEvent{ get; set; }

        void Open();

        void Close();

        bool IsConnected();

        void Send(string data);

        void Send(byte[] data);

        void CleanRxBuffer();
    }
}
