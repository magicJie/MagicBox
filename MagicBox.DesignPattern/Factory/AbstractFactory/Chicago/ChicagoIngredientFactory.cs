using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicBox.DesignPattern.Factory.AbstractFactory.Ingredient;

namespace MagicBox.DesignPattern.Factory.AbstractFactory.Chicago
{
    public class ChicagoIngredientFactory : PizzaIngredientFactory
    {
        public override Cheese CreateCheese()
        {
            return new Cheese();
        }

        public override Clams CreateClam()
        {
            return new FreshClams();
        }

        public override Dough CreateDough()
        {
            return new Dough();
        }

        public override Peperoni CreatePeperoni()
        {
            throw new NotImplementedException();
        }

        public override Sauce CreateSauce()
        {
            return new Sauce();
        }
    }
}
