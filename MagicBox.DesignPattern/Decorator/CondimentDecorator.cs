using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Decorator
{
    public abstract class CondimentDecorator:Beverage
    {
        protected Beverage Beverage;
    }
}
