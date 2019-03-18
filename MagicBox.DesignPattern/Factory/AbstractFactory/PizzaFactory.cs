using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicBox.DesignPattern.Factory.AbstractFactory.Ingredient;

namespace MagicBox.DesignPattern.Factory.AbstractFactory
{
    public abstract class PizzaIngredientFactory
    {
        public abstract Peperoni CreatePeperoni();

        public abstract Cheese CreateCheese();

        public abstract Dough CreateDough();

        public abstract Sauce CreateSauce();

        public abstract Clams CreateClam();
    }
}
