using STM_TestDevice.Comm;
using STM_TestDevice.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM_TestDevice.UI
{
    public partial class SinggleSetupControl : Form
    {

        Device rootDevice;
        public SinggleSetupControl(Device rootDevice, List<Device> listDevice)
        {
            InitializeComponent();

            this.rootDevice = rootDevice;
            if(rootDevice == null)
            {
                return;
            }
            
            // set for header
            foreach (string component in rootDevice.datas)
            {
                dataGridView1.Columns.Add(component, component);
            }

            // config singgle item
            if(listDevice == null)
            {
                return;
            }
            foreach(Device singgle in listDevice)
            {
                //listViewSetup.Items.Add(new ListViewItem(singgle.datas.ToArray(), setupGroup));
                dataGridView1.Rows.Add(singgle.datas.ToArray());
            }
        }

        public string DeviceParser { get; private set; }

        // send command to STM device
        private void buttonSend_Click(object sender, EventArgs e)
        {
            // TODO: send to STM by UART
            if(rootDevice != null)
            {

                //string strSend = rootDevice.getHeaderSend(Battery.CMD_INIT_PRE, Battery.CMD_SEPERATE);

                //int i;

                //for (i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    Device sendDevice = new Device();
                //    sendDevice.cmdName = rootDevice.cmdName;
                //    sendDevice.cmdValue = rootDevice.cmdValue;

                //    for (int j = 0; j < rootDevice.datas.Count; j++)
                //    {
                //        if(dataGridView1.Rows[i].Cells[j].Value != null)
                //        {
                //            sendDevice.datas.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
                //        }
                //    }
                //    if(sendDevice.datas.Count == rootDevice.datas.Count)
                //    {
                //        string sendSTM = sendDevice.getCmdSend();

                //        //Program.batteryTest.WriteSerial(sendSTM);
                //        strSend += sendSTM;
                //    }

                //}

                string strSend;
                if(rootDevice.cmdValue == Battery.CMD_RUN)
                {
                    strSend = getRUNCommand();
                }
                else
                {
                    strSend = getNormalCommand();
                }
                Program.batteryTest.WriteSerial(strSend);
            }
        }

        string getNormalCommand()
        {
            string strSend = rootDevice.getHeaderSend(Battery.CMD_INIT_PRE, Battery.CMD_SEPERATE);

            int i;

            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Device sendDevice = new Device();
                sendDevice.cmdName = rootDevice.cmdName;
                sendDevice.cmdValue = rootDevice.cmdValue;

                for (int j = 0; j < rootDevice.datas.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        sendDevice.datas.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                }
                if (sendDevice.datas.Count == rootDevice.datas.Count)
                {
                    string sendSTM = sendDevice.getCmdSend();

                    //Program.batteryTest.WriteSerial(sendSTM);
                    strSend += sendSTM;
                }
            }
            return strSend;
        }

        string getRUNCommand()
        {
            string strSend = rootDevice.getHeaderSend(Battery.CMD_INIT_PRE, Battery.CMD_SEPERATE);
            strSend += "@";
            strSend += dataGridView1.Rows[1].Cells[0].Value;
            int i;

            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Device sendDevice = new Device();
                sendDevice.cmdName = rootDevice.cmdName;
                sendDevice.cmdValue = rootDevice.cmdValue;

                for (int j = 0; j < rootDevice.datas.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        sendDevice.datas.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                }
                if (sendDevice.datas.Count == rootDevice.datas.Count)
                {
                    string sendSTM = "[" + sendDevice.datas[1] + "]";

                    //Program.batteryTest.WriteSerial(sendSTM);
                    strSend += sendSTM;
                }
            }
            return strSend;
        }
    }
}
