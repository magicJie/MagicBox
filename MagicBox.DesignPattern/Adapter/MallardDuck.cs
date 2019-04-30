using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Adapter
{
    public class MallardDuck : Duck
    {
        public override void Fly()
        {
            Console.WriteLine("I can fly 20m");
        }

        public override void Quack()
        {
            Console.WriteLine("Quack Quack Quack...");
        }
    }
}
