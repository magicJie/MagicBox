using System;
using System.Diagnostics;
using MagicBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Test.MaigcBox.Common
{
    [TestClass]
    public class EnvironmentHelperTest
    {
        [TestMethod]
        public void GetMachineInfoTest()
        {
            var a=EnvironmentHelper.GetMachineInfo();
            var b = EnvironmentHelper.GetMachineInfo();
            Assert.AreEqual(a, b,$"a:{a},b:{b}");
        }
    }
}
