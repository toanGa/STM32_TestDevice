using STM_TestDevice.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM_TestDevice
{
    static class Program
    {
        public static BatteryTest batteryTest;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            batteryTest = new BatteryTest();
            Application.Run(batteryTest);
        }
    }
}
