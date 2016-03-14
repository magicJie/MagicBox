/* *********************************************** 
* 作者：王杰，创建于2016/2/16 15:29:31 
* 邮箱：wangjie.magic@gmail.com 
* QQ ：2354557520
* ***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Printing;

namespace MagicBox.Common
{
    public class Printer
    {
        #region USB打印集成代码

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }

        [DllImport("fnthex32.dll")]
        public static extern int GETFONTHEX(
                              string BarcodeText,
                              string FontName,
                              string FileName,
                              int Orient,
                              int Height,
                              int Width,
                              int IsBold,
                              int IsItalic,
                              StringBuilder ReturnBarcodeCMD);

        [DllImport("fnthex32.dll")]
        public static extern int GETFONTHEX(
                              string BarcodeText,
                              string FontName,
                              int Orient,
                              int Height,
                              int Width,
                              int IsBold,
                              int IsItalic,
                              StringBuilder ReturnBarcodeCMD); 

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi,
            ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter,
            IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi,
            ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level,
            [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
                throw new Exception("打印出错，错误代码:" + dwError);
            }
            return bSuccess;
        }

        public bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }

        public bool SendStringToPrinter1(string szPrinterName,string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            //Encoding.GetEncoding("GB2312").GetBytes(szString);
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);

            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }

        /// <summary>
        /// 打印标签hr带有中文字符的ZPL指令
        /// </summary>
        /// <param name="szString"></param>
        /// <returns></returns>
        public void SendStringToPrinter(string printerName,string szString)
        {
            byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(szString); //转换格式
            IntPtr ptr = Marshal.AllocHGlobal(bytes.Length + 2);
            try
            {
                Marshal.Copy(bytes, 0, ptr, bytes.Length);
                SendBytesToPrinter(printerName, ptr, bytes.Length);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.FreeCoTaskMem(ptr);
            }
        }        

        /// <summary>
        /// 自动根据指令模板，替换序列进行打印。支持批量打印
        /// </summary>
        /// <param name="list"></param>
        public virtual void Print(List<KeyValuePair<string, Dictionary<string, string>>> list)
        {
            string printOrder = "";
            foreach (KeyValuePair<string, Dictionary<string, string>> kv in list)
            {
                string printOrderTemplate = kv.Key;

                string temp = string.Empty;
                foreach (KeyValuePair<string, string> parameterKeyValue in kv.Value)
                {
                    temp += printOrderTemplate.Replace(parameterKeyValue.Key, parameterKeyValue.Value);
                }
                printOrder += temp + "\r\n";
            }
            var printerName = new PrintDocument().PrinterSettings.PrinterName;//TODO 获取默认打印机名称
            this.SendStringToPrinter(printerName, printOrder);
        }
        #endregion
    }

}
