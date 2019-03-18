using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Decorator
{
    public class HouseBlend : Beverage
    {
        public override float Cost()
        {
            return 5 ;
        }

        public override string GetDescription()
        {
            return $"{GetType().Name}";
        }
    }
}
