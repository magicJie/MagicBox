using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox
{
    interface IStack<T>
    {
        bool IsEmpty { get;}
        int Length { get; }

        void Push(T item);
        T Pop();
        T GetTop();
        void Clear();
    }
}
