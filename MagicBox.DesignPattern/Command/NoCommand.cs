using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Command
{
    public class NoCommand : Command
    {
        public override void Excute()
        {
        }

        public override void Undo()
        {
        }
    }
}
