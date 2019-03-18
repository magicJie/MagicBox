using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Factory.AbstractFactory
{
    public abstract class PizzaStore
    {
        public abstract Pizza OrderPizza(string name);
        protected abstract Pizza CreatePizza(string name);
    }
}
