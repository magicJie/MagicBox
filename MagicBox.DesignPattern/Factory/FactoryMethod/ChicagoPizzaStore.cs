using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Factory.FactoryMethod
{
    public class ChicagoPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string name)
        {
            switch (name)
            {
                case "cheese":
                    return new ChicagoCheesePizza();
                case "peperoni":
                    return new ChicagoPeperoniPizza();
                default:
                    throw new Exception("错误的产品名称");
            }
        }
    }
}
