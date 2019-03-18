using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Decorator
{
    public abstract class Beverage
    {
        public abstract string GetDescription();
        public abstract float Cost();
    }
}
