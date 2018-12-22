using STM_TestDevice.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM_TestDevice.UI
{
    public partial class SinggleBatInfo : Form
    {
        public static SinggleBatInfo BatInfo = new SinggleBatInfo(null);
        Battery mBatDisplayInfor;
        public SinggleBatInfo(Battery batteryInfo)
        {
            InitializeComponent();
            mBatDisplayInfor = batteryInfo;
            if (batteryInfo != null)
            {
                textBox1.Text = batteryInfo.gParameter.ToStringMultiLine();
            }

        }

        public void ShowInfo(Battery batteryInfo)
        {
            mBatDisplayInfor = batteryInfo;
            if (batteryInfo != null)
            {
                textBox1.Text = batteryInfo.gParameter.ToStringMultiLine();
            }
        }

        public void ShowBatName(string batName)
        {
            labelInfo.Text = batName;
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            if((string)textBox1.Tag == "Detail")
            {
                textBox1.Tag = "";
                buttonDetail.Text = "Detail";
            }
            else
            {
                textBox1.Tag = "Detail";
                buttonDetail.Text = "Fewer";
            }

            if((string)textBox1.Tag == "Detail")
            {
                string allText = Program.batteryTest.GetTextLogStatusBat();
                string[] totalLineString = Regex.Split(allText, "\r\n|\r|\n");

                textBox1.Text = "";
                foreach (string s in totalLineString)
                {
                    if(s.Contains(labelInfo.Text))
                    {
                        textBox1.AppendText(s + "\r\n");
                    }
                }
            }
            else
            {
                // show fewer
                ShowInfo(mBatDisplayInfor);
            }
        }
    }
}
