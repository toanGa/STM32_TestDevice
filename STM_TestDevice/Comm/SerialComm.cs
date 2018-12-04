using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM_TestDevice.Comm
{
    class SerialComm
    {
        public SerialPort serialPort = new SerialPort();

        public SerialComm(string portName)
        {
            serialPort.PortName = portName;
            serialPort.BaudRate = 115200;
        }

        public SerialComm(string portName, int baudrate)
        {
            serialPort.PortName = portName;
            serialPort.BaudRate = baudrate;
        }

        public bool Open()
        {
            try
            {
                serialPort.Open();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                serialPort.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Write(string data)
        {
            try
            {
                serialPort.Write(data);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
