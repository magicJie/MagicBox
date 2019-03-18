using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Decorator
{
    public class Milk : CondimentDecorator
    {
        public Milk(Beverage beverage) {
            Beverage = beverage;
        }

        public override float Cost()
        {
            return Beverage.Cost() + 1.0f;
        }

        public override string GetDescription()
        {
            return $"Milk{Beverage.GetDescription()}";
        }
    }
}
