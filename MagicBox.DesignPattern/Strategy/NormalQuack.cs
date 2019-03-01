using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Strategy
{
    public class NormalQuack : IQuackBehavior
    {
        public string PeformQuack()
        {
            return "Ga Ga Ga...";
        }
    }
}
