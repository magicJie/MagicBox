using System;

namespace MagicBox
{
    /*利用循环结构规避假溢出问题*/
    public class CSeqQueue<T>:IQueue<T>
    {
        private int _maxsize;
        private T[] _data;
        private int _front;
        private int _rear;

        public bool IsEmpty
        {
            get { return _front==_rear; }
        }

        public bool IsFull
        {
            get
            {
                return _front == -1 && _rear == _maxsize - 1 || (_rear + 1) % _maxsize == _front;
            }
        }

        public int Length
        {
            get { return (_rear-_front+_maxsize)%_maxsize; }
        }

        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public int Maxsize
        {
            get { return _maxsize; }
            set
            {
                _maxsize = value;
                var tmp = _data;
                _data=new T[_maxsize];
                var m = _data.Length;
                for (var i = 0; i < m; i++)
                {
                    _data[i] = tmp[i];
                }
            }
        }

        public int Front
        {
            get { return _front; }
            set { _front=value; }
        }

        public int Rear
        {
            get { return _rear; }
            set { _rear=value; }
        }

        public CSeqQueue()
        {
        }

        public CSeqQueue(int size)
        {
            _data=new T[size];
            _maxsize = size;
            _front = _rear = -1;
        }

        public void EnQueue(T item)
        {
            if(IsFull)throw new Exception("Queue is full!");
            _rear = (_rear + 1)%_maxsize;
            _data[_rear] = item;
        }

        public T DeQueue()
        {
            if(IsEmpty)throw new Exception("Queue is empty!");
            _front = (_front + 1)%_maxsize;
            var tmp = _data[_front];
            _data[_front] = default(T);
            return tmp;
        }

        public T GetFront()
        {
            if(IsEmpty) throw new Exception("Queue is empty!");
            return _data[(_front + 1)%_maxsize];//front从-1开始
        }

        public void Clear()
        {
            _front = _rear = -1;
        }

        public override string ToString()
        {
            var str = "rear:" + _rear + ";front:" + _front + ";";
            var m = _data.Length;
            for (var i = 0; i < m; i++)
            {
                if (i != m - 1) str += _data[i] + ",";
                else str += _data[i];
            }
            return str;
        }
    }
}
