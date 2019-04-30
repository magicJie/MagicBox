using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Command
{
    public class RemoteControl
    {
        private Command[] _onComands;
        private Command[] _offCommands;
        private Command _lastCommand;

        public RemoteControl()
        {
            _onComands = new Command[7];
            _offCommands = new Command[7];
            _lastCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                _onComands[i] = _lastCommand;
                _offCommands[i] = _lastCommand;
            }
        }

        public void SetCommand(int slot, Command onCommand, Command offCommand)
        {
            _onComands[slot] = onCommand;
            _offCommands[slot] = offCommand;
        }

        public void OnButtonWasPushed(int slot)
        {
            _onComands[slot].Excute();
            _lastCommand = _onComands[slot];
        }

        public void OffButtonWasPushed(int slot)
        {
            _offCommands[slot].Excute();
            _lastCommand = _offCommands[slot];
        }

        public void Undo()
        {
            _lastCommand.Undo();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
