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
    public partial class SinggleBatInfo : Form
    {
        public static SinggleBatInfo BatInfo = new SinggleBatInfo(null);

        public SinggleBatInfo(Battery batteryInfo)
        {
            InitializeComponent();
            if(batteryInfo != null)
            {
                textBox1.Text = batteryInfo.gParameter.ToStringMultiLine();
            }
        }

        public void ShowInfo(Battery batteryInfo)
        {
            if (batteryInfo != null)
            {
                textBox1.Text = batteryInfo.gParameter.ToStringMultiLine();
            }
        }
    }
}
