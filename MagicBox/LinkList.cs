using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicBox
{
    public class LinkList<T> : IList<T>
    {
        public int Last
        {
            get { throw new NotImplementedException(); }
        }

        bool IList<T>.IsEmpty
        {
            get { throw new NotImplementedException(); }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public T GetElement(int index)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T element)
        {
            throw new NotImplementedException();
        }

        public T PreElement(T element)
        {
            throw new NotImplementedException();
        }

        public T NextElement(T element)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T element)
        {
            throw new NotImplementedException();
        }

        public T RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Traverse(Func<T> operation)
        {
            throw new NotImplementedException();
        }

        public void Append(T element)
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }
    }
}
