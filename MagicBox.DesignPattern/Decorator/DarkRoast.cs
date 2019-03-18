using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Decorator
{
    public class DarkRoast : Beverage
    {
        public override float Cost()
        {
            return 10;
        }

        public override string GetDescription()
        {
            return $"{GetType().Name}";
        }
    }
}
