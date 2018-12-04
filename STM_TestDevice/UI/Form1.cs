using ELABO.Communication;
using Microsoft.Office.Interop.Excel;
using STM_TestDevice.Devices;
using STM_TestDevice.ExcellUtils;
using STM_TestDevice.Exporter;
using STM_TestDevice.GPIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM_TestDevice
{
    public partial class Form1 : Form
    {
        private L2Process L2Handler;
        private ManualResetEvent RTSEvent = new ManualResetEvent(false);
        private GPIBHelper gpibHelper;

        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Clear();
            comboBox1.DataSource = SerialPort.GetPortNames();

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        public void InitFunc()
        {
            try
            {
                CommConfig cfg = new CommConfig();

                cfg.commType = CommType.RS232;
                cfg.PortName = comboBox1.SelectedItem.ToString();
                cfg.BaudRate = 115200;
                cfg.DataBit = 8;
                cfg.parity = System.IO.Ports.Parity.None;
                cfg.stopbit = System.IO.Ports.StopBits.One;

                L2Handler = new L2Process(cfg);
                L2Handler.CallbackFunc = new L2CallbackDataReceived(DataRecvFunc);
                L2Handler.bIsNeedACK = 0;
                L2Handler.bIsEnableEncrypt = 0;
                L2Handler.u8NumResend = 2;

                L2Handler.L2Start();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            // Test();
        }

        private void DataRecvFunc(object obj)
        {
            byte[] data = obj as byte[];

            //Do somethings with data here
            if (data[0] == (byte)'A' && data[1] == (byte)'C' && data[2] == (byte)'K')
            {
                RTSEvent.Set();
                Trace.WriteLine("Receive ACK");
                if(InvokeRequired)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        try
                        {
                            textBox1.AppendText("Receive ACK\n");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    });
                }
                else
                {
                    textBox1.Text = "Receive ACK";
                }
            }
            else
            {
                L2Handler.L2TXAddPkg(new byte[] { (byte)'A', (byte)'C', (byte)'K' }, false, 1, 7);
            }
        }

        private void Test()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += delegate
            {
                try
                {
                    if (InvokeRequired)
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            button1.Enabled = false;
                            button1.Text = "Waitiing";
                        });
                    }
                    else
                    {
                        button1.Enabled = false;
                        button1.Text = "Waitiing";
                    }

                    byte[] tempBytes = new byte[] { (byte)'H', (byte)'e', (byte)'l', (byte)'l', (byte)'o', (byte)'\r', (byte)'\n' };

                    L2Pkg pkg = new L2Pkg(tempBytes, false, 1, 7);
                    pkg.MinorCmd = 7;
                    L2Handler.L2TXAddPkg(pkg);
                    if (RTSEvent.WaitOne(10000))
                    {

                    }
                    else
                    {
                        ShowMsgInUIThread("Transfer ERROR", "STM comm");
                    }
                    RTSEvent.Reset();

                    if (InvokeRequired)
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            textBox1.Text = "done";
                        });
                    }
                    else
                    {
                        textBox1.Text = "done";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return;

            };
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WaitWorkerComplete);
            worker.RunWorkerAsync();
        }

        private void WaitWorkerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            button1.Text = "Send Test";
        }

        public DialogResult ShowMsgInUIThread(string detail, string caption = "Note", MessageBoxButtons bt = MessageBoxButtons.OK)
        {
            ManualResetEvent waitEvent = new ManualResetEvent(false);
            DialogResult retVal = DialogResult.OK;

            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    retVal = MessageBox.Show(this, detail, caption, bt);
                    //if (MessageBox.Show(detail, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                    //    // user clicked yes
                    //    Application.Exit();
                    //}
                    //else
                    //{
                    //    // user clicked no

                    //}
                    waitEvent.Set();
                });
            }
            else
            {
                retVal = MessageBox.Show(this, detail, caption, bt);
                //if (MessageBox.Show(detail, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    // user clicked yes
                //    Application.Exit();
                //}
                //else
                //{
                //    // user clicked no
                //}

                waitEvent.Set();
            }

            waitEvent.WaitOne();
            waitEvent.Reset();

            return retVal;
        }

        private void generateReport()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += delegate
            {
                try
                {
                    if (InvokeRequired)
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            buttonExport.Enabled = false;
                            buttonExport.Text = "Exporting";
                        });
                    }
                    else
                    {
                        button1.Enabled = false;
                        button1.Text = "Exporting";
                    }

                    String currDate = DateTime.Now.ToString("dd-MM-yyy");
                    ExcelExporter excelExporter = new ExcelExporter("d:\\report" + currDate + ".xls");
                    string exportResult = excelExporter.ExportCSV();
                    //textBox1.AppendText(excelExporter.ExportCSV() + "\n");

                    if (InvokeRequired)
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            textBox1.AppendText(exportResult + "\n");
                            textBox1.AppendText ("done\n");
                        });
                    }
                    else
                    {
                        textBox1.AppendText(exportResult + "\n");
                        textBox1.AppendText("done\n");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return;

            };
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WaitReportComplete);
            worker.RunWorkerAsync();
        }

        private void WaitReportComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonExport.Enabled = true;
            buttonExport.Text = "Export";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (L2Handler != null && L2Handler.IsConnected())
            {
                L2Handler.L2Stop();

                buttonOpenCom.Text = "Open COM";
                comboBox1.Enabled = true;
            }
            else
            {
                try
                {
                    InitFunc();
                    buttonOpenCom.Text = "Close COM";
                    comboBox1.Enabled = false;
                }
                catch (System.Exception ex)
                {
                    buttonOpenCom.Text = "Open COM";
                    comboBox1.Enabled = true;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isGPIBOpen = false;
            if(gpibHelper == null)
            {
                try
                {
                    gpibHelper = new GPIBHelper(textBoxGPIB.Text);
                    isGPIBOpen = true;
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
                    gpibHelper.Disconnect();
                    gpibHelper = null;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if(isGPIBOpen == true)
            {
                buttonGPIB.Text = "Close GPIB";
            }
            else
            {
                buttonGPIB.Text = "Open GPIB";
            }
        }

        private void buttonReadRES_Click(object sender, EventArgs e)
        {
            if(gpibHelper != null)
            {
                textBox1.AppendText(gpibHelper.ReadResistance() + "\n");
            }
        }

        private void buttonReadVolDC_Click(object sender, EventArgs e)
        {
            if (gpibHelper != null)
            {
                textBox1.AppendText(gpibHelper.ReadVoltageDC() + "\n");
            }
        }

        private void buttonCurrDC_Click(object sender, EventArgs e)
        {
            if (gpibHelper != null)
            {
                textBox1.AppendText(gpibHelper.ReadCurrentDC() + "\n");
            }
        }

        private void buttonResetGPIB_Click(object sender, EventArgs e)
        {
            gpibHelper.ResetDevice();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            string fileName = @"E:\ToanTV\STM\2.source c#\STM_TestDevice\STM_TestDevice\bin\Debug\ConfigBatery.xlsx";
            // generateReport();
            //TestCopyPasteTextExcell();
            DevicesParser devicesParser = new DevicesParser(fileName);
            devicesParser.Open();

            List<Device> devices = devicesParser.ParseConfigDefine();
            List<Device> detail = devicesParser.ParseSetupData(devices[0]);
            devicesParser.Close();

        }

        // test function
        void TestCopyPasteTextExcell()
        {
            string text = File.ReadAllText("LOG_1");
            ExcelExporter exp = new ExcelExporter(@"E:\ToanTV\STM\2.source c#\STM_TestDevice\STM_TestDevice\bin\Debug\result_battery.xlsx");
            exp.PasteText(text, 1, 1, 1);
            exp.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                L2Handler.L2Stop();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
