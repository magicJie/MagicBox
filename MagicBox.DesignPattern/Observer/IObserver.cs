using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Observer
{
    public interface IObserver
    {
        void Update(Object observerable);
    }
}