using System;

namespace MagicBox
{
    public class LinkQueue<T>:IQueue<T>
    {
        private SingleLinkNode<T> _front;
        private SingleLinkNode<T> _rear;
        private int _size;

        public bool IsEmpty
        {
            get { return _front==_rear&&_size==0; }
        }

        public bool IsFull
        {
            get { return false; }
        }

        public int Length
        {
            get { return _size; }
        }

        public SingleLinkNode<T> Front
        {
            get { return _front; }
            set { _front=value; }
        }

        public SingleLinkNode<T> Rear
        {
            get { return _rear; }
            set { _rear=value; }
        }

        public void EnQueue(T item)
        {
            var p = new SingleLinkNode<T>(item);
            if (IsEmpty)
            {
                _front = _rear = p;
            }
            else
            {
                _rear.Next = p;
                _rear = p;
            }
            _size++;
        }

        public T DeQueue()
        {
            if(IsEmpty)throw new Exception("Queue is empty!");
            var p = _front;
            _front = _front.Next;
            if (_front == null) _rear = null;
            _size--;
            return p.Data;
        }

        public T GetFront()
        {
            if (IsEmpty) throw new Exception("Queue is empty!");
            return _front.Data;
        }

        public void Clear()
        {
            _front = _rear = null;
            _size = 0;
        }

        public override string ToString()
        {
            var str = "";
            var p = _front;
            while (p.Next!=null)
            {
                str += p.Data+",";
                p = p.Next;
            }
            str += p.Data;
            return str;
        }
    }
}
