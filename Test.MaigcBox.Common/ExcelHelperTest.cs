using System.Diagnostics;
using System.Linq;
using System.Threading;
using MagicBox.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Timeout = MagicBox.Common.Timeout;

namespace Test.MaigcBox.Common
{
    /// <summary>
    ///这是 ExcelHelperTest 的测试类，旨在
    ///包含所有 ExcelHelperTest 单元测试
    ///</summary>
    [TestClass()]
    public class ExcelHelperTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup().
        //{
        //}
        //
        #endregion

        /// <summary>
        ///SendExcelToPrinter 的测试
        ///</summary>
        [TestMethod()]
        public void SendExcelToPrinterTest()
        {
            ExcelHelper target = new ExcelHelper(); // TODO: 初始化为适当的值
            const string filePath = @"D:\Developing\ddmes\01源码\FppData\Excel\工票批20141029034829413.xls"; // TODO: 初始化为适当的值
            //Assert.IsTrue(target.SendExcelToPrinter(filePath));
        }

        /// <summary>
        ///GetLocalPrinters 的测试
        ///</summary>
        [TestMethod()]
        public void GetNetPrintersTest()
        {
            ExcelHelper target = new ExcelHelper(); // TODO: 初始化为适当的值
            Assert.IsTrue(target.GetNetPrinters().Any(), "没有查找到网络上的打印机，该方法存在bug");
        }

        /// <summary>
        ///GetLocalPrinters 的测试
        ///</summary>
        [TestMethod()]
        public void GetLocalPrintersTest()
        {
            ExcelHelper target = new ExcelHelper(); // TODO: 初始化为适当的值
            Assert.IsTrue(target.GetLocalPrinters().Any(),"没有查找到系统中的打印机，该方法存在bug");
        }

        /// <summary>
        ///GetDefaultPrinter 的测试
        ///</summary>
        [TestMethod()]
        public void GetDefaultPrinterTest()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(ExcelHelper.GetDefaultPrinter()),"未能读取到默认打印机，该方法存在bug");
        }

        /// <summary>
        ///SetDefaultPrinter 的测试
        ///</summary>
        [TestMethod()]
        public void SetDefaultPrinterTest()
        {
            Assert.IsTrue(ExcelHelper.SetDefaultPrinter("Microsoft XPS Document Writer"));
        }

        /// <summary>
        ///GetDefaultPrinter1 的测试
        ///</summary>
        [TestMethod()]
        public void GetDefaultPrinter1Test()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(ExcelHelper.GetDefaultPrinter1()));
        }
    }
}
