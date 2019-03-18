using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Factory.AbstractFactory.Chicago
{
    public class ChicagoPeperoniPizza : Pizza
    {
        public ChicagoPeperoniPizza(PizzaIngredientFactory factory) : base(factory)
        {
        }

        public override void Prepare()
        {
            Console.WriteLine($"Begin{GetType().Name} Preparing.");
            _Peperoni = _Factory.CreatePeperoni();
            Console.WriteLine($"Using {_Peperoni.GetDescription()}");
            Console.WriteLine("End Preparing");
        }
    }
}
