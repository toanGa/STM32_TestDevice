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

        Device mRootDevice;
        ContextMenuStrip mRightClickMenuStrip = new ContextMenuStrip();

        public SinggleSetupControl(Device rootDevice, List<Device> listDevice)
        {
            InitializeComponent();

            mRightClickMenuStrip.Items.Add("Delete");
            mRightClickMenuStrip.ItemClicked += rightClickMenuStrip_Click;

            this.mRootDevice = rootDevice;
            if(rootDevice == null)
            {
                return;
            }
            
            // set for header
            foreach (string component in rootDevice.gDatas)
            {
                dataGridView1.Columns.Add(component, component);
            }

            // config singgle item
            if(listDevice == null)
            {
                return;
            }

            // assign name
            this.Text = rootDevice.gCmdName;

            foreach (Device singgle in listDevice)
            {
                //listViewSetup.Items.Add(new ListViewItem(singgle.datas.ToArray(), setupGroup));
                dataGridView1.Rows.Add(singgle.gDatas.ToArray());
            }
        }

        private void rightClickMenuStrip_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            string itemString = ((ToolStripMenuItem)e.ClickedItem).ToString();
            if(itemString == "Delete")
            {
                try
                {
                    int rowIdx = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIdx);
                }
                catch
                {

                }
            }

        }


        // send command to STM device
        private void buttonSend_Click(object sender, EventArgs e)
        {
            // TODO: send to STM by UART
            if(mRootDevice != null)
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
                if(mRootDevice.gCmdValue == Battery.CMD_RUN)
                {
                    strSend = getRUNCommand();
                }
                else
                {
                    strSend = getNormalCommand();
                }
                strSend += Battery.CMD_END_COMMAND;

                Program.batteryTest.WriteSerial(strSend);
                Console.WriteLine(strSend);
            }
        }

        string getNormalCommand()
        {
            string strSend = mRootDevice.getHeaderSend(Battery.CMD_INIT_PRE, Battery.CMD_SEPERATE);

            int i;

            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Device sendDevice = new Device();
                sendDevice.gCmdName = mRootDevice.gCmdName;
                sendDevice.gCmdValue = mRootDevice.gCmdValue;

                for (int j = 0; j < mRootDevice.gDatas.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        sendDevice.gDatas.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                }
                if (sendDevice.gDatas.Count == mRootDevice.gDatas.Count)
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
            string strSend = mRootDevice.getHeaderSend(Battery.CMD_INIT_PRE, Battery.CMD_SEPERATE);
            strSend += dataGridView1.Rows[0].Cells[0].Value;
            strSend += "@";
            
            int i;

            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Device sendDevice = new Device();
                sendDevice.gCmdName = mRootDevice.gCmdName;
                sendDevice.gCmdValue = mRootDevice.gCmdValue;

                for (int j = 0; j < mRootDevice.gDatas.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        sendDevice.gDatas.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                }
                if (sendDevice.gDatas.Count == mRootDevice.gDatas.Count)
                {
                    string sendSTM = "[" + sendDevice.gDatas[1] + "]";

                    //Program.batteryTest.WriteSerial(sendSTM);
                    strSend += sendSTM;
                }
            }
            return strSend;
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if(dataGridView1.Rows.Count > 1)
                {
                    mRightClickMenuStrip.Show(this, e.X, e.Y);
                }
            }
        }
    }
}
