using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Command
{
    public class LightOffCommand : Command
    {
        private Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }
        public override void Excute()
        {
            _light.Off();
        }

        public override void Undo()
        {
            _light.On();
        }
    }
}
