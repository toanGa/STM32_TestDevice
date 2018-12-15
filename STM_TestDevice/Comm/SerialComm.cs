using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace STM_TestDevice.Comm
{
    class SerialComm
    {
        public SerialPort gSerialPort = new SerialPort();

        string[] mCurrPortNames = SerialPort.GetPortNames();

        List<SerialPort> mtListSerialPort = new List<SerialPort>();
        ManualResetEvent mRevDataEvent = new ManualResetEvent(false);

        int mMilisecondWait = 30000;
        string mStrContainResp = null;

        SerialPort mSerialPortDet = null;
        object mtLockSerialThread = new object();
        /// <summary>
        /// constructor
        /// </summary>
        public SerialComm()
        {

        }

        public SerialComm(string portName)
        {
            gSerialPort.PortName = portName;
            gSerialPort.BaudRate = 115200;
        }

        public SerialComm(string portName, int baudrate)
        {
            gSerialPort.PortName = portName;
            gSerialPort.BaudRate = baudrate;
        }

        /// <summary>
        /// public function
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            try
            {
                gSerialPort.Open();
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
                gSerialPort.Close();
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
                gSerialPort.Write(data);
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// Detect serial with fixed timeout wait respond
        /// </summary>
        /// <param name="containRespond"></param>
        /// <param name="baudRate"></param>
        /// <returns></returns>
        public SerialPort DetectSerial(string containRespond, int baudRate)
        {
            mStrContainResp = containRespond;
            mSerialPortDet = null;

            foreach (SerialPort closePort in mtListSerialPort)
            {
                try
                {
                    closePort.Close();
                }
                catch(Exception ex)
                {

                }
            }

            mtListSerialPort.Clear();
            
            for (int i = 0; i < mCurrPortNames.Length; i++)
            {
                try
                {
                    SerialPort sp = new SerialPort();
                    sp.BaudRate = baudRate;
                    sp.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort_DataReceived);
                    sp.PortName = mCurrPortNames[i];
                    sp.Open();
                    // if open success -> add port to list
                    mtListSerialPort.Add(sp);
                }
                catch(Exception ex)
                {

                }
            }

            mRevDataEvent.Reset();
            bool rstWait = mRevDataEvent.WaitOne(mMilisecondWait);

            // clean data
            foreach (SerialPort closePort in mtListSerialPort)
            {
                try
                {
                    closePort.Close();
                }
                catch (Exception ex)
                {

                }
            }
            return mSerialPortDet;
        }

        /// <summary>
        /// detect serial with sepecific timeout
        /// </summary>
        /// <param name="containRespond"></param>
        /// <param name="baudRate"></param>
        /// <param name="milisecond"></param>
        /// <returns></returns>
        public SerialPort DetectSerial(string containRespond, int baudRate, int milisecond)
        {
            mMilisecondWait = milisecond;
            return DetectSerial(containRespond, baudRate);
        }

        // call back in list port
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock(mtLockSerialThread)
            {
                SerialPort sp = sender as SerialPort;
                string dataRev = sp.ReadExisting();
                if(dataRev.Contains(mStrContainResp))
                {
                    Console.Write(dataRev);
                    // open event to make receive datas
                    string portName = sp.PortName;
                    for (int i = 0; i < mtListSerialPort.Count; i++)
                    {
                        if (mtListSerialPort[i].PortName == portName && dataRev.Contains(mStrContainResp))
                        {
                            mSerialPortDet = mtListSerialPort[i];
                            mRevDataEvent.Set();
                            
                            break;
                        }
                    }
                }
            }
        }
    }
}
