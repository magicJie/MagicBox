using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicBox.Common;

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
    }
}
