using Microsoft.Office.Interop.Excel;
using STM_TestDevice.ExcellUtils;
using STM_TestDevice.Exporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM_TestDevice.Devices
{
    class Battery
    {
        /* max battery */
        const int NUMS_BATTERY = 12;
        public static int gNumsRow = 100;

        #region command init parameter
        public const string CMD_INIT_PRE        = "!#";
        public const string CMD_END_COMMAND     = "\r\n";
        public const string CMD_SEPERATE        = "#";

        public const string CMD_INIT_PARA       = "0";
        public const string CMD_ASIGN_STT_BAT   = "1";
        public const string CMD_REQUEST_DATA    = "2";
        public const string CMD_RUN             = "3";
        public const string CMD_STOP            = "4";
        public const string CMD_PAUSE           = "5";

        #endregion command init parameter

        /// <summary>
        /// create report file with fomat Battery LOG
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static public bool CreateReportFile(string fileName)
        {
            List<String> lStr = new List<string>();
            lStr.Add("log_data");

            for(int i = 1; i <= NUMS_BATTERY; i++)
            {
                lStr.Add("Bat " + i);
            }
            
            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp = null;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;
                Microsoft.Office.Interop.Excel.Worksheet xlDataWorkSheet = null;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                for (int i = 0; i < lStr.Count; i++)
                {
                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add();
                    xlWorkSheet.Name = lStr[i];
                    xlWorkSheet.Move(System.Reflection.Missing.Value, xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);
                }
                Console.WriteLine("Delete default sheet: " + xlWorkBook.Worksheets[1].Name);
                xlWorkBook.Worksheets[1].Delete();

                xlDataWorkSheet = xlWorkBook.Worksheets[1];
                string fomular;
                int shiftCol;
                // assign fomular for each sheet
                for (int i = 2; i <= lStr.Count; i++)// sheet
                {
                    xlWorkSheet = xlWorkBook.Worksheets[i];
                    shiftCol = 9 * (i - 2);

                    // set header
                    xlWorkSheet.Cells[1, 2] = "temperature";
                    xlWorkSheet.Cells[1, 3] = "remain capacity";
                    xlWorkSheet.Cells[1, 4] = "vol of bat";
                    xlWorkSheet.Cells[1, 5] = "avg current";
                    xlWorkSheet.Cells[1, 6] = "bat percent";
                    xlWorkSheet.Cells[1, 7] = "state of bat";
                    xlWorkSheet.Cells[1, 8] = "Number Run";
                    xlWorkSheet.Cells[1, 9] = "res of bat";

                    // end of set header

                    // set fomular for each cell
                    for (int j = 2; j < gNumsRow; j++)// row
                    {
                        //                1                      2          3          4           5         6       7         8                         9                               
                        // 1.______________________________  temperature  remain   capacity   vol of bat    avg    current    bat     percent state of bat Number Run res of bat
                        // 2.[Sat Oct 27 09:35:35.512 2018] 	  38.6        610      3604       1661        31       10       10                       0

                        // net add shift for time log
                        fomular = getExtractString(xlDataWorkSheet.Name, j, 1);
                        xlWorkSheet.Cells[j, 1].Formula = fomular;

                        // add shift
                        for (int k = 2; k <= 9; k++)
                        {
                            fomular = getExtractString(xlDataWorkSheet.Name, j, shiftCol + k);
                            xlWorkSheet.Cells[j, k].Formula = fomular;
                        }
                    }

                    for (int h = 2; h <= 9; h++)
                    {
                        // add chart
                        Microsoft.Office.Interop.Excel.Range chartRange;
                        Microsoft.Office.Interop.Excel.ChartObjects xlCharts = (Microsoft.Office.Interop.Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                        Microsoft.Office.Interop.Excel.ChartObject myChart = (Microsoft.Office.Interop.Excel.ChartObject)xlCharts.Add(500, 300 + (350 + 100) * (h - 2), 1000, 350);
                        Microsoft.Office.Interop.Excel.Chart chartPage = myChart.Chart;

                        // TODO: hard code
                        chartRange = xlWorkSheet.Range[String.Format("A1:A{0},{1}1:{1}{0}", gNumsRow + "", (char)((int)'A' + h - 1))];
                        chartPage.SetSourceData(chartRange, misValue);
                        //chartPage.Name = (string)xlWorkSheet.Cells[1, h].Value;
                        chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;
                        chartPage.ChartTitle.Text = (string)xlWorkSheet.Cells[1, h].Value;


                    }
                    
                }
                //

                xlWorkBook.SaveAs(fileName);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// create chart for exsited file
        /// </summary>
        /// <param name="excelFileName"></param>
        /// <returns></returns>
        static public bool CreateChartForFile(string excelFileName)
        {
            List<String> lStr = new List<string>();
            lStr.Add("log_data");

            for (int i = 1; i <= NUMS_BATTERY; i++)
            {
                lStr.Add("Bat " + i);
            }

            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp = null;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(excelFileName);
                

                // assign fomular for each sheet
                for (int i = 2; i <= lStr.Count; i++)// sheet
                {
                    xlWorkSheet = xlWorkBook.Worksheets[i];

                    // delete old chart
                    ChartObjects objs = xlWorkSheet.ChartObjects();
                    int chartCount = objs.Count;
                    foreach(ChartObject obj in objs)
                    {
                        obj.Delete();
                    }

                    // end of set header
                    for (int h = 2; h <= 9; h++)
                    {
                        // add chart
                        Microsoft.Office.Interop.Excel.Range chartRange;
                        Microsoft.Office.Interop.Excel.ChartObjects xlCharts = (Microsoft.Office.Interop.Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                        Microsoft.Office.Interop.Excel.ChartObject myChart = (Microsoft.Office.Interop.Excel.ChartObject)xlCharts.Add(500, 300 + (350 + 100) * (h - 2), 1000, 350);
                        Microsoft.Office.Interop.Excel.Chart chartPage = myChart.Chart;

                        // TODO: hard code
                        chartRange = xlWorkSheet.Range[String.Format("A1:A{0},{1}1:{1}{0}", gNumsRow + "", (char)((int)'A' + h - 1))];
                        chartPage.SetSourceData(chartRange, misValue);
                        //chartPage.Name = (string)xlWorkSheet.Cells[1, h].Value;
                        chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;
                        chartPage.ChartTitle.Text = (string)xlWorkSheet.Cells[1, h].Value;
                    }
                }
                //

                xlWorkBook.Save();
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        static string getExtractString(string worksheetRoot, int rowSheet, int colRoot)
        {            
            string nameSheetModify = "'" + worksheetRoot + "'";
            string detail = "" + FileUtils.ColumnIndexToColumnLetter(colRoot) + rowSheet;            

            return String.Format(@"=IF(EXACT({0}!{1},""""),"""",{0}!{1})", nameSheetModify, detail);
        }
    }
}
