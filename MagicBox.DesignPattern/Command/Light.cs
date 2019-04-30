using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Command
{
    public class Light
    {
        private string _name;
        public Light(string name)
        {
            _name = name;
        }

        public void On()
        {
            Console.WriteLine($"{_name} is on");
        }

        public void Off()
        {
            Console.WriteLine($"{_name} is off");
        }
    }
}
