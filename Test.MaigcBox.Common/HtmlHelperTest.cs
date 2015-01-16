using System.Globalization;
using MagicBox.Common;
using Microsoft.SqlServer.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Test.MaigcBox.Common
{
    
    
    /// <summary>
    ///This is a test class for HtmlHelperTest and is intended
    ///to contain all HtmlHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HtmlHelperTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for OpenHtml
        ///</summary>
        [TestMethod()]
        public void OpenHtmlTest()
        {
            HtmlHelper target = new HtmlHelper(); // TODO: Initialize to an appropriate value
            string path = "/tmp/工票打印.htm";
            string htmlContent = target.OpenHtml(path);

        }



        /// <summary>
        ///A test for OpenAndReplaceData
        ///</summary>
        [TestMethod()]
        public void OpenAndReplaceDataTest()
        {
            HtmlHelper target = new HtmlHelper(); // TODO: Initialize to an appropriate value
            string path = "/tmp/工票打印.htm";
            Dictionary<string,string> dic=new Dictionary<string, string>();
            dic.Add("$工作编号$","OD123456");
            dic.Add("$订单类型$","东电无物料生产订单");
            var content = target.OpenAndReplaceData(path, dic);
        }

        [TestMethod()]
        public void TestForToString()
        {
            const double m = 1.1254;
            var a = m.ToString("G2");
            var b = m.ToString("f1");
            var c = Math.Round(m, 2, MidpointRounding.AwayFromZero);
            var d = Math.Round(m, 2, MidpointRounding.ToEven);
            var e = m.ToString(CultureInfo.CurrentCulture);
            var f = e.Substring(0, e.IndexOf('.') + 3);
        }

        [TestMethod]
        public void TestTmp()
        {
            var a = "a;b;c;;;d;e;f";
            var b = a.Split(';');

        }
    }
}
