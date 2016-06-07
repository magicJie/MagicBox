using System;
using System.Linq;

namespace MagicBox
{
    public class SequenceStack<T>:IStack<T>
    {
        private int _maxsize;
        private T[] _data;
        private int _top;

        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public bool IsEmpty
        {
            get
            {
                return _top == -1;
            }
        }

        public int Length
        {
            get { return _top + 1; }
        }

        public int Maxsize {
            get { return _maxsize; }
            set
            {
                _maxsize = value;
                var tmp = _data;
                _data=new T[_maxsize];
                var m = tmp.Length;
                for (var i = 0; i < m; i++)
                {
                    _data[i] = tmp[i];
                }
            }
        }

        public bool IsFull {
            get { return _top == _maxsize - 1; }
        }

        public SequenceStack(int size)
        {
            _data=new T[size];
            _maxsize = size;
            _top = -1;
        }

        public void Push(T item)
        {
            if(IsFull) throw new Exception("Stack is Full!");
            _data[++_top] = item;
        }

        public T Pop()
        {
            if(IsEmpty)throw new Exception("Stack is Empty!");
            return _data[_top--];
        }

        public T GetTop()
        {
            if (IsEmpty) throw new Exception("Stack is Empty!");
            return _data[_top];
        }

        public void Clear()
        {
            _top = -1;
        }

        public override string ToString()
        {
            var str = "";
            var m = Length;
            for (var i = m-1; i >-1; i--)
            {
                if (i != 0) str += this[i] + ",";
                else str += this[i];
            }
            return str;
        }
    }
}
