using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Decorator
{
    public class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage)
        {
            Beverage = beverage;
        }

        public override float Cost()
        {
            return Beverage.Cost() + 0.5f;
        }

        public override string GetDescription()
        {
            return $"Mocha,{Beverage.GetDescription()}";
        }
    }
}
