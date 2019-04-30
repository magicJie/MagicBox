using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Command
{
    public class LightOnCommand : Command
    {
        private Light _light;
        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public override void Excute()
        {
            _light.On();
        }

        public override void Undo()
        {
            _light.Off();
        }
    }
}
