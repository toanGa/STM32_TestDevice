using Microsoft.Office.Interop.Excel;
using STM_TestDevice.Devices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
//using System.Windows.Forms;

namespace STM_TestDevice.ExcellUtils
{
    /// <summary>
    /// ver 0.0.1 - static position
    /// </summary>
    class DevicesParser
    {
        const string CMD_NAME = "CMD NAME";
        const string SETUP = "SETUP";
        public string mExcellFileName;
        
        Application xlApp;
        Workbook xlWorkBook;
        Worksheet xlWorkSheet;

        /// <summary>
        /// constructor with file name
        /// </summary>
        /// <param name="excellFileName"></param>
        public DevicesParser(string excellFileName)
        {
            this.mExcellFileName = excellFileName;
        }

        /// <summary>
        /// open Excell file for background
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            if(!IsOpen())
            {
                try
                {
                    xlApp = new Application();
                    xlWorkBook = xlApp.Workbooks.Open(mExcellFileName);
                    xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return true;
            }
            else
            {
                xlWorkBook = xlApp.Workbooks.Open(mExcellFileName);
                xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            }
            return true;
        }

        /// <summary>
        /// close excell application
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            if (IsOpen())
            {
                try
                {
                    xlWorkBook.Close();
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);

                    xlApp = null;
                }
                catch (Exception ex)
                {
                    //throw ex;
                }
                
                return true;
            }
            return true;
        }

        /// <summary>
        /// check excell app open or not
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            return (xlApp != null);
            //try
            //{
            //    Stream s = File.Open(excellFileName, FileMode.Open, FileAccess.Read, FileShare.None);

            //    s.Close();

            //    return false;
            //}
            //catch (Exception)
            //{
            //   return true;
            //}
        }       

        /// <summary>
        /// open file to view
        /// </summary>
        public void OpenUI()
        {
            if(!IsOpen())
            {
                try
                {
                    Open();
                    xlApp.Visible = true;
                }
                catch(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            else
            {
                xlWorkBook = xlApp.Workbooks.Open(mExcellFileName);
                xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlApp.Visible = true;
            }
        }

        /// <summary>
        /// get list define object from define file
        /// </summary>
        /// <returns></returns>
        public List<Device> ParseConfigDefine()
        {
            int rowStartCmd = -1;
            int cntRows;
            int cntCols;
            string tmpStr;

            cntRows = xlWorkSheet.Columns.Count;
            cntCols = xlWorkSheet.Rows.Count;

            for (int i = 0; i < cntRows; i++)
            {
                //tmpStr = (string)(xlWorkSheet.Cells[i + 1, 1] as Microsoft.Office.Interop.Excel.Range).Value;
                tmpStr = getCellValue(xlWorkSheet, i + 1, 1);
                if (tmpStr == CMD_NAME)
                {
                    rowStartCmd = i + 1;

                    break;
                }
            }

            // not found start cmdvalue
            if(rowStartCmd == -1)
            {
                return null;
            }

            List<Device> listDevice = new List<Device>();
            int rowParsCmd = rowStartCmd + 1;
            string currCmdName;
            string currCmdValue;
            
            while (rowParsCmd <= cntRows)
            {
                Device tmpDevice = new Device();

                List<string> listData = new List<string>();

                //currCmdName = (xlWorkSheet.Cells[rowParsCmd, 1] as Microsoft.Office.Interop.Excel.Range).Value.ToString();
                currCmdName = getCellValue(xlWorkSheet, rowParsCmd, 1);
                if(String.IsNullOrEmpty(currCmdName))
                {
                    break;
                }

                //currCmdValue = (xlWorkSheet.Cells[rowParsCmd, 2] as Microsoft.Office.Interop.Excel.Range).Value.ToString();
                currCmdValue = getCellValue(xlWorkSheet, rowParsCmd, 2);

                for (int i = 3; i <= cntCols; i++)
                {
                    //string tmpColVal = (xlWorkSheet.Cells[rowParsCmd, i] as Microsoft.Office.Interop.Excel.Range).Value.ToString();
                    string tmpColVal = getCellValue(xlWorkSheet, rowParsCmd, i);
                    if (String.IsNullOrEmpty(tmpColVal))
                    {
                        break;
                    }
                    listData.Add(tmpColVal);
                }

                tmpDevice.gCmdName = currCmdName;
                tmpDevice.gCmdValue = currCmdValue;
                tmpDevice.gDatas = listData;

                listDevice.Add(tmpDevice);

                rowParsCmd++;
            }

            return listDevice;
        }

        /// <summary>
        /// get specific for every command
        /// </summary>
        /// <param name="rootDevice"></param>
        /// <returns></returns>
        public List<Device> ParseSetupData(Device rootDevice)
        {
            int rowStartCmd = -1;
            int rowStartSetup = -1;
            int cntRows;
            int cntCols;
            string tmpStr;

            cntRows = xlWorkSheet.Columns.Count;
            cntCols = xlWorkSheet.Rows.Count;

            for (int i = 0; i < cntRows; i++)
            {
                //tmpStr = (string)(xlWorkSheet.Cells[i + 1, 1] as Microsoft.Office.Interop.Excel.Range).Value;
                tmpStr = getCellValue(xlWorkSheet, i + 1, 1);
                if (tmpStr == SETUP)
                {
                    rowStartSetup = i;
                    break;
                }
            }

            // if not found SETUP 
            if(rowStartSetup == -1)
            {
                return null;
            }

            for (int i = rowStartSetup + 1; i < cntRows; i++)
            {
                //tmpStr = (string)(xlWorkSheet.Cells[i + 1, 1] as Microsoft.Office.Interop.Excel.Range).Value;
                tmpStr = getCellValue(xlWorkSheet, i + 1, 1);
                if (tmpStr == rootDevice.gCmdName)
                {
                    rowStartCmd = i + 1;

                    break;
                }
            }

            // not found start cmdvalue
            if (rowStartCmd == -1)
            {
                return null;
            }

            List<Device> listDeviceSetup = new List<Device>();
            Device tmpDevice;
            int colCurr = 2;
            while(true)
            {
                int rowParsCmd = rowStartCmd + 1;
                int rowParsEnd;
                tmpStr = getCellValue(xlWorkSheet, rowParsCmd, colCurr);
                if(String.IsNullOrEmpty(tmpStr))
                {
                    break;
                }
                rowParsEnd = rowParsCmd + rootDevice.gDatas.Count;
                tmpDevice = new Device();
                for (int i = rowParsCmd; i < rowParsEnd; i++)
                {
                    tmpDevice.gCmdName = rootDevice.gCmdName;
                    tmpDevice.gCmdValue = rootDevice.gCmdValue;
                    tmpStr = getCellValue(xlWorkSheet, rowParsCmd, colCurr);

                    tmpDevice.gDatas.Add(tmpStr);
                    rowParsCmd++;
                }

                listDeviceSetup.Add(tmpDevice);
                colCurr++;
            }

            return listDeviceSetup;
        }


        private string getCellValue(Worksheet Sheet, int Row, int Column)
        {
            string cellValue = "";
            if (Sheet.Cells[Row, Column].Value != null)
            {
                cellValue = Sheet.Cells[Row, Column].Value.ToString();
            }
            
            return cellValue;
        }
    }
}
