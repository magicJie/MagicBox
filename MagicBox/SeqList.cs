using System;
using System.Linq;
using System.Text;

namespace MagicBox
{
    public class SeqList<T> : IList<T>
    {
        private int _maxsize;
        private T[] _data;
        private int _last;

        public T this[int index]
        {
            get { return GetElement(index); }
            set {
                if (index<0||index>_last+1)
                {
                    throw new IndexOutOfRangeException();
                }
                _data[index] = value;
            }
        }
        public bool IsEmpty
        {
            get { return _last == -1; }
        }

        public bool IsFull
        {
            get { return _last == _maxsize - 1; }
        }

        public T Last
        {
            get { return this[_last]; }
        }
        
        public int Maxsize
        {   
            get { return _maxsize; }
            //注意在重置最大容量后要修改_data
            set
            {
                _maxsize = value;
                var tmp = new T[_maxsize];
                var i = 0;
                foreach (var item in _data)
                {
                    tmp[i++] = item;
                }
                _data = tmp;
            }
        }
        /// <summary>
        /// 指定最大容量进行初始化
        /// </summary>
        /// <param name="size">最大容量</param>
        public SeqList(int size)
        {
            _data = new T[size];
            _maxsize = size;
            _last = -1;
        }

        public void Clear()
        {
            _last = -1;
        }

        public int Count
        {
            get { return _last + 1; }
        }

        public T GetElement(int index)
        {
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }
            if (index < 0 || index > _last)
            {
                throw new Exception("Position is error");
            }
            return _data[index];
        }

        public int IndexOf(T element)
        {
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }
            var i = 0;
            for (; i <=_last; i++)
            {
                if (element.Equals(_data[i]))
                {
                    break;
                }
            }
            if (i > _last)
            {
                return -1;
            }
            return i;
        }

        public T PreElement(T element)
        {
            var i = IndexOf(element);
            if(i<0)throw new Exception("The element is not exist");
            if(i-1<0)throw new Exception("PreElement is not exist");
            return this[i - 1];
        }

        public T NextElement(T element)
        {
            var i = IndexOf(element);
            if (i < 0) throw new Exception("The element is not exist");
            if (i + 1 >_last) throw new Exception("Next Element is not exist");
            return this[i + 1];
        }
        /// <summary>
        /// 将元素插入指定索引之前
        /// </summary>
        /// <param name="index">要插入的位置索引</param>
        /// <param name="element">要插入的元素</param>
        public void Insert(int index, T element)
        {
            if (IsFull)
            {
                throw new Exception("List is full");
            }

            if (index < 0 || index > Count)
            {
                throw new Exception("Position is error");
            }

            if (index == _last + 1)
            {
                _data[_last + 1] = element;
            }
            else
            {
                //位置index及以后元素后移
                for (var i = _last; i >=index; i--)
                {
                    _data[i + 1] = _data[i];
                }
                _data[index] = element;
            }
            _last++;
        }

        public T RemoveAt(int index)
        {
            var tmp = default(T);
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }

            if (index < 0 || index > _last)
            {
                throw new Exception("Position is error");
            }

            if (index == _last)
            {
                tmp = _data[_last];
            }
            else
            {
                tmp = _data[index];
                //位置index以后元素前移
                for (var i = index; i <= _last; i++)
                {
                    _data[i] = _data[i + 1];
                }
            }
            _last--;
            return tmp;
        }

        public void Traverse(Func<T> operation)
        {
            for (int i = 0; i < _data.Count(); i++)
            {
                _data[i] = operation(_data[i]);
            }
        }

        public void Append(T element)
        {
            if (IsFull)
            {
                throw new Exception("List is full");
            }
            _data[++_last] = element;
        }

        public void Reverse()
        {
            var tmp = default(T);
            for (var i = 0; i <=_last/2; i++)
            {
                tmp = _data[i];
                _data[i] = _data[_last - i];
                _data[_last - i] = tmp;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i <=_last; i++)
            {
                sb.Append(_data[i].ToString() + ",");
            }
            return sb.ToString().TrimEnd(',');
        }
    }
}
