using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM_TestDevice.ExcellUtils
{
    class FileUtils
    {
        public static bool IsOpen(string fileName)
        {
            try
            {
                Stream s = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None);

                s.Close();

                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
