using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicBox.DesignPattern.Factory.AbstractFactory;
using MagicBox.DesignPattern.Factory.AbstractFactory.Ingredient;

namespace MagicBox.DesignPattern.Factory
{
    public abstract class Pizza
    {
        protected PizzaIngredientFactory _Factory;

        protected Cheese _Cheese;
        protected Peperoni _Peperoni;
        protected Sauce _Sauce;
        protected Clams _Clams;

        public Pizza(PizzaIngredientFactory factory)
        {
            _Factory = factory;
        }

        public abstract void Prepare();
        
        public virtual void Bake()
        {
            Console.WriteLine($"{GetType().Name} Baking");
        }
        public virtual void Cut()
        {
            Console.WriteLine($"{GetType().Name} Cuting");
        }
        public virtual void Box()
        {
            Console.WriteLine($"{GetType().Name} Boxing");
        }
    }
}
