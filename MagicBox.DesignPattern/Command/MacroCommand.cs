using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Command
{
    public class MacroCommand : Command
    {
        private Command[] _commands;

        public MacroCommand(Command[] commands)
        {
            _commands = commands;
        }

        public override void Excute()
        {
            foreach (var command in _commands)
            {
                command.Excute();
            }
        }

        public override void Undo()
        {
            foreach (var command in _commands.Reverse())
            {
                command.Undo();
            }
        }
    }
}
