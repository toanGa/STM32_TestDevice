using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM_TestDevice.Devices
{
    /// <summary>
    /// reference HUY DAI protocol: "battery transfer protocol define.pdf"
    /// </summary>
    public class Device
    {
        public string cmdName;
        public string cmdValue;
        public List<string> datas = new List<string>();

        public virtual string getHeaderSend(string pre, string seprate)
        {
            string headerString = pre + cmdValue + seprate;
            return headerString;
        }

        public virtual string getCmdSend()
        {
            int numsData = datas.Count;

            string cmdString = "";

            if(numsData > 0)
            {
                cmdString += "[";
            }
            
            if(numsData > 1)
            {
                int i;
                for (i = 0; i < numsData - 1; i++)
                {
                    cmdString += datas[i] + ",";
                }
                cmdString += datas[i];
                cmdString += "]";
            }
            else
            {
                // numsData = 1
                if (numsData > 0)
                {
                    cmdString += datas[0];
                    cmdString += "]";
                }
            }

            return cmdString;
        }
    }
}
