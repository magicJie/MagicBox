using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Factory.SimpleFactory
{
    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(string name)
        {
            switch (name)
            {
                case "cheese":
                    return new CheesePizza();
                case "pepperoni":
                    return new PepperoniPizza();
                default:
                    throw new Exception("错误的pizza名称");
            }
        }
    }
}
