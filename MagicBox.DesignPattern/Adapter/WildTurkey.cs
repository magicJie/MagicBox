using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Adapter
{
    public class WildTurkey : Turkey
    {
        public override void Fly()
        {
            Console.WriteLine("I can fly 3m");
        }

        public override void Gobble()
        {
            Console.WriteLine("gobble gobble gobble");
        }
    }
}
