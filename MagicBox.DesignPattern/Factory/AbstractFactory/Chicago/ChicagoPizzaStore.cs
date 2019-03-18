using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Factory.AbstractFactory.Chicago
{
    public class ChicagoPizzaStore : PizzaStore
    {
        public override Pizza OrderPizza(string name)
        {
            var pizza = CreatePizza(name);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

        protected override Pizza CreatePizza(string name)
        {
            switch (name)
            {
                case "cheese":
                    return new ChicagoCheesePizza(new ChicagoIngredientFactory());
                case "peperoni":
                    return new ChicagoPeperoniPizza(new ChicagoIngredientFactory());
                default:
                    throw new Exception("错误的产品名称");
            }
        }
    }
}
