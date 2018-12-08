using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        /// <summary>
        /// convert index colum to string colum in excell
        /// </summary>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public static string ColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (int)((div - mod) / 26);
            }
            return colLetter;
        }

        /// <summary>
        /// get full path of input path
        /// </summary>
        /// <param name="inputPath"></param>
        /// <returns></returns>
        public static string GetFullPath(string inputPath)
        {
            if(inputPath.Contains(@"\") || inputPath.Contains(@"/"))
            {
                return inputPath;
            }
            else
            {
                return Application.StartupPath + @"\" + inputPath;
            }
        }
    }
}
