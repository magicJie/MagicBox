using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Factory.AbstractFactory.Chicago
{
    public class ChicagoCheesePizza : Pizza
    {
        public ChicagoCheesePizza(PizzaIngredientFactory factory) : base(factory)
        {

        }

        public override void Prepare()
        {
            Console.WriteLine($"Begin{GetType().Name} Preparing.");
            _Cheese = _Factory.CreateCheese();
            Console.WriteLine($"Using {_Cheese.GetDescription()}");
            Console.WriteLine("End Preparing");
        }
    }
}
