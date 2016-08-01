using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace MagicBox.Common
{
    /// <summary>
    /// 提供Excel处理的帮助。要求运行此代码的主机上安装了office
    /// </summary>
    public class ExcelHelper
    {

        /// <summary>
        /// 将一个数据表存储到指定xls文件中。由于是从内存数据表直接进行处理，所以数据量很多的表格的导出
        /// </summary>
        /// <param name="fileName">xls文件名</param>
        /// <param name="dt">待导出的表</param>
        public void Export(string fileName, System.Data.DataTable dt)
        {
            int CurrentCol = 0;//当前列
            int RowCount = dt.Rows.Count + 1;//总行数
            int ColCount = dt.Columns.Count;//总列数
            StreamWriter sw = new StreamWriter(fileName, false);//文件如果存在，则自动覆盖
            try
            {
                #region XML头部
                sw.WriteLine("<?xml version=\"1.0\"?>");
                sw.WriteLine("<?mso-application progid=\"Excel.Sheet\"?>");
                sw.WriteLine("<Workbook");
                sw.WriteLine("xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                sw.WriteLine("xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
                sw.WriteLine("\t<Styles>");
                sw.WriteLine("\t\t<Style ss:ID=\"Default\" ss:Name=\"Normal\"><Alignment ss:Vertical=\"Center\"/><Font ss:FontName=\"宋体\" ss:Size=\"12\"/></Style>");
                sw.WriteLine("\t\t<Style ss:ID=\"s47\"><Font ss:FontName=\"宋体\" ss:Size=\"11\" ss:Color=\"#000000\"/><Interior ss:Color=\"#EBF1DE\" ss:Pattern=\"Solid\"/></Style>");
                sw.WriteLine("\t\t<Style ss:ID=\"s33\"><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Double\" ss:Weight=\"3\" ss:Color=\"#3F3F3F\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Double\" ss:Weight=\"3\" ss:Color=\"#3F3F3F\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Double\" ss:Weight=\"3\" ss:Color=\"#3F3F3F\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Double\" ss:Weight=\"3\" ss:Color=\"#3F3F3F\"/></Borders><Font ss:FontName=\"宋体\" ss:Size=\"11\" ss:Color=\"#FFFFFF\" ss:Bold=\"1\"/><Interior ss:Color=\"#A5A5A5\" ss:Pattern=\"Solid\"/></Style>");
                sw.WriteLine("\t\t<Style ss:ID=\"s68\" ss:Parent=\"s33\"><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\"/></Style>");
                sw.WriteLine("\t\t<Style ss:ID=\"s93\" ss:Parent=\"s47\"><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#3F3F3F\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#3F3F3F\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#3F3F3F\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#3F3F3F\"/></Borders></Style>");
                sw.WriteLine("\t</Styles>");
                sw.WriteLine("\t<Worksheet ss:Name=\"Sheet1\">");
                sw.WriteLine("\t\t<Table ss:DefaultColumnWidth=\"150\" ss:DefaultRowHeight=\"20\">");
                #endregion

                #region excel标题
                sw.WriteLine("\t\t\t<Row>");
                sw.WriteLine("\t\t\t\t<Cell ss:MergeAcross=\"{0}\" ss:StyleID=\"s68\">", ColCount - 1);
                sw.WriteLine("\t\t\t\t\t<Data ss:Type=\"String\">{0}</Data>", dt.TableName);
                sw.WriteLine("\t\t\t\t</Cell>");
                sw.WriteLine("\t\t\t</Row>");
                #endregion

                #region excel表头信息
                sw.WriteLine("\t\t\t<Row ss:AutoFitHeight=\"0\" ss:Height=\"15\">");
                for (CurrentCol = 0; CurrentCol < ColCount; CurrentCol++)
                {
                    sw.Write("\t\t\t\t<Cell ss:StyleID=\"s93\"><Data ss:Type=\"String\">{0}</Data></Cell>", dt.Columns[CurrentCol].ColumnName.ToString().Trim());
                }
                sw.WriteLine("\t\t\t</Row>");
                #endregion

                #region excel表格内容
                foreach (DataRow row in dt.Rows)
                {
                    sw.WriteLine("\t\t\t<Row ss:AutoFitHeight=\"0\" ss:Height=\"15\">");
                    for (CurrentCol = 0; CurrentCol < ColCount; CurrentCol++)
                    {
                        sw.Write("\t\t\t\t<Cell ss:StyleID=\"s93\"><Data ss:Type=\"String\">");
                        if (row[CurrentCol] != null)
                        {
                            sw.Write(row[CurrentCol].ToString().Trim());
                        }
                        else
                        {
                            sw.Write("");
                        }
                        sw.Write("</Data></Cell>");
                    }
                    sw.WriteLine("\t\t\t</Row>");
                }
                #endregion

                #region XML尾部
                sw.WriteLine("\t\t</Table>");
                sw.WriteLine("\t</Worksheet>");
                sw.WriteLine("</Workbook>");
                #endregion
            }
            catch
            { }
            finally
            {
                sw.Close();
                sw = null;
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

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
    }

}
