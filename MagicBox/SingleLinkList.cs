using System;

namespace MagicBox
{
    public class SingleLinkList<T> : IList<T>
    {
        private Node<T> _head;

        public T this[int index] {
            get {
                if (IsEmpty||index<0||index>Count-1)
                {
                    throw new Exception("SingleLinkedList is empty or Position is error!");
                }
                var p = _head;
                var i = 0;
                while (p != null && p.Next != null && i < index)
                {
                    p = p.Next;
                    ++i;
                }
                return p == null ? default(T) : p.Data;
            }
            set
            {
                if (index < 0 || index > Count - 1||index!=0&&_head==null)
                {
                    throw new Exception("Position is error!");
                }
                var p = _head;
                if (index==0)
                {
                    _head = new Node<T>(value) {Next = p.Next};
                }
                var i = 0;
                while (p.Next!=null||i<index)
                {
                    p = p.Next;
                    ++i;
                }
                p.Data = value;
            }
        }

        public T Last
        {
            get
            {
                var p=_head;
                while (p!=null&&p.Next!=null)
                {
                    p = p.Next;
                }
                return p==null ? default(T) : p.Data;
            }
        }

        public void Clear()
        {
            _head = null;
        }

        public int Count {
            get
            {
                Node<T> p = _head;
                int len = 0;
                while (p != null)
                {
                    ++len;
                    p = p.Next;
                }
                return len;
            }
        }

        public SingleLinkList(params T[] paramaters)
        {
            _head = new Node<T>(paramaters[0]);
            var p = _head;
            var count = paramaters.Length;
            for (var i = 1; i < count ; i++)
            {
                p.Next=new Node<T>(paramaters[i]);
                p = p.Next;
            }
        }

        public T GetElement(int index)
        {
            return this[index];
        }

        public int IndexOf(T element)
        {
            var i = 0;
            var p = _head;
            if (p==null||p.Data==null)
            {
                return -1;
            }
            if (p.Data.Equals(element))
            {
                return 0;
            }
            while(p.Next!=null)
            {               
                if (p.Data.Equals(element))
                {
                    break;
                }
                p = p.Next;
                ++i;
            }
            return i;
        }

        public T PreElement(T element)
        {
            return this[IndexOf(element) - 1];
        }

        public T NextElement(T element)
        {
            return this[IndexOf(element) + 1];
        }

        public void Insert(int index, T element)
        {
            if (IsEmpty||index<0||index>Count)
            {
                throw new Exception("SingleLinkedList is empty or Position is error!");
            }
            if (index==0)
            {
                var q = new Node<T>(element) {Next = _head};
                _head = q;
                return;
            }
            var r = new Node<T>(element);
            var p = _head;
            var tmp = new Node<T>();
            var i = 0;
            while (p.Next!=null&&i<index)
            {
                tmp = p;
                p = p.Next;
                ++i;
            }
            tmp.Next = r;
            r.Next = p;
        }

        public T RemoveAt(int index)
        {
            if (_head==null || index < 0 || index > Count-1)
            {
                throw new Exception("SingleLinkList is empty or position is error!");
            }
            if (index==0)
            {
                var tmp = _head.Data;
                _head = _head.Next;
                return tmp;
            }
            var p = _head;
            var q = new Node<T>();
            var i = 0;
            while (p.Next!=null&&i<index)
            {
                q = p;
                p = p.Next;
                ++i;
            }
            q.Next = index==Count-1 ? null : p.Next;
            return p.Data;
        }

        public void Traverse(Func<T> operation)
        {
            var p = _head;
            while (p!=null&&p.Next!=null)
            {
                operation(p.Data);
                p = p.Next;
            }
        }

        public void Append(T element)
        {
            var q = new Node<T>(element);
            if (_head==null)
            {
                _head = q;
                return;
            }
            var p = _head;
            while (p.Next!=null)
            {
                p = p.Next;
            }
            p.Next = q;
        }

        public void Reverse()
        {
            if (_head==null)
            {
                return;
            }
            var p = _head;
            while (p.Next!=null)
            {
                var x = p;
                p = p.Next;
                var y = p;
                var z = p.Next;
                if (x==_head)
                {
                    x.Next = null;
                }
                if (z==null)
                {
                    _head = y;
                    _head.Next = x;
                }
                else
                {
                    z.Next = y;
                    y.Next = x;
                }
            }
        }

        public bool IsEmpty
        {
            get { return _head == null; }
        }

        public override string ToString()
        {
            var p = _head;
            if (p==null)
            {
                return "null";
            }
            var str = "";
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
