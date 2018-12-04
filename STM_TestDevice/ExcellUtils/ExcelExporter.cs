using STM_TestDevice.ExcellUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM_TestDevice.Exporter
{
    class ExcelExporter
    {
        public string fileName;

        Microsoft.Office.Interop.Excel.Application xlApp;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        

        public ExcelExporter(string fileName)
        {
            this.fileName = fileName;
        }

        public void Open()
        {
            if (FileUtils.IsOpen(fileName))
            {
                Close();
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

        public void Close()
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
                if(String.IsNullOrEmpty(text))
                {
                    text = "NULL content";
                }
                Clipboard.SetText(text);
                //xlApp.Visible = true;

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

                xlWorkSheet.Paste(CR, false);

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
