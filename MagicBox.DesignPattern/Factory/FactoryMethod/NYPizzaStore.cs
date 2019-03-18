using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Factory.FactoryMethod
{
    public class NYPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string name)
        {
            switch (name)
            {
                case "cheese":
                    return new NYCheesePizza();
                case "peperoni":
                    return new NYPeperoniPizza();
                default:
                    throw new Exception("错误的产品名称");
            }
        }
    }
}
