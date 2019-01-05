using STM_TestDevice.Comm;
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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using WpfControlLibraryBat;

namespace STM_TestDevice.UI
{
    public partial class BatteryTest : Form
    {
        const string FILE_BUFFER = "LOG_BUFFER";
        const string FODER_RESULT = "ResultTest";
        const string HELP_FILE = "help_user";
        const string PRE_BUTTON_CFG_NAME = "buttonConfig";
        string mtLogString = "";
        string mtUpdateBatStatUI = "";

        string fileConfigBattery_Root = Application.StartupPath + @"\" + "ConfigBatery_Root.xlsx";
        string fileResult_battery_Root = Application.StartupPath + @"\" + "result_battery_Root.xlsx";
        
        List<Device> mDevices;
        DevicesParser mDevicesParser;
        ExcelExporter mtExcelExporter;
        List<Battery> mtListBatStat = new List<Battery>();
        // background woker
        BackgroundWorker mFileSaveWorker = new BackgroundWorker();
        ManualResetEvent mFileSaveEvent = new ManualResetEvent(false);

        BackgroundWorker mPasteExcellWorker = new BackgroundWorker();
        ManualResetEvent mPasteExcelEvent = new ManualResetEvent(false);

        BackgroundWorker mUpdateBatStatUIWoker = new BackgroundWorker();
        ManualResetEvent mUpdateBatStatUIEvent = new ManualResetEvent(false);

        // first condition worker run
        ManualResetEvent mOpenFileSaveThreadEvent = new ManualResetEvent(false);
        ManualResetEvent mOpenPasteExcellThredEvent = new ManualResetEvent(false);
        ManualResetEvent mOpenUpdateBatStatUIThredEvent = new ManualResetEvent(false);

        /// <summary>
        /// stream writer to write file
        /// </summary>
        StreamWriter mtWriteBufferFile;
        StreamWriter mWriteResuleBat;
        // Globle timer
        public int gTimerDrawChart = 0;// 


