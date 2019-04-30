using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Command
{
    public abstract class Command
    {
        public abstract void Excute();

        public abstract void Undo();
    }
}
