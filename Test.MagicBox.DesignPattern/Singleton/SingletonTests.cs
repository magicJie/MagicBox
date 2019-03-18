using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicBox.DesignPattern.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MagicBox.DesignPattern.Singleton.Tests
{
    [TestClass()]
    public class SingletonTests
    {
        [TestMethod()]
        public void InstanceTest()
        {
            for (int i = 0; i < 30; i++)
            {
                Task.Run(() =>
                {
                    var ins = Singleton.Instance;
                    Console.WriteLine(ins.GetHashCode());
                });
            }
        }
    }
}