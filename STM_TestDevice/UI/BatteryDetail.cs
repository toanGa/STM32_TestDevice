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
    public partial class BatteryDetail : Form
    {
        public static string emtybatImageName = "Empty.png";
        public static string chargingBatImageName = "Charging.png";
        public static string fullBatImageName = "BatteryFull.png";
        public static string noBatImageName = "NoBat.png";

        public static BatteryDetail gBatDetailUI = new BatteryDetail();
        List<Battery> mtListBats;
        public BatteryDetail()
        {
            InitializeComponent();

            // clear lable text
            for (int i = 1; i <= Battery.NUMS_BATTERY; i++)
            {
                Control c = GetControlByName("label" + i);
                if(c != null)
                {
                    Label lbl = c as Label;
                    lbl.Text = "";
                    lbl.Visible = false;
                }

                Control ptbox = GetControlByName("pictureBox" + i);
                if(ptbox != null)
                {
                    ptbox.Tag = i;
                }
            }
        }

        public void UpdateBatStat(List<Battery> listBats)
        {
            int idxBat;
            mtListBats = listBats;
            for (int i = 0; i < listBats.Count; i++)
            {
                idxBat = i;
                Battery b = listBats[idxBat];
                string fileImage = GetFileBatImage((BatteryStatus)b.gParameter.stateOfBat);
                string batStatName = GetBatStatName((BatteryStatus)b.gParameter.stateOfBat);

                Control c = GetControlByName("pictureBox" + (idxBat + 1));
                if (c != null)
                {
                    PictureBox pictureBox = c as PictureBox;
                    pictureBox.ImageLocation = fileImage;
                }

                Control l = GetControlByName("label" + (idxBat + 1));
                Label lbl = l as Label;
                if (lbl != null)
                {
                    if (fileImage.EndsWith(emtybatImageName))
                    {
                        lbl.Text = batStatName;
                        lbl.Visible = true;
                    }
                    else
                    {
                        lbl.Text = "";
                        lbl.Visible = false;
                    }
                }
            }
        }

        public static string GetFileBatImage(BatteryStatus status)
        {
            string path = @"Resource\";
            switch(status)
            {
                case BatteryStatus.BAT_CHARGE:
                    path += chargingBatImageName;
                    break;
                case BatteryStatus.BAT_FULL:
                    path += fullBatImageName;
                    break;
                case BatteryStatus.BAT_NO_DETECTED:
                    path += noBatImageName;
                    break;
                default:
                    path += emtybatImageName;
                    break;
            }

            return path;
        }

        public static string GetBatStatName(BatteryStatus status)
        {
            string batStatName = "";
            switch (status)
            {
                case BatteryStatus.BAT_NO_DETECTED:
                    batStatName += "Bat no detected";
                    break;
                case BatteryStatus.BAT_OK:
                    break;
                case BatteryStatus.BAT_CHARGE_FAULT:
                    batStatName += "Charge Fault";
                    break;
                case BatteryStatus.BAT_PRE_CHARGE:
                    batStatName += "Pre charge";
                    break;
                case BatteryStatus.BAT_NO_CHARGER_NO_DISCHARGER:
                    batStatName += "No charge, No discharge";
                    break;
                case BatteryStatus.BAT_CHARGE_DISCHARGE:
                    batStatName += "Discharge";
                    break;
                case BatteryStatus.BAT_END_MEASURE_RESISTANCE:
                    batStatName += "Mesure resistance";
                    break;
                case BatteryStatus.BAT_CHARGE:
                    batStatName += "Charging";
                    break;
                case BatteryStatus.BAT_FULL:
                    batStatName += "Full";
                    break;
                case BatteryStatus.BAT_FULL_MEASURE_RESISTANCE:
                    batStatName += "Full mesure resistance";
                    break;
                case BatteryStatus.BAT_DISCHARGE:
                    batStatName += "Bat discharge";
                    break;
                case BatteryStatus.BAT_END:
                    batStatName += "Bat end";
                    break;
                default:
                    batStatName += "Code error!";
                    break;
            }

            return batStatName;
        }

        Control GetControlByName(string Name)
        {
            foreach (Control c in this.Controls)
                if (c.Name == Name)
                    return c;

            return null;
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            //SinggleBatInfo.BatInfo.Location = Cursor.Position;
            if(SinggleBatInfo.BatInfo.Visible)
            {
                SinggleBatInfo.BatInfo.Visible = false;
                Console.WriteLine("Bat info disable");
            }
               
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (!SinggleBatInfo.BatInfo.Visible)
            {
                PictureBox pt = sender as PictureBox;
                SinggleBatInfo.BatInfo.Location = Cursor.Position;
                SinggleBatInfo.BatInfo.Visible = true;

                lock(mtListBats)
                {
                    SinggleBatInfo.BatInfo.ShowInfo(mtListBats[(int)pt.Tag - 1]);
                }
                
                SinggleBatInfo.BatInfo.Text = "Bat " + (int)pt.Tag;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.batteryTest.FocusOnBatStat();
        }
    }
}
