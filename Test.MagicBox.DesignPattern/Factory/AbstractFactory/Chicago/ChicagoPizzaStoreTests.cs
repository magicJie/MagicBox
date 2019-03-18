using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicBox.DesignPattern.Factory.AbstractFactory.Chicago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Factory.AbstractFactory.Chicago.Tests
{
    [TestClass()]
    public class ChicagoPizzaStoreTests
    {
        [TestMethod()]
        public void OrderPizzaTest()
        {
            var store = new ChicagoPizzaStore();
            store.OrderPizza("cheese");
            store.OrderPizza("peperoni");
        }
    }
}