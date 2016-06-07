using System;

namespace MagicBox
{
    public class LinkStack<T>:IStack<T>
    {
        private SingleLinkNode<T> _top;
        private int _size;

        public bool IsEmpty
        {
            get {return _top==null; }
        }

        public int Length
        {
            get { return _size; }
        }

        public void Push(T item)
        {
            var p = new SingleLinkNode<T>(item);
            if (_top == null) _top = p;
            else
            {
                p.Next = _top;
                _top = p;
            }
            _size++;
        }

        public T Pop()
        {
            if (_top == null) throw new Exception("Stack is empty!");
            var tmp = _top;
            _top = _top.Next;
            _size--;
            return tmp.Data;
        }

        public T GetTop()
        {
            if(_top==null)throw new Exception("Stack is empty!");
            return _top.Data;
        }

        public void Clear()
        {
            _top = null;
            _size = 0;
        }

        public override string ToString()
        {
            var str = "";
            var p = _top;
            while (p.Next!=null)
            {
                str += p.Data + ",";
                p = p.Next;
            }
            str += p.Data;
            return str;
        }
    }
}