        /// <summary>
        /// init form
        /// </summary>
        public BatteryTest()
        {
            InitializeComponent();
            
            // conbobox
            comboBoxControl.Items.Clear();
            comboBoxControl.DataSource = SerialPort.GetPortNames();

            // Auto detect serial port for Control com
            if (comboBoxControl.Items.Count > 0)
            {
                SerialComm serialComm = new SerialComm();
                SerialPort detSerial = serialComm.DetectSerial("P[", 115200, 3000);
                if (detSerial != null)
                {
                    for (int i = 0; i < comboBoxControl.Items.Count; i++)
                    {
                        if (comboBoxControl.Items[i].ToString() == detSerial.PortName)
                        {
                            comboBoxControl.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    comboBoxControl.SelectedIndex = 0;
                }
            }


            comboBoxData.Items.Clear();
            comboBoxData.DataSource = SerialPort.GetPortNames();
            // Auto detect serial port for Data com
            if (comboBoxData.Items.Count > 0)
            {
                SerialComm serialComm = new SerialComm();
                SerialPort detSerial = serialComm.DetectSerial("\t", 115200, 3000);
                if(detSerial != null)
                {
                    for(int i = 0; i < comboBoxData.Items.Count; i++)
                    {
                        if(comboBoxData.Items[i].ToString() == detSerial.PortName)
                        {
                            comboBoxData.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    comboBoxData.SelectedIndex = 0;
                }
            }
            // end of combobox setup

            // clear button text
            for (int i = 1; i < 13; i++)
            {
                Control currButton = GetControlByName("buttonConfig" + i);
                if (currButton != null)
                {
                    Button b = (Button)currButton;
                    b.Text = "";
                    b.Visible = false;
                }
            }

            // init list battery
            for(int i = 0; i < Battery.NUMS_BATTERY; i++)
            {
                mtListBatStat.Add(new Battery());
            }
            
            // init Help
            if(File.Exists(FileUtils.GetFullPath(HELP_FILE)))
            {
                textBoxHelp.Text = File.ReadAllText(FileUtils.GetFullPath(HELP_FILE));
            }

            // update battery control
            batteryDetailControl.UpdateBatStat(mtListBatStat);

            //oldTextContent = File.ReadAllText(FILE_BUFFER);
            //ExcelExporter exp = new ExcelExporter(getPathReportFile());
            //exp.PasteText(oldTextContent, 1, 1, 1);
            //exp.Close();
            if (!File.Exists(FILE_BUFFER))
            {
                FileStream fs = File.Create(FILE_BUFFER);
                fs.Close();
            }

            if (!File.Exists(getPathConfigFile()))
            {
                MessageBox.Show("Config file not exsited, auto generate config file");
                File.Copy(fileConfigBattery_Root, getPathConfigFile());
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
            mtWriteBufferFile = new StreamWriter(FILE_BUFFER);
            DateTime dtNow = DateTime.Now;
            string fileGen = FODER_RESULT + "/" + dtNow.Year + "-" + dtNow.Month + "-" + dtNow.Day + "_" + dtNow.Hour + "h" + dtNow.Minute + "m" + dtNow.Second + "s";
            if(!Directory.Exists(FODER_RESULT))
            {
                Directory.CreateDirectory(FODER_RESULT);
            }
            if (!File.Exists(fileGen))
            {
                FileStream fs = File.Create(fileGen);
                fs.Close();
            }
            mWriteResuleBat = new StreamWriter(fileGen);
            mWriteResuleBat.AutoFlush = true;

            // background worker
            mFileSaveWorker.WorkerReportsProgress = true;
            mFileSaveWorker.WorkerSupportsCancellation = true;
            mFileSaveWorker.DoWork += fileSaveBackgroundWork;
            mFileSaveWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WaitReportComplete);
            mFileSaveWorker.RunWorkerAsync();

            mPasteExcellWorker.WorkerReportsProgress = true;
            mPasteExcellWorker.WorkerSupportsCancellation = true;
            mPasteExcellWorker.DoWork += pasteExcellBackgroundWork;
            mPasteExcellWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WaitReportComplete);
            mPasteExcellWorker.RunWorkerAsync();

            mUpdateBatStatUIWoker.WorkerReportsProgress = true;
            mUpdateBatStatUIWoker.WorkerSupportsCancellation = true;
            mUpdateBatStatUIWoker.DoWork += UpdateBatStatUIWork;
            mUpdateBatStatUIWoker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WaitReportComplete);
            mUpdateBatStatUIWoker.RunWorkerAsync();

            // init for test
            if (!File.Exists(getPathReportFile()))
            {
                MessageBox.Show("Generate file not exsisted, Auto generate file");
                File.Copy(fileResult_battery_Root, getPathReportFile());
            }
        }

        /// <summary>
        /// close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatteryTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            // close thread background
            try
            {
                mFileSaveWorker.CancelAsync();
                mPasteExcellWorker.CancelAsync();
                mUpdateBatStatUIWoker.CancelAsync();
            }
            catch (Exception ex)
            {

            }

            // close stream writer
            try
            {
                mtWriteBufferFile.Close();
                mWriteResuleBat.Close();
            }
            catch (Exception ex)
            {

            }

            // close serial port
            try
            {
                serialPortControl.Close();
                serialPortData.Close();
            }
            catch (Exception ex)
            {

            }

            // close exporter
            try
            {
                if (!File.Exists(getPathReportFile()))
                {
                    MessageBox.Show("Generate file not exsisted, Auto generate file");
                    File.Copy(fileResult_battery_Root, getPathReportFile());
                }

                string preCloseString = File.ReadAllText(FILE_BUFFER);

                if (mtExcelExporter != null)
                {
                    lock (mtExcelExporter)
                    {
                        mtExcelExporter.PasteText(preCloseString, 1, 1, 1);
                        mtExcelExporter.CloseExcelFile();
                    }
                }
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

        // Globle function
        public void WriteSerial(string content)
        {
            try
            {
                serialPortControl.Write(content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FocusOnBatStat()
        {
            textBoxLogStatusBat.Focus();
        }

        public string GetTextLogStatusBat()
        {
            return textBoxLogStatusBat.Text;
        }


        public IEnumerable<Control> GetAllControl(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControl(ctrl))
                                      .Concat(controls); ;
        }

        public IEnumerable<Control> GetAllControl(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControl(ctrl, type))
                                      .Concat(controls); ;
        }

        // sub funtion
        Control GetControlByName(string Name)
        {
            var controls = GetAllControl(this);
            foreach (Control c in controls)
                if (c.Name == Name)
                    return c;

            return null;
        }

        Device getDeviceByName(string name)
        {
            if(mDevices != null)
            {
                foreach (Device d in mDevices)
                {
                    if (d.gCmdName == name)
                    {
                        return d;
                    }
                }
            }
            return null;
        }

        private string getPathConfigFile()
        {
            return FileUtils.GetFullPath(textBoxConfigFile.Text);
        }

        private string getPathReportFile()
        {
            return FileUtils.GetFullPath(textBoxReportFile.Text);
        }
        // Event function

        /// <summary>
        /// control setup button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("OK");
            Button b = sender as Button;
            if (!String.IsNullOrEmpty(b.Text))
            {
                Device rootDevice = getDeviceByName(b.Text);
                if(rootDevice != null)
                {
                    List<Device> listSetupDetail = mDevicesParser.ParseSetupData(rootDevice);
                    if (listSetupDetail != null)
                    {
                        SinggleSetupControl singgleSetup = new SinggleSetupControl(rootDevice, listSetupDetail);
                        singgleSetup.Show();
                    }
                }
            }
        }

        /// <summary>
        /// open, close control COM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonControlCom_Click(object sender, EventArgs e)
        {
            if (serialPortControl.IsOpen)
            {
                try
                {
                    serialPortControl.Close();
                    buttonControlCom.Text = "Open";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    serialPortControl.PortName = comboBoxControl.SelectedItem.ToString();
                    serialPortControl.Open();
                    buttonControlCom.Text = "Close";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Open, Close Data COM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDataCom_Click(object sender, EventArgs e)
        {
            if (serialPortData.IsOpen)
            {
                try
                {
                    serialPortData.Close();
                    buttonDataCom.Text = "Open";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    serialPortData.PortName = comboBoxData.SelectedItem.ToString();
                    serialPortData.Open();
                    buttonDataCom.Text = "Close";
                }
                catch (Exception ex)
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
        private void serialPortControl_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string result = serialPortControl.ReadExisting();
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    richTextBoxDebug.AppendText(result);
                });
            }
            else
            {
                richTextBoxDebug.AppendText(result);
            }
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
            catch (Exception ex)
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

            //Battery.CreateReportFile(Application.StartupPath + "\\toan_creat_full.xlsx");
            //return;

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
                Control currButton = GetControlByName("buttonConfig" + (i + 1));
                Button b = (Button)currButton;
                if (currButton != null)
                {
                    //b.Click += button_Click;
                    b.Text = mDevices[i].gCmdName;
                    b.Visible = true;
                }
                else
                {
                    b.Visible = false;
                }
            }

            mOpenFileSaveThreadEvent.Set();
            mOpenPasteExcellThredEvent.Set();
            mOpenUpdateBatStatUIThredEvent.Set();

            // disable change report file if thread is running
            buttonOpenReportFile.Enabled = false;
        }

        /// <summary>
        /// receive log data -> just copy data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPortData_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // receive data here
            string result = serialPortData.ReadExisting();

            if(mDevicesParser != null)
            {
                // multithread acess logString
                lock (mtLogString)
                {
                    mtLogString += result;
                }

                mFileSaveEvent.Set();
            }

            lock(mtUpdateBatStatUI)
            {
                mtUpdateBatStatUI += result;
                mUpdateBatStatUIEvent.Set();
            }
        }


        /// <summary>
        /// Test purpose
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTest_Click(object sender, EventArgs e)
        {
            Window1 wpfWin = new WpfControlLibraryBat.Window1();
            ElementHost.EnableModelessKeyboardInterop(wpfWin);
            Window1.myForm.Show();

            // end test
            Console.WriteLine("Test perpose");
            mPasteExcelEvent.Reset();
            mPasteExcelEvent.Set();

            //SerialComm serialComm = new SerialComm();
            //SerialPort detectPort = serialComm.DetectSerial("Toan", 115200);
        }

        /// <summary>
        /// chang Timer update data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTimerDrawChart_Click(object sender, EventArgs e)
        {
            if(timerUpdateData.Enabled == false)
            {
                return;
            }

            int parseValue = 0;
            if (buttonChangeTimerDrawChart.Text == "Save")
            {
                if (int.TryParse(textBoxTimerDrawChart.Text, out parseValue))
                {
                    if(parseValue > 0)
                    {
                        gTimerDrawChart = parseValue;

                        // if timer is running
                        if(timerUpdateData.Enabled)
                        {
                            timerUpdateData.Enabled = false;
                        }

                        timerUpdateData.Interval = gTimerDrawChart * 1000;
                        timerUpdateData.Enabled = true;
                    }
                    else if(parseValue == 0)
                    {
                        timerUpdateData.Enabled = false;
                    }
                }
            }

            if(parseValue < 0)
            {
                MessageBox.Show("Wrong text enter. Try again!");
            }
            else
            {
                buttonChangeTimerDrawChart.Text = "Change";
            }
        }

        /// <summary>
        /// action when change text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTimerDrawChart_TextChanged(object sender, EventArgs e)
        {
            buttonChangeTimerDrawChart.Text = "Save";
        }

        /// <summary>
        /// timer update data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerUpdateData_Tick(object sender, EventArgs e)
        {
            mPasteExcelEvent.Reset();
            mPasteExcelEvent.Set();
        }

        /// <summary>
        /// system checking tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        int tickCnt = 0;
        private void timerSystemChecking_Tick(object sender, EventArgs e)
        {
            labelSysInfo.ForeColor = Color.Red;

            string textInfo = "";
            if(mDevicesParser == null)
            {
                textInfo = "Config file NOT loaded";
            }
            else if(!serialPortControl.IsOpen)
            {
                textInfo = "Control Port is closed";
            }
            else if (!serialPortData.IsOpen)
            {
                textInfo = "Data Port is closed";
            }
            else
            {
                textInfo = "System is running";
                labelSysInfo.ForeColor = Color.Green;
            }

            tickCnt++;
            if(tickCnt > 3)
            {
                tickCnt = 1;
            }
            switch (tickCnt)
            {
                case 1:
                    textInfo += "...";
                    break;
                case 2:
                    textInfo += "......";
                    break;
                case 3:
                    textInfo += ".........";
                    break;
                default:
                    break;
            }

            labelSysInfo.Text = textInfo;
        }

        private void comboBoxData_DropDown(object sender, EventArgs e)
        {
            comboBoxData.DataSource = null;
            comboBoxData.Items.Clear();
            comboBoxData.DataSource = SerialPort.GetPortNames();
        }

        private void comboBoxControl_DropDown(object sender, EventArgs e)
        {
            comboBoxControl.DataSource = null;
            comboBoxControl.Items.Clear();
            comboBoxControl.DataSource = SerialPort.GetPortNames();
        }

        /// <summary>
        /// create report file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReportFile_Click(object sender, EventArgs e)
        {
            int parseValue = 0;
            bool rstReport;

            if (!int.TryParse(textBoxNumsRowCreate.Text, out parseValue))
            {
                MessageBox.Show("Invalid text input");
                return;
            }
            if(parseValue <= 0)
            {
                MessageBox.Show("Invalid text input");
                return;
            }

            Battery.gNumsRow = parseValue;
            if (File.Exists(textBoxGenReportFile.Text))
            {
                MessageBox.Show("File exsited!", "Warning!");
            }
            else
            {
                rstReport = Battery.CreateReportFile(textBoxGenReportFile.Text);
                //rstReport = Battery.CreateChartForFile(textBoxGenReportFile.Text);
                if (rstReport)
                {
                    MessageBox.Show("Reported file success");
                }
                else
                {
                    MessageBox.Show("Reported file fail");
                }
            }
        }

        /// <summary>
        /// fomat chart for a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFomatChart_Click(object sender, EventArgs e)
        {
            string path = FileUtils.GetFullPath(textBoxFomatChart.Text);
            Battery.CreateChartForFile(path);
        }
        
        /// <summary>
        /// enable or disable auto draw chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAutoDrawChart_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;

            if(c.Checked)
            {
                timerUpdateData.Enabled = true;
            }
            else
            {
                timerUpdateData.Enabled = false;
            }
        }
        
        private void buttonChangeConfigFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                //InitialDirectory = @"D:\",
                Title = "Open Config file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxConfigFile.Text = openFileDialog1.FileName;
            }
        }

