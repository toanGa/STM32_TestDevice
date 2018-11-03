using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data;
using System.Windows.Forms;

namespace ELABO.Utils
{
    public class Util
    {
        public const int NO_WORK = -999;
        public DateTime CURR_TIME { get { return DateTime.Now; } }

        public const double ONE_SEC = 0.00001157407678;
        public const double ONE_MIN = (ONE_SEC * 60);
        public const double ONE_HOR = (ONE_SEC * 60 * 60);
        public const double ONE_mSEC = (ONE_SEC / 1000);
        public const double ONE_uSEC = (ONE_SEC / 1000000);

        public static System.IO.Ports.Parity ParityConvert(int par)
        {
            switch (par)
            {
                case 0:
                    return System.IO.Ports.Parity.None;
                case 1:
                    return System.IO.Ports.Parity.Odd;
                case 2:
                    return System.IO.Ports.Parity.Even;
                case 3:
                    return System.IO.Ports.Parity.Mark;
                case 4:
                    return System.IO.Ports.Parity.Space;
                default:
                    return System.IO.Ports.Parity.None;
            }
        }
        public static System.IO.Ports.StopBits StopbitConvert(int stopbit)
        {
            switch (stopbit)
            {
                case 0:
                    return System.IO.Ports.StopBits.One;
                case 1:
                    return System.IO.Ports.StopBits.Two;
                case 2:
                    return System.IO.Ports.StopBits.OnePointFive;
                default:
                    return System.IO.Ports.StopBits.None;
            }
        }

        public static int ByteToInt(byte b)
        {
            return Convert.ToInt32(b);
        }

        public static byte IntToByte(int i)
        {
            return Convert.ToByte(i);
        }

        public static byte IntToByte(string i)
        {
            return Convert.ToByte(i);
        }

        //convert a string to a byte array        
        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }
        //convert a byte array to a string

        public static string ByteArrayToStrUTF8(byte[] dBytes)
        {
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            return enc.GetString(dBytes);
        }

        //convert a byte array to a string

        public static string ByteArrayToStrBinary(byte[] dBytes)
        {
            string buf = string.Empty;
            for (int i = 0; i < dBytes.Length; i++)
            {
                string tem = Convert.ToString(dBytes[i], 2);
                if (tem.Length < 8)
                {
                    //padding 0 at head
                    for (int j = 0; j < (8 - tem.Length); j++)
                    {
                        tem = "0" + tem;
                    }
                }
                buf += (tem);
            }
            return buf;
        }
        
        //---------------------------------------------------------------------------

