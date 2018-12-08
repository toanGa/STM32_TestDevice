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
        public string gCmdName;
        public string gCmdValue;
        public List<string> gDatas = new List<string>();

        public virtual string getHeaderSend(string pre, string seprate)
        {
            string headerString = pre + gCmdValue + seprate;
            return headerString;
        }

        public virtual string getCmdSend()
        {
            int numsData = gDatas.Count;

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
                    cmdString += gDatas[i] + ",";
                }
                cmdString += gDatas[i];
                cmdString += "]";
            }
            else
            {
                // numsData = 1
                if (numsData > 0)
                {
                    cmdString += gDatas[0];
                    cmdString += "]";
                }
            }

            return cmdString;
        }
    }
}
