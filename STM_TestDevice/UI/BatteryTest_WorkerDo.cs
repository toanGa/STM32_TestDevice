using STM_TestDevice.Exporter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM_TestDevice.UI
{
    /// <summary>
    /// define for background worker thread
    /// </summary>
    public partial class BatteryTest
    {
        /// <summary>
        /// background save text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSaveBackgroundWork(object sender, DoWorkEventArgs e)
        {
            string saveString;
            bool isValidSaveString;

            // waite for truly use click
            mOpenFileSaveThreadEvent.Reset();
            mOpenFileSaveThreadEvent.WaitOne();

            while (true)
            {
                mFileSaveEvent.Reset();
                mFileSaveEvent.WaitOne();

                lock(mtLogString)
                {
                    isValidSaveString = !String.IsNullOrEmpty(mtLogString);
                }

                if (isValidSaveString)
                {
                    if (InvokeRequired)
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            lock (mtLogString)
                            {
                                saveString = mtLogString;
                            }

                            lock (mtWriteBufferFile)
                            {
                                if (mtWriteBufferFile.BaseStream != null)
                                {
                                    saveString = saveString.Replace("\r\n", "\r\n" + "[" + DateTime.Now + "]");
                                    mtWriteBufferFile.Write(saveString);
                                    lock (mtLogString)
                                    {
                                        mtLogString = "";
                                    }
                                }
                            }
                        });
                    }
                    else
                    {
                        lock (mtLogString)
                        {
                            saveString = mtLogString;
                        }
                        lock (mtWriteBufferFile)
                        {
                            if (mtWriteBufferFile.BaseStream != null)
                            {
                                saveString = saveString.Replace("\r\n", "\r\n" + DateTime.Now);
                                mtWriteBufferFile.Write(saveString);
                                lock (mtLogString)
                                {
                                    mtLogString = "";
                                }
                            }
                        }

                        lock (mtLogString)
                        {
                            mtLogString = "";
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Background for paste text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasteExcellBackgroundWork(object sender, DoWorkEventArgs e)
        {
            // waite for user trully open
            mOpenPasteExcellThredEvent.Reset();
            mOpenPasteExcellThredEvent.WaitOne();

            // open excell exporter in background
            mtExcelExporter = new ExcelExporter(getPathReportFile());
            mtExcelExporter.OpenExcelFile();

            while (true)
            {
                mPasteExcelEvent.Reset();
                mPasteExcelEvent.WaitOne();

                try
                {
                    /// try to read all text
                    /// if read false -> streamwrite is running -> close
                    string saveString = File.ReadAllText(FILE_BUFFER);
                    int numsEnter = Regex.Matches(saveString, "\r\n").Count;

                    // todo: need optimaze
                    //lock(mtExcelExporter)
                    //{
                    //    mtExcelExporter.PasteText(saveString, 1, 1, 1);
                    //}


                    if (InvokeRequired)
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            lock (mtExcelExporter)
                            {
                                mtExcelExporter.PasteText(saveString, 1, 1, 1);
                            }
                        });
                    }
                    else
                    {

                        lock (mtExcelExporter)
                        {
                            mtExcelExporter.PasteText(saveString, 1, 1, 1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    lock (mtWriteBufferFile)
                    {
                        mtWriteBufferFile.Close();
                    }
                    
                    string saveString = File.ReadAllText(FILE_BUFFER);

                    // todo: need optimaze
                    //lock (mtExcelExporter)
                    //{
                    //    mtExcelExporter.PasteText(saveString, 1, 1, 1);
                    //}

                    if (InvokeRequired)
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            lock (mtExcelExporter)
                            {
                                mtExcelExporter.PasteText(saveString, 1, 1, 1);
                            }
                        });
                    }
                    else
                    {

                        lock (mtExcelExporter)
                        {
                            mtExcelExporter.PasteText(saveString, 1, 1, 1);
                        }
                    }
                }

                lock (mtWriteBufferFile)
                {
                    mtWriteBufferFile = new StreamWriter(FILE_BUFFER, true);
                }
            }
        }

        private void WaitReportComplete(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