        public static void ProgramDataSave(string fileName, Type zclass, object dataObj)
        {
            XmlSerializer mySerializer;
            try
            {
                string folder = Path.GetDirectoryName(fileName);
                // Check path
                if (folder != string.Empty && !Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                mySerializer = new XmlSerializer(zclass);
                // Writing the file requires a TextWriter.
                TextWriter writer = new StreamWriter(fileName);

                // Serialize the class, and close the TextWriter.
                mySerializer.Serialize(writer, dataObj);
                writer.Close();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public static object ProgramDataLoad(string filename, Type zclass)
        {
            object ret = null;

            XmlSerializer serializer = new XmlSerializer(zclass);
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open);
                ret = serializer.Deserialize(fs);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

            return ret;
        }
        //---------------------------------------------------------------------------

        public static bool IsOKForDecimalTextBox(char theCharacter, TextBox theTextBox)
        {
            // Only allow control characters, digits, plus and minus signs.
            // Only allow ONE plus sign.
            // Only allow ONE minus sign.
            // Only allow the plus or minus sign as the FIRST character.
            // Only allow ONE decimal point.
            // Do NOT allow decimal point or digits BEFORE any plus or minus sign.

            if (
                !char.IsControl(theCharacter)
                && !char.IsDigit(theCharacter)
                && (theCharacter != '.')
                && (theCharacter != '-')
                && (theCharacter != '+')
            )
            {
                // Then it is NOT a character we want allowed in the text box.
                return false;
            }



            // Only allow one decimal point.
            if (theCharacter == '.'
                && theTextBox.Text.IndexOf('.') > -1)
            {
                // Then there is already a decimal point in the text box.
                return false;
            }

            // Only allow one minus sign.
            if (theCharacter == '-'
                && theTextBox.Text.IndexOf('-') > -1)
            {
                // Then there is already a minus sign in the text box.
                return false;
            }

            // Only allow one plus sign.
            if (theCharacter == '+'
                && theTextBox.Text.IndexOf('+') > -1)
            {
                // Then there is already a plus sign in the text box.
                return false;
            }

            // Only allow one plus sign OR minus sign, but not both.
            if (
                (
                    (theCharacter == '-')
                    || (theCharacter == '+')
                )
                &&
                (
                    (theTextBox.Text.IndexOf('-') > -1)
                    ||
                    (theTextBox.Text.IndexOf('+') > -1)
                )
                )
            {
                // Then the user is trying to enter a plus or minus sign and
                // there is ALREADY a plus or minus sign in the text box.
                return false;
            }

            // Only allow a minus or plus sign at the first character position.
            if (
                (
                    (theCharacter == '-')
                    || (theCharacter == '+')
                )
                && theTextBox.SelectionStart != 0
                )
            {
                // Then the user is trying to enter a minus or plus sign at some position 
                // OTHER than the first character position in the text box.
                return false;
            }

            // Only allow digits and decimal point AFTER any existing plus or minus sign
            if (
                    (
                // Is digit or decimal point
                        char.IsDigit(theCharacter)
                        ||
                        (theCharacter == '.')
                    )
                    &&
                    (
                // A plus or minus sign EXISTS
                        (theTextBox.Text.IndexOf('-') > -1)
                        ||
                        (theTextBox.Text.IndexOf('+') > -1)
                    )
                    &&
                // Attempting to put the character at the beginning of the field.
                        theTextBox.SelectionStart == 0
                )
            {
                // Then the user is trying to enter a digit or decimal point in front of a minus or plus sign.
                return false;
            }

            // Otherwise the character is perfectly fine for a decimal value and the character
            // may indeed be placed at the current insertion position.
            return true;
        }

        public static bool Create_Dir(string Dir)
        {
            string sStr = string.Empty;

            if (!Directory.Exists(Dir))
            {
                for (int i = 0; i < Dir.Length; i++)
                {
                    sStr = sStr + Dir.Substring(i, 1);
                    if (Dir.Substring(i, 1) == "\\" || i == Dir.Length - 1)
                    {
                        if (Directory.Exists(sStr)) continue;
                        try
                        {
                            Directory.CreateDirectory(sStr);
                        }
                        catch
                        {
                            return false;
                        }

                    }
                }
            }

            return true;
        }
        //---------------------------------------------------------------------------

        public static bool ClearDirectory(string directory)
        {
            return false;
        }
        //---------------------------------------------------------------------------

        public static List<string> GetList_FileName(string SourceDir, string Exetantion)
        {

            List<string> ListR = new List<string>();
            
            if(!Directory.Exists(SourceDir))
                Directory.CreateDirectory(SourceDir);

            string[] fileArray = Directory.GetFiles(SourceDir, Exetantion);
            foreach (string aa in fileArray)
            {
                ListR.Add(Path.GetFileNameWithoutExtension(aa));
            }
            return ListR;

        }
        //---------------------------------------------------------------------------

        public static void Delay(uint dwCount, ref bool bBreak)
        {
            uint curCount = 0;

            while (true)
            {
                if (curCount >= dwCount) break;

                if (bBreak)
                {
                    break;
                }
                Thread.Sleep(10);
                curCount += 10;
            }
        }

        //---------------------------------------------------------------------------

        public static string EraseFileExt(string sFileName)
        {
            char cChar;

            for (int i = sFileName.Length - 1; i >= 0; i--)
            {
                cChar = (sFileName.Substring(i, 1).ToArray()[0]);
                if (cChar == '.') return sFileName.Substring(0, i - 1);
            }

            return sFileName;
        }
        //---------------------------------------------------------------------------

        public static bool IsHexString(string sHex)
        {
            char cChar, cPreChar = '0';

            sHex = sHex.ToUpper();
            if (sHex.Length >= 2)
            {
                if (sHex.Substring(0, 2) != "0X") return false;
            }
            else
            {
                return false;
            }

            for (int i = 0; i < sHex.Length; i++)
            {
                cChar = (sHex.Substring(i, 1).ToArray()[0]);
                if ((cChar >= 'A' && cChar <= 'F') || (cChar >= '0' && cChar <= '9') ||
                    (cChar == 'X' && i == 1 && cPreChar == '0'))
                {
                    cPreChar = cChar;
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        //---------------------------------------------------------------------------

        public static bool IsNumberString(string sSrc)
        {
            char cOneChar;

            if (IsHexString(sSrc)) return true;
            for (int i = 0; i < sSrc.Length; i++)
            {
                cOneChar = (sSrc.Substring(i, 1).ToArray()[0]);
                if (cOneChar == '-' || cOneChar == '+' || cOneChar == 'E' || cOneChar == 'e' || cOneChar == '.') continue;
                if (cOneChar >= '0' && cOneChar <= '9') continue;
                return false;
            }

            return true;
        }
        //---------------------------------------------------------------------------

        public static string GetFloatStr(string sSrc)
        {
            char cOneChar;
            string sStr = string.Empty;
            bool bDot = false;

            for (int i = 0; i < sSrc.Length; i++)
            {
                cOneChar = (sSrc.Substring(i, 1).ToArray()[0]);
                if (cOneChar == '.')
                {
                    if (bDot) continue;
                    bDot = true;
                }
                if (cOneChar >= '0' && cOneChar <= '9' || cOneChar == '.' || cOneChar == '-' || cOneChar == 'E')
                {
                    sStr = sStr + cOneChar;
                }
            }
            if (sStr == "") sStr = "0";

            return sStr;
        }
        //---------------------------------------------------------------------------

        public static string GetHexStr(string sHex, string sEmptyStr)
        {
            char cChar, cPreChar = '0';
            bool bHex = false;
            string sRet = string.Empty;

            sHex = sHex.ToUpper();

            if (sHex.Length >= 2)
            {
                if (sHex.Substring(0, 2) == "0X") bHex = true;
            }

            for (int i = 0; i < sHex.Length; i++)
            {
                cChar = (sHex.Substring(i, 1).ToArray()[0]);
                if ((cChar >= 'A' && cChar <= 'F') || (cChar >= '0' && cChar <= '9') ||
                    (cChar == 'X' && i == 1 && cPreChar == '0'))
                {
                    sRet = sRet + cChar;
                }
                if ((cChar >= 'A' && cChar <= 'F') || cChar == 'X')
                {
                    bHex = true;
                }
                cPreChar = cChar;

            }
            if (sRet.Substring(0, 2) != "0X" && bHex) sRet = "0X" + sRet;
            if (sRet == "0X") sRet = "0X0";
            if (sRet == "") sRet = sEmptyStr;

            return sRet;
        }
        //---------------------------------------------------------------------------

        public static string GetNumStr(string sNum, string sEmptyStr)
        {
            char cChar;
            string sRet = string.Empty;

            for (int i = 0; i < sNum.Length; i++)
            {
                cChar = (sNum.Substring(i, 1).ToArray()[0]);
                if (cChar >= '0' && cChar <= '9')
                {
                    sRet = sRet + cChar;
                }
            }
            if (sRet == "") sRet = sEmptyStr;

            return sRet;
        }
        //---------------------------------------------------------------------------

        public static int CountDIV(string sSource, char cDiv)
        {
            string sStr = string.Empty;
            char cTrim;
            int nCount = 0;

            for (int i = 0; i < sSource.Length; i++)
            {
                cTrim = (sSource.Substring(i, 1).ToArray()[0]);
                if (cTrim == cDiv)
                {
                    nCount++;
                    continue;
                }
            }

            return nCount;
        }
        //---------------------------------------------------------------------------

        public static int StrToWordArray(string sSource, char cDiv, ref ushort[] wData)
        {
            string sStr = string.Empty;
            char cTrim;
            int nCount = 0;

            for (int i = 0; i < sSource.Length; i++)
            {
                cTrim = (sSource.Substring(i, 1).ToArray()[0]);
                if (cTrim == ' ') continue;
                if (cTrim == cDiv)
                {
                    if (sStr != string.Empty)
                    {
                        wData[nCount] = Convert.ToUInt16(sStr);
                        nCount++;
                        sStr = "";
                    }
                    continue;
                }
                sStr = sStr + cTrim;
            }
            if (sStr != "")
            {
                wData[nCount] = Convert.ToUInt16(sStr);
                nCount++;
            }

            return nCount;
        }
        //---------------------------------------------------------------------------

        public static bool GetTmSec(string sTimeStr, ref double dSec)
        {
            string sStr = string.Empty;
            char cChar;

            sTimeStr = sTimeStr.Trim();
            sTimeStr = sTimeStr.ToUpper();
            dSec = 0;

            for (int i = 0; i < sTimeStr.Length; i++)
            {
                cChar = (sTimeStr.Substring(i, 1).ToArray()[0]);
                if (cChar == ',') continue;
                if (cChar >= '0' && cChar <= '9')
                {
                    sStr = sStr + cChar;
                    continue;
                }
                switch (cChar)
                {
                    case 'D':
                        dSec = Convert.ToDouble(sStr) * 60 * 60 * 24;
                        break;
                    case 'H':
                        dSec = Convert.ToDouble(sStr) * 60 * 60;
                        break;
                    case 'M':
                        dSec = Convert.ToDouble(sStr) * 60;
                        break;
                    case 'S':
                        dSec = Convert.ToDouble(sStr);
                        break;
                    default:
                        return false;
                }
                sStr = "";
            }
            dSec = dSec * ONE_SEC;

            return true;
        }
        //---------------------------------------------------------------------------

        public static string FillHeaderValue(int nVal, char cFillChar, int nLen)
        {
            string sRet = string.Empty;
            string sSrc = nVal.ToString();
            int nSrcLen = sSrc.Length;

            if (nVal < 0) return "";
            if (nSrcLen <= 0) return sSrc;

            sRet = StringOfChar(cFillChar, nLen - nSrcLen) + sSrc;

            return sRet;
        }

        public static string StringOfChar(char cFillChar, int count)
        {
            if (count <= 0)
            {
                return string.Empty;
            }
            char[] cha = new char[count];

            for (int i = 0; i < count; i++)
            {
                cha[i] = cFillChar;
            }

            return new string(cha);
        }

        //---------------------------------------------------------------------------

        public static bool GET_EraseSpace(string sSrc, List<string> slList)
        {
            char cOneChar;
            string sStr = string.Empty;

            for (int i = 0; i < sSrc.Length; i++)
            {
                cOneChar = (sSrc.Substring(i, 1).ToArray()[0]);
                if (cOneChar == '\n') continue;
                if (cOneChar == '\t' || cOneChar == '\r')
                {
                    slList.Add(sStr);
                    sStr = "";
                    continue;
                }
                sStr = sStr + cOneChar;
            }

            return true;
        }
        //---------------------------------------------------------------------------

        public static string EraseSpecialChar(string sSrc)
        {
            char cOneChar;
            string sStr = string.Empty;

            for (int i = 0; i < sSrc.Length; i++)
            {
                cOneChar = (sSrc.Substring(i, 1).ToArray()[0]);
                if (cOneChar == '\n' || cOneChar == '\r') continue;
                sStr = sStr + cOneChar;
            }

            return sStr;
        }
        //---------------------------------------------------------------------------

        public static string LeftStr(string sSrc, int nCount)
        {
            if (nCount > sSrc.Length) nCount = sSrc.Length;

            return sSrc.Substring(0, nCount);
        }
        //---------------------------------------------------------------------------

        public static string RightStr(string sSrc, int nCount)
        {
            int nLen = sSrc.Length;

            if (nLen - nCount < 0) nCount = nLen;

            return sSrc.Substring(nLen - nCount, nCount);
        }
        //---------------------------------------------------------------------------

        public static int GetBitIndex(int nValue)
        {
            int nCount = 0;

            // ex) 63   = [64] 32, 16, 8, 4, 2, 1
            nValue++;
            while (true)
            {
                nValue = nValue / 2;
                nCount++;
                if (nValue <= 1) return nCount;
            }
        }
        //---------------------------------------------------------------------------

        public static double GetCommaValue(string sData, int nGetIndex)
        {
            char cOneChar;
            string sStr = string.Empty;
            int nCommaCount = 0;
            double dValue;

            sData = sData + ",";
            for (int i = 0; i < sData.Length; i++)
            {
                cOneChar = (sData.Substring(i, 1).ToArray()[0]);
                if (cOneChar == ',')
                {
                    if (nGetIndex == nCommaCount)
                    {
                        dValue = Convert.ToDouble(sStr);
                        return dValue;
                    }
                    nCommaCount++;
                    sStr = "";
                    continue;
                }
                sStr = sStr + cOneChar;
            }

            return NO_WORK;
        }
        //---------------------------------------------------------------------------

        public static string GetStartEndStrBaseExtractionString(string sSrc, char cStartChar, char cEndChar)
        {
            char cOneChar;
            string sStr = string.Empty;
            bool bFindStartChar = false;

            for (int i = 0; i < sSrc.Length; i++)
            {
                cOneChar = (sSrc.Substring(i, 1).ToArray()[0]);
                if (cOneChar == cStartChar && !bFindStartChar)
                {
                    bFindStartChar = true;
                    continue;
                }
                if (cOneChar == cStartChar && !bFindStartChar)
                    if (cOneChar == cEndChar && bFindStartChar) return sStr;
                if (bFindStartChar)
                {
                    sStr = sStr + cOneChar;
                }
            }

            return sStr;
        }
        //---------------------------------------------------------------------------
        //###########################################################################
        //##################          일반함수    ###################################
        //###########################################################################
        public static int Adjust(double Color, double Factor)
        {
            double Gamma = 0.80;
            int IntensityMax = 255;

            if (Color == 0.0)
                return 0;
            else
                return (int)(IntensityMax * Math.Pow(Color * Factor, Gamma));
        }
        //---------------------------------------------------------------------------

        public static UInt32 WavelengthToRGB(double Wavelength)
        {
            double Red = 0.0;
            double Green = 0.0;
            double Blue = 0.0;
            double factor = 0.0;

            int R;
            int G;
            int B;
            if (380 <= Wavelength && Wavelength <= 439)
            {
                Red = -(Wavelength - 440) / (440 - 380);
                Green = 0.0;
                Blue = 1.0;
            }
            else if (439 < Wavelength && Wavelength <= 489)
            {
                Red = 0.0;
                Green = (Wavelength - 439) / (490 - 439);
                Blue = 1.0;
            }
            else if (489 < Wavelength && Wavelength <= 509)
            {
                Red = 0.0;
                Green = 1.0;
                Blue = -(Wavelength - 510) / (510 - 489);
            }
            else if (509 < Wavelength && Wavelength <= 579)
            {
                Red = (Wavelength - 509) / (580 - 509);
                Green = 1.0;
                Blue = 0.0;
            }
            else if (579 < Wavelength && Wavelength <= 644)
            {
                Red = 1.0;
                Green = -(Wavelength - 645) / (645 - 579);
                Blue = 0.0;
            }
            else if (644 < Wavelength && Wavelength <= 780)
            {
                Red = 1.0;
                Green = 0.0;
                Blue = 0.0;
            }
            else
            {
                Red = 0.0;
                Green = 0.0;
                Blue = 0.0;
            }
            if (380 <= Wavelength && Wavelength <= 419)
                factor = 0.3 + 0.7 * (Wavelength - 380) / (420 - 380);
            else if (419 < Wavelength && Wavelength <= 700)
                factor = 1.0;
            else if (700 < Wavelength && Wavelength <= 780)
                factor = 0.3 + 0.7 * (780 - Wavelength) / (780 - 700);
            else
                factor = 0.0;

            R = Adjust(Red, factor);
            G = Adjust(Green, factor);
            B = Adjust(Blue, factor);

            return ((UInt32)(R + G * 0x100 + B * 0x10000));
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        // CIE 좌표계의 값을 상호변경하는 함수
        // int type : 변경형태 설정
        //            X Y
        //            ↑↑
        //       source destination
        //            3 : 31, 6 : 60, 7 : 76
        //---------------------------------------------------------------------------
        public static bool ChangeCIEValue(int type, double x, double y, ref double cx, ref double cy)
        {
            //     if ( cx == NULL || cy == NULL )
            //         return false;
            // 
            switch (type)
            {
                case 36:
                    cx = 4 * x / (3 + 12 * y - 2 * x);
                    cy = 2 * (9 * y / (3 + 12 * y - 2 * x)) / 3;
                    break;
                case 37:
                    cx = 4 * x / (3 + 12 * y - 2 * x);
                    cy = 9 * y / (3 + 12 * y - 2 * x);
                    break;
                case 63:
                    cx = 3 * x / (2 * x - 8 * y + 4);
                    cy = y / (x - 4 * y + 2);
                    break;
                case 67:
                    // 이상해서 수정 2005. 5.3 Kim Hyeong Deok
                    //*cx = 3*x / (2.*x - 8*y + 4);
                    //*cy = 3*y / 2.;
                    cx = x;
                    cy = 3 * y / 2;
                    break;
                case 73:
                    cx = (27 * x / 4) / (9 * x / 2 - 12 * y + 9);
                    cy = 3 * y / (9 * x / 2 - 12 * y + 9);
                    break;
                case 76:
                    cx = x;
                    cy = 2 * y / 3;
                    break;
                default:
                    return false;
            }

            return true;
        }
        //---------------------------------------------------------------------------

        public static int FindMaxValue(int nCount, double[] dData, ref double dFindValue, int nStart)
        {
            double dMax;
            int nIndex = nStart;

            dMax = dData[nIndex];
            for (int i = nStart; i < nCount; i++)
            {
                if (dMax < dData[i])
                {
                    dMax = dData[i];
                    nIndex = i;
                }
            }
            /*if (dFindValue != null)*/
            dFindValue = dMax;

            return nIndex;
        }
        //---------------------------------------------------------------------------

        public static int FindMinValue(int nCount, double[] dData, ref double dFindValue, int nStart)
        {
            double dMin;
            int nIndex = nStart;

            dMin = dData[0];
            for (int i = nStart; i < nCount; i++)
            {
                if (dMin > dData[i])
                {
                    dMin = dData[i];
                    nIndex = i;
                }
            }
            /*if (dFindValue != null)*/
            dFindValue = dMin;

            return nIndex;
        }
        //---------------------------------------------------------------------------

        public static int FindMaxValue(int nCount, int[] nData, ref int nFindValue, int nStart)
        {
            int nMax;
            int nIndex = nStart;

            nMax = nData[nIndex];
            for (int i = nStart; i < nCount; i++)
            {
                if (nMax < nData[i])
                {
                    nMax = nData[i];
                    nIndex = i;
                }
            }
            /*if (nFindValue != null)*/
            nFindValue = nMax;

            return nIndex;
        }
        //---------------------------------------------------------------------------

        public static int FindMinValue(int nCount, int[] nData, ref int nFindValue, int nStart)
        {
            int nMin;
            int nIndex = nStart;

            nMin = nData[nIndex];
            for (int i = nStart; i < nCount; i++)
            {
                if (nMin > nData[i])
                {
                    nMin = nData[i];
                    nIndex = i;
                }
            }
            /*if (nFindValue != null)*/
            nFindValue = nMin;

            return nIndex;
        }
        //---------------------------------------------------------------------------

        public static byte GetCheckSum(byte[] sendCmd, int length)
        {
            byte chksum = 0;

            for (int i = 0; i < length; i++)
            {
                chksum += sendCmd[i];
            }

            return chksum;
        }
        //---------------------------------------------------------------------------

        public static double Remainder(double op1, double op2)
        {
            int temp = 0;

            op1 = Math.Abs(op1);
            op2 = Math.Abs(op2);
            if (op1 > op2)
            {
                temp = (int)(op1 / op2);
                op1 -= (double)temp * op2;
            }

            return op1;
        }

        //---------------------------------------------------------------------------
        public static void InitGridView(System.Windows.Forms.DataGridView dataGrid, int ColNum, int RowNum, string[] sColHeader, string[] sRowHeader)
        {
            dataGrid.RowHeadersVisible = false;


            System.Data.DataTable table = new System.Data.DataTable();
            // Add column
            for (int i = 0; i < ColNum; i++)
            {
                if (i >= sColHeader.Length)
                {
                    table.Columns.Add("Unknown " + i);
                }
                else
                {
                    table.Columns.Add(sColHeader[i]);
                }
            }


            //Init row headers
            for (int i = 0; i < RowNum; i++)
            {
                DataRow dr = table.NewRow();
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    dr[j] = "0";
                }
                table.Rows.Add(dr);
            }

            dataGrid.DataSource = table;
            dataGrid.Columns[0].ReadOnly = true;
            dataGrid.Columns[0].Frozen = true;

            for (int i = 0; i < ColNum; i++)
            {
                dataGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            // add header
            if (sRowHeader != null)
            {
                int idx = 0;
                foreach (System.Windows.Forms.DataGridViewRow row in dataGrid.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (idx >= sRowHeader.Length)
                    {
                        row.HeaderCell.Value = "Unknown";
                    }
                    else
                    {
                        row.HeaderCell.Value = sRowHeader[idx++].ToString();
                    }

                }
            }
            dataGrid.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }
        
        public static int UI_COMBO_SELECT(System.Windows.Forms.ComboBox control, string sItem, bool bZeroBase = true)
        {
            int nIndex;
            control.SelectedIndex = control.FindStringExact(sItem);
            nIndex = control.SelectedIndex;

            if (nIndex < 0 && bZeroBase)
            {
                nIndex = 0;
            }

            if(nIndex >= 0)
            {
                if (control.Items.Count>0)
                {
                    control.SelectedIndex = nIndex;
                }
            }                
             
            return nIndex;
        }

        public static int UI_LISTVIEW_SELECT(System.Windows.Forms.ListView Listview, string sItem, bool bZeroBase = true)
        {
            int nIndex;
            ListViewItem item = Listview.Items
                                        .Cast<ListViewItem>()
                                        .FirstOrDefault(x => x.Text == sItem);

            nIndex = item.Index;

            if (nIndex < 0 && bZeroBase)
            {
                nIndex = 0;
               
            }

            return nIndex;
        }

        public static int UI_LISTBOX_SELECT(System.Windows.Forms.ListBox Listbox, string sItem, bool bZeroBase = true)
        {
            int nIndex;
            nIndex = Listbox.FindStringExact(sItem);
            // Determine if a valid index is returned. Select the item if it is valid.

            if (nIndex < 0 && bZeroBase)
            {
                nIndex = -1;
            }

            if ( nIndex >= 0)
            {
                if (Listbox.Items.Count > 0)
                {
                    Listbox.SetSelected(nIndex, true);
                }                
            }
            return nIndex;
        }
    }

    public class CBBoxItem
    {

        public string text { get; set; }

        public int value { get; set; }

        public CBBoxItem(string _text, int _value)
        {
            text = _text;
            value = _value;

        }

        public CBBoxItem()
        {

        }

        public override string ToString()
        {
            return text;
        }
    }
}
