using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicBox.DesignPattern.Decorator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MagicBox.DesignPattern.Decorator
{
    [TestClass()]
    public class DecortorTest
    {
        [TestMethod()]
        public void HouseBlendTest()
        {
            var b1 = new Milk(new Milk(new Mocha(new DarkRoast())));
            Console.WriteLine(b1.GetDescription());
        }
    }
}
