using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicBox.DesignPattern.Factory.AbstractFactory.Ingredient;

namespace MagicBox.DesignPattern.Factory.AbstractFactory.NY
{
    public class NYIngredientFactory : PizzaIngredientFactory
    {
        public NYIngredientFactory()
        {
        }

        public override Cheese CreateCheese()
        {
            throw new NotImplementedException();
        }

        public override Clams CreateClam()
        {
            return new FreshClams();
        }

        public override Dough CreateDough()
        {
            throw new NotImplementedException();
        }

        public override Peperoni CreatePeperoni()
        {
            throw new NotImplementedException();
        }

        public override Sauce CreateSauce()
        {
            throw new NotImplementedException();
        }
    }
}
