using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Factory.AbstractFactory.Ingredient
{
    public abstract class Ingredient
    {
        public virtual string GetDescription() {
            return $"{GetType().Name}";
        }
    }
}
