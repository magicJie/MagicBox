using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace MagicBox.Common
{
    /// <summary>
    /// 提供Excel处理的帮助。要求运行此代码的主机上安装了office
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// 将指定excle文件发送到打印机打印
        /// </summary>
        /// <param name="filePath">需要打印的文件</param>
        /// <returns>打印成功返回true，否则为false</returns>
        public bool SendExcelToPrinter(string filePath)
        {
            Application app = new Application();
            Workbook workbook = new Workbook();
            Worksheet worksheet =new Worksheet();
            try
            {
                workbook = app.Workbooks.Open(filePath);
                worksheet = (Worksheet) workbook.Worksheets[1];
                var defautPrinter = ExcelHelper.GetDefaultPrinter();
                SetDefaultPrinter("Samsung SCX-4x24 Series PCL6 Class Driver");
                worksheet.PrintOut();
                SetDefaultPrinter(defautPrinter);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.FinalReleaseComObject(worksheet);
                workbook.Close(false);
                Marshal.FinalReleaseComObject(workbook);
                app.Quit();
                Marshal.FinalReleaseComObject(app);
            }
        }

        public List<string> GetNetPrinters()
        {
            var printerList = new List<string>();
            ObjectQuery oquery = new ObjectQuery("SELECT * FROM Win32_Printer");
            ManagementObjectSearcher moseraher=new ManagementObjectSearcher(oquery);
            ManagementObjectCollection moc = moseraher.Get();
            foreach (ManagementObject mo in moc)
            {
                PropertyDataCollection pdc = mo.Properties;
                foreach (PropertyData pd in pdc)
                {
                    if ((bool)mo["Network"])
                    {
                        printerList.Add(mo[pd.Name].ToString());
                    }
                }
            }
            return printerList;
        }

        /// <summary>
        /// 查找已经安装的打印机
        /// </summary>
        /// <returns></returns>
        public List<string> GetLocalPrinters()
        {
            return PrinterSettings.InstalledPrinters.Cast<string>().ToList();
        } 

        [DllImport("Winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string printerName);
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int pcchBuffer);

        /// <summary>
        /// 获取默认打印机
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultPrinter()
        {
            const int ERROR_FILE_NOT_FOUND = 2;
            const int ERROR_INSUFFICIENT_BUFFER = 122;
            int pcchBuffer = 0;
            if (GetDefaultPrinter(null, ref pcchBuffer))
            {
                return null;
            }
            int lastWin32Error = Marshal.GetLastWin32Error();
            if (lastWin32Error == ERROR_INSUFFICIENT_BUFFER)
            {
                StringBuilder pszBuffer = new StringBuilder(pcchBuffer);
                if (GetDefaultPrinter(pszBuffer, ref pcchBuffer))
                {
                    return pszBuffer.ToString();
                }
                lastWin32Error = Marshal.GetLastWin32Error();
            }
            if (lastWin32Error == ERROR_FILE_NOT_FOUND)
            {
                return null;
            }
            throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public static string GetDefaultPrinter1()
        {
            return new PrintDocument().PrinterSettings.PrinterName;
        }

    }

}
