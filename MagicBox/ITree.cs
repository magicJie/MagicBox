using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicBox
{
    public interface ITree<T>
    {
        T Root
        {
            get;
            set;
        }

        T Parent
        {
            get;
            set;
        }

        T Child
        {
            get;
            set;
        }

        T RightSiblging
        {
            get;
            set;
        }

        bool IsEmpty
        {
            get;
            set;
        }

        bool Insert(T s, T t, int i);

        T Delete(T t, int i);

        void Traverse(TraverseType traverseType);

        void Clear();

        int GetDepth();
    }
}
