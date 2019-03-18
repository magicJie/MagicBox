using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicBox.DesignPattern.Factory.AbstractFactory;

namespace MagicBox.DesignPattern.Factory
{
    public class NYPeperoniPizza : Pizza
    {
        public NYPeperoniPizza(PizzaIngredientFactory factory) : base(factory)
        {
        }

        public override void Prepare()
        {
            throw new NotImplementedException();
        }
    }
}
