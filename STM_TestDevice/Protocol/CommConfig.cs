using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELABO.Communication
{
    public enum CommType
    {
        RS232,
        TCPIP
    }

    public class CommConfig
    {
        public CommType commType = CommType.RS232;

        public string PortName = string.Empty;
        public int BaudRate = 115200;
        public int DataBit = 8;
        public Parity parity = Parity.None;
        public StopBits stopbit = StopBits.One;

        public string IPAddress = "127.0.0.1";
        public int IPPort = 8888;
        public CommConfig()
        {

        }

        public string[] GetAvailablePort()
        {
            return SerialPort.GetPortNames();
        }

        public string GetName()
        {
            if(commType == CommType.RS232)
            {
                return PortName;
            }
            else if( commType == CommType.TCPIP)
            {
                return IPAddress.Replace('.', '_') + "_" + IPPort.ToString("0000");
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
