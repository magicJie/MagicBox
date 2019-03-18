using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicBox.DesignPattern.Factory.SimpleFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Factory.SimpleFactory.Tests
{
    [TestClass()]
    public class PizzaStoreTests
    {
        [TestMethod()]
        public void OrderPizzaTest()
        {
            var store = new PizzaStore(new SimplePizzaFactory());
            store.OrderPizza("cheese");
            store.OrderPizza("pepperoni");
        }
    }
}