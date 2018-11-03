using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agilent.CommandExpert.ScpiNet.AgU3606B_3_09_3_00_3_04;
//using System.Linq;
using Ivi.Visa.Interop;
namespace STM_TestDevice.GPIB
{
    class GPIBHelper
    {
        AgU3606B U3606B;

        public GPIBHelper(string location)
        {
            U3606B = new AgU3606B(location);
        }

        public double ReadResistance()
        {
            double reading = 0D;
            U3606B.SCPI.MEASure.RESistance.Query(null, null, out reading);
            return reading;
        }

        public double ReadVoltageDC()
        {
            double reading = 0D;
            U3606B.SCPI.MEASure.VOLTage.DC.Query(null, null, out reading);
            return reading;
        }

        public double ReadCurrentDC()
        {
            double reading = 0D;
            U3606B.SCPI.MEASure.CURRent.DC.Query(null, null, out reading);
            return reading;
        }

        public void Connect()
        {
            U3606B.Connect();
        }

        public void Disconnect()
        {
            U3606B.Disconnect();
        }

        public void Reconnect()
        {
            U3606B.Reconnect();
        }

        public void ResetDevice()
        {
            //U3606B.SCPI.STATus.PRESet.Command();
            U3606B.SCPI.RST.Command();
        }
    }
}
