using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Factory.FactoryMethod
{
    public abstract class PizzaStore
    {
        public virtual Pizza OrderPizza(string name)
        {
            var pizza = CreatePizza(name);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

        public abstract Pizza CreatePizza(string name);
    }
}
