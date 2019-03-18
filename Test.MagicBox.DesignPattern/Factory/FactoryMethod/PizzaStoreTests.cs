using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicBox.DesignPattern.Factory.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Factory.FactoryMethod.Tests
{
    [TestClass()]
    public class PizzaStoreTests
    {
        [TestMethod()]
        public void OrderPizzaTest()
        {
            PizzaStore store = new ChicagoPizzaStore();
            store.OrderPizza("cheese");
            store.OrderPizza("peperoni");
            store = new NYPizzaStore();
            store.OrderPizza("cheese");
            store.OrderPizza("peperoni");
        }
    }
}