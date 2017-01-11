/* *********************************************** 
* 作者：王杰，创建于2016/9/30 11:36:57 
* 邮箱：wangjie@bill-sj.com
* QQ ：2354557520
* ***********************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicBox.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.Common.Tests
{
    [TestClass()]
    public class DateTimeExtensionTests
    {
        public DateTime dt = DateTime.Now;

        [TestMethod()]
        public void GetWeekofYearTest()
        {
            Assert.AreEqual(40,dt.GetWeekofYear());
        }

        [TestMethod()]
        public void GetFirstDayOfWeekTest()
        {
            Assert.AreEqual(new DateTime(dt.Year,9,26).ToShortDateString(), dt.GetFirstDayOfWeek().ToShortDateString());
        }

        [TestMethod()]
        public void GetLastDayOfWeekTest()
        {
            Assert.AreEqual(new DateTime(dt.Year, 10, 2).ToShortDateString(), dt.GetLastDayOfWeek().ToShortDateString());
        }

        [TestMethod()]
        public void GetFirstDayOfMonthTest()
        {
            Assert.AreEqual(new DateTime(dt.Year, 9, 1).ToShortDateString(), dt.GetFirstDayOfMonth().ToShortDateString());
        }

        [TestMethod()]
        public void GetLastDayOfMonthTest()
        {
            Assert.AreEqual(new DateTime(dt.Year, 9, 30).ToShortDateString(), dt.GetLastDayOfMonth().ToShortDateString());
        }

        [TestMethod()]
        public void GetFirstDayOfQuarterTest()
        {
            Assert.AreEqual(new DateTime(dt.Year, 7, 1).ToShortDateString(), dt.GetFirstDayOfQuarter().ToShortDateString());
        }

        [TestMethod()]
        public void GetLastDayOfQuarterTest()
        {
            Assert.AreEqual(new DateTime(dt.Year, 9, 30).ToShortDateString(), dt.GetLastDayOfQuarter().ToShortDateString());
        }

        [TestMethod()]
        public void GetFirstDayOfYearTest()
        {
            Assert.AreEqual(new DateTime(dt.Year, 1, 1).ToShortDateString(), dt.GetFirstDayOfYear().ToShortDateString());
        }

        [TestMethod()]
        public void GetLastDayOfYearTest()
        {
            Assert.AreEqual(new DateTime(dt.Year, 12, 31).ToShortDateString(), dt.GetLastDayOfYear().ToShortDateString());
        }
    }
}