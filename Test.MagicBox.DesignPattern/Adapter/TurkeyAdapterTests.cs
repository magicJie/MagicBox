using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicBox.DesignPattern.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Adapter.Tests
{
    [TestClass()]
    public class DuckAdapterTests
    {
        [TestMethod()]
        public void DuckAdapterTest()
        {
            var turkey = new WildTurkey();
            var duck = new DuckAdapter(turkey);
            duck.Fly();
            duck.Quack();
        }
    }
}