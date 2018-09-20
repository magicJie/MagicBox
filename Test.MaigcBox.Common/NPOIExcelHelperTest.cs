using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicBox;
using NPOI.HSSF.UserModel;

namespace Test.MaigcBox.Common
{
    [TestClass]
    public class NPOIExcelHelperTest
    {
        
        [TestMethod]
        public void DataTableToExcelTest()
        {
            var dt = NPOIExcelHelper.ExcelToDataTable("物料类型", true, @"C:\Users\Administrator\Desktop\宏源物料分类整理.xlsx");
        }

        [TestMethod]
        public void ExcelToDataTableTest()
        {
            var binaryFormater = new BinaryFormatter();

            var dt = NPOIExcelHelper.ExcelToDataTable("物料类型", true, @"C:\Users\Administrator\Desktop\宏源物料分类整理.xlsx");
            var fs = new FileStream(@"C:\Users\Administrator\Desktop\data", FileMode.Create, FileAccess.ReadWrite);
            binaryFormater.Serialize(fs,dt);
            fs.Flush(true);
            fs.Close();

            var fs1=new FileStream(@"C:\Users\Administrator\Desktop\data",FileMode.Open,FileAccess.Read);
            var dt1 = binaryFormater.Deserialize(fs1) as DataTable;
            NPOIExcelHelper.DataTableToExcel(dt1, "物料类型1", true, @"C:\Users\Administrator\Desktop\宏源物料分类整理1.xlsx");
        }

        [TestMethod]
        public void ReplaceItemValueTest()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var templatePath = dir+@"\zgd.xls";
            var outputPath = dir + @"\zgd1.xls";

            var fs = new FileStream(templatePath, FileMode.Open, FileAccess.Read);
            var workbook = new HSSFWorkbook(fs);
            fs.Close();
            var worksheetTemp = workbook.GetSheetAt(0) as HSSFSheet;
            worksheetTemp.CopySheet("整改单1");

            try
            {
                fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
                workbook.Write(fs);
            }
            finally
            {
                fs.Close();
                fs.Dispose();
            }
        }
    }
}
