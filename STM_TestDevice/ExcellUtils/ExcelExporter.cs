using Microsoft.Office.Interop.Excel;
using STM_TestDevice.ExcellUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM_TestDevice.Exporter
{
    class ExcelExporter : Form
    {
        public string fileName;

        Microsoft.Office.Interop.Excel.Application xlApp;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        

        public ExcelExporter(string fileName)
        {
            this.fileName = fileName;
        }

        public void OpenExcelFile()
        {
            if (FileUtils.IsOpen(fileName))
            {
                CloseExcelFile();
            }
            try
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                object misValue = System.Reflection.Missing.Value;
                //xlWorkBook = xlApp.Workbooks.Add(misValue);
                //xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            }
            catch(Exception ex)
            {

            }
        }

        public void CloseExcelFile()
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;
                //xlWorkBook.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Save();
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static public bool CreatReportFile(string fileName, string[] nameSheet)
        {
            if(nameSheet.Length == 0)
            {
                return false;
            }

            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp = null;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                for (int i = 0; i < nameSheet.Length; i++)
                {
                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add();
                    xlWorkSheet.Name = nameSheet[i];
                    xlWorkSheet.Move(System.Reflection.Missing.Value, xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);
                }
                Console.WriteLine("Delete default sheet: " + xlWorkBook.Worksheets[1].Name);
                xlWorkBook.Worksheets[1].Delete();

                xlWorkBook.SaveAs(fileName);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// re modify the chart with numbers of row changed
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public bool ModifyChart(int numRows)
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;

                // assign fomular for each sheet
                for (int i = 2; i <= xlWorkBook.Worksheets.Count; i++)// sheet
                {
                    xlWorkSheet = xlWorkBook.Worksheets[i];

                    // delete old chart
                    ChartObjects objs = xlWorkSheet.ChartObjects();
                    int chartCount = objs.Count;


                    for(int j = 2; j <= chartCount; j++)
                    {
                        ChartObject currChartObj = objs.Item(j - 1);
                        Microsoft.Office.Interop.Excel.Range chartRange;
                        Microsoft.Office.Interop.Excel.Chart chartPage = currChartObj.Chart;

                        chartRange = xlWorkSheet.Range[String.Format("A1:A{0},{1}1:{1}{0}", numRows + "", (char)((int)'A' + j - 1))];
                        chartPage.SetSourceData(chartRange, misValue);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Auto open and close file
        /// </summary>
        /// <returns></returns>
        public string ExportCSV()
        {
            try
            {
                if (File.Exists(fileName))
                {
                    var result = MessageBox.Show("File existed: " + fileName + ". Do you want to delete this file?", "Warning!", MessageBoxButtons.YesNo);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            File.Delete(fileName);
                            break;
                        case DialogResult.No:
                            // Reuturn if user doesn't want to delete file
                            return "Cancel export";
                        default:
                            break;
                    }
                }

                xlApp = new Microsoft.Office.Interop.Excel.Application();

                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return "Excell was NOT installed";
                }

                object misValue = System.Reflection.Missing.Value;

                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Cells[1, 1] = "ID";
                xlWorkSheet.Cells[1, 2] = "Name";
                xlWorkSheet.Cells[2, 1] = "1";
                xlWorkSheet.Cells[2, 2] = "One";
                xlWorkSheet.Cells[3, 1] = "2";
                xlWorkSheet.Cells[3, 2] = "Two";

                xlWorkBook.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

                return "Export file was created in " + fileName;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }


        public bool PasteText(string text, int sheetNum, int row, int col)
        {
            //xlApp = new Microsoft.Office.Interop.Excel.Application();
            
            // check if file existed
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Auto create file");
                object misValue = System.Reflection.Missing.Value;
                xlApp.Workbooks.Add(misValue).SaveAs(fileName);
            }

            try
            {
                //Microsoft.Office.Interop.Excel.Worksheet preActiveSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(sheetNum);

                if (String.IsNullOrEmpty(text))
                {
                    text = "NULL content";
                }
               
                xlApp.Visible = true;

                //~~> Add a new a workbook
                //xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkBook = xlApp.Workbooks.Open(fileName);

                //~~> Set Sheet 1 as the sheet you want to work with
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(sheetNum);
                xlWorkSheet.Cells.ClearContents();
                xlWorkSheet.Select();
                //~~> Set your range
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[col, row];

                CR.Select();

                //System.Threading.Thread.CurrentThread.TrySetApartmentState(System.Threading.ApartmentState.STA);

                if (InvokeRequired)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        Clipboard.SetText(text);
                    });
                }
                else
                {
                    Clipboard.SetText(text);
                }

                xlWorkSheet.Paste(CR, false);

                // modify chart
                int numsEnter = Regex.Matches(text, "\r\n").Count;

                ModifyChart(numsEnter);

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

    }
}
