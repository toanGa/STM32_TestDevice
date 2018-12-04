using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM_TestDevice.Devices
{
    class Battery
    {
        #region command init parameter
        public const string CMD_INIT_PRE        = "!#";
        public const string CMD_SEPERATE        = "#";

        public const string CMD_INIT_PARA       = "0";
        public const string CMD_ASIGN_STT_BAT   = "1";
        public const string CMD_REQUEST_DATA    = "2";
        public const string CMD_RUN             = "3";
        public const string CMD_STOP            = "4";
        public const string CMD_PAUSE           = "5";

        #endregion command init parameter

    }
}
