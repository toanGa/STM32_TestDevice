using STM_TestDevice.Devices;
using STM_TestDevice.ExcellUtils;
using STM_TestDevice.Exporter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM_TestDevice.UI
{
    public partial class BatteryTest : Form
    {
        const string fileName = @"E:\ToanTV\STM\2.source c#\STM_TestDevice\STM_TestDevice\bin\Debug\ConfigBatery.xlsx";
        const string FILE_BUFFER = "LOG_BUFFER";
        string mLogString = "";

        List<Device> mDevices;
        DevicesParser mDevicesParser;
        ExcelExporter mExcelExporter;
        BackgroundWorker mFileSaveWorker = new BackgroundWorker();
        ManualResetEvent mManualResetEvent = new ManualResetEvent(false);
        StreamWriter mWriteBufferFile;

        public BatteryTest()
        {
            InitializeComponent();

            comboBox1.Items.Clear();
            comboBox1.DataSource = SerialPort.GetPortNames();

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            
            for (int i = 1; i < 13; i++)
            {
                Control currButton = GetControlByName("button" + i);
                if(currButton != null)
                {
                    Button b = (Button)currButton;
                    b.Text = "";
                }
            }

            //oldTextContent = File.ReadAllText(FILE_BUFFER);
            //ExcelExporter exp = new ExcelExporter(getPathReportFile());
            //exp.PasteText(oldTextContent, 1, 1, 1);
            //exp.Close();
            if (!File.Exists(FILE_BUFFER))
            {
                FileStream fs = File.Create(FILE_BUFFER);
                fs.Close();
            }

            foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
            {
                if (myProc.ProcessName == "EXCEL")
                {
                    myProc.Kill();
                    break;
                }
            }

            // setup stream writer
            // create stream overide old content of file
            mWriteBufferFile = new StreamWriter(FILE_BUFFER);
            mWriteBufferFile.AutoFlush = true;

            // background worker
            mFileSaveWorker.WorkerReportsProgress = true;
            mFileSaveWorker.WorkerSupportsCancellation = true;
            mFileSaveWorker.DoWork += fileSaveBackgroundWork;
            mFileSaveWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WaitReportComplete);
            mFileSaveWorker.RunWorkerAsync();
        }

        /// <summary>
        /// background save text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSaveBackgroundWork(object sender, DoWorkEventArgs e)
        {
            string saveString;
            //if (mExcelExporter == null)
            //{
            //    mExcelExporter = new ExcelExporter(getPathReportFile());
            //    mExcelExporter.Open();
            //}

            while(true)
            {
                mManualResetEvent.Reset();
                mManualResetEvent.WaitOne();
                
                if (!String.IsNullOrEmpty(mLogString))
                {
                    if (InvokeRequired)
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            lock (mLogString)
                            {
                                saveString = mLogString;
                            }
                            //excelExporter.PasteText(saveString, 1, 1, 1);
                            mWriteBufferFile.Write(saveString);
                            mLogString = "";
                        });
                    }
                    else
                    {
                        
                        lock (mLogString)
                        {
                            saveString = mLogString;
                        }
                        //excelExporter.PasteText(saveString, 1, 1, 1);
                        mWriteBufferFile.Write(saveString);
                        mLogString = "";
                    }
                }
                Thread.Sleep(1000);
            }

        }

        private void WaitReportComplete(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        // Globle function
        public void WriteSerial(string content)
        {
            try
            {
                serialPort.Write(content);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Control GetControlByName(string Name)
        {
            foreach (Control c in this.Controls)
                if (c.Name == Name)
                    return c;

            return null;
        }

        Device getDeviceByName(string name)
        {
            foreach (Device d in mDevices)
            {
                if (d.cmdName == name)
                {
                    return d;
                }
            }
            return null;
        }
        private string getPathConfigFile()
        {
            return Application.StartupPath + @"\" + textBoxConfigFile.Text;
        }

        private string getPathReportFile()
        {
            return Application.StartupPath + @"\" + textBoxReportFile.Text;
        }

        private void button_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("OK");
            Button b = sender as Button;
            if(!String.IsNullOrEmpty(b.Text))
            {
                Device rootDevice = getDeviceByName(b.Text);
                List<Device> listSetupDetail = mDevicesParser.ParseSetupData(rootDevice);
                if(listSetupDetail != null)
                {
                    SinggleSetupControl singgleSetup = new SinggleSetupControl(rootDevice, listSetupDetail);
                    singgleSetup.Show();
                }
            }
        }
        
        /// <summary>
        /// release all data when form close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatteryTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    mFileSaveWorker.CancelAsync();
            //    mWriteBufferFile.Close();

            //    serialPort.Close();
            //    string preCloseString = File.ReadAllText(FILE_BUFFER);
            //    mExcelExporter.PasteText(preCloseString, 1, 1, 1);
            //    mExcelExporter.Close();
            //    mDevicesParser.Close();
                  
            //    if (String.IsNullOrEmpty(mLogString))
            //    {
            //        mExcelExporter.PasteText(mLogString, 1, 1, 1);
            //    }
            //}
            //catch(Exception ex)
            //{

            //}

            // close thread background
            try
            {
                mFileSaveWorker.CancelAsync();
            }
            catch(Exception ex)
            {

            }

            // close stream writer
            try
            {
                mWriteBufferFile.Close();
            }
            catch (Exception ex)
            {

            }

            // close serial port
            try
            {
                serialPort.Close();
            }
            catch (Exception ex)
            {

            }

            // close exporter
            try
            {
                mExcelExporter = new ExcelExporter(getPathReportFile());
                mExcelExporter.Open();

                string preCloseString = File.ReadAllText(FILE_BUFFER);
                mExcelExporter.PasteText(preCloseString, 1, 1, 1);
                mExcelExporter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // close device parser
            try
            {
                mDevicesParser.Close();
            }
            catch (Exception ex)
            {

            }
        }
        
        private void buttonOpenCom_Click(object sender, EventArgs e)
        {
            if(serialPort.IsOpen)
            {
                try
                {
                    serialPort.Close();
                    buttonOpenCom.Text = "Open";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    serialPort.PortName = comboBox1.SelectedItem.ToString();
                    serialPort.Open();
                    buttonOpenCom.Text = "Close";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// save read data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // receive data here
            string result = serialPort.ReadExisting();

            // multithread acess logString
            lock(mLogString)
            {
                mLogString += result;
            }

            mManualResetEvent.Set();
        }

        /// <summary>
        /// open file then display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonViewConfig_Click(object sender, EventArgs e)
        {
            if (mDevicesParser == null)
            {
                mDevicesParser = new DevicesParser(getPathConfigFile());
            }
            else
            {
                //mDevicesParser.Close();
                //mDevicesParser = new DevicesParser(getPathConfigFile());
            }

            // check file is open
            try
            {
                mDevicesParser.OpenUI();
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// set worker do make this task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadConfig_Click(object sender, EventArgs e)
        {
            if (mDevicesParser == null)
            {
                mDevicesParser = new DevicesParser(getPathConfigFile());
            }
            else
            {
                //mDevicesParser.Close();
                //mDevicesParser = new DevicesParser(getPathConfigFile());
            }

            mDevicesParser.Open();
            mDevices = mDevicesParser.ParseConfigDefine();

            //devicesParser.Close();

            for (int i = 0; i < mDevices.Count; i++)
            {
                Control currButton = GetControlByName("button" + (i + 1));
                if (currButton != null)
                {
                    Button b = (Button)currButton;
                    //b.Click += button_Click;
                    b.Text = mDevices[i].cmdName;
                }
            }
        }
    }
}