        private void buttonOpenReportFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                //InitialDirectory = @"D:\",
                Title = "Open Report file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxReportFile.Text = openFileDialog1.FileName;
            }
        }

        private void buttonOpenFileFomatChart_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                //InitialDirectory = @"D:\",
                Title = "Open file to fomat chart",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFomatChart.Text = openFileDialog1.FileName;
            }
        }

        private void buttonViewBatStat_Click(object sender, EventArgs e)
        {
            //if (!BatteryDetail.gBatDetailUI.Visible)
            //{
            //    BatteryDetail.gBatDetailUI = new BatteryDetail();
            //}
            batteryDetailControl.UpdateBatStat(mtListBatStat);
            batteryDetailControl.Visible = true;
            batteryDetailControl.Focus();
        }

        private void buttonDeviceConfig_Click(object sender, EventArgs e)
        {
            SidePanel.Height = buttonDeviceConfig.Height;
            SidePanel.Top = buttonDeviceConfig.Top;
            panelFileConfig.Hide();
            panelDeviceConfig.Show();
            //panelDeviceConfig.BringToFront();
        }

        private void buttonFileConfig_Click(object sender, EventArgs e)
        {
            SidePanel.Height = buttonFileConfig.Height;
            SidePanel.Top = buttonFileConfig.Top;

            panelDeviceConfig.Hide();
            panelFileConfig.Show();
            //panelFileConfig.BringToFront();
        }

        private void button13_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Key down\r\n");
        }

        private void button13_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("Key Press\r\n");
        }

        private void button13_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Key Up\r\n");
        }
    }
}
