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
        string[] currPortNames = SerialPort.GetPortNames();
        List<SerialPort> listSerialPort = new List<SerialPort>();
        List<string> listStringRecv = new List<string>();

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

        public bool DetectSerial(string containRespond, int baudRate)
        {
            foreach(SerialPort closePort in listSerialPort)
            {
                try
                {
                    closePort.Close();
                }
                catch(Exception ex)
                {

                }
            }

            listSerialPort.Clear();
            listStringRecv.Clear();

            for (int i = 0; i < currPortNames.Length; i++)
            {
                try
                {
                    SerialPort sp = new SerialPort();
                    sp.BaudRate = baudRate;
                    sp.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort_DataReceived);
                    sp.PortName = currPortNames[i];
                    sp.Open();
                    listSerialPort.Add(sp);
                    listStringRecv.Add(String.Empty);
                }
                catch(Exception ex)
                {

                }
            }
            return true;
        }

        // call back
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = sender as SerialPort;
            string dataRev = sp.ReadExisting();

            // open event to make receive datas
            string portName = sp.PortName;
            foreach (SerialPort port in listSerialPort)
            {
                if(port.PortName == portName)
                {
                    
                }
            }
        }
    }
}
