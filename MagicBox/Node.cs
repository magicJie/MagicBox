namespace MagicBox
{
    public class Node<T>
    {
        private T _data;
        private Node<T> _next;

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public Node<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        /// <summary>
        /// 构造器：普通结点
        /// </summary>
        /// <param name="item">数据域</param>
        /// <param name="p">引用域</param>
        public Node(T item, Node<T> p)
        {
            _data = item;
            _next = p;
        }
        /// <summary>
        /// 构造器：头结点
        /// </summary>
        /// <param name="p">引用域</param>
        public Node(Node<T> p)
        {
            _next = p;
        }
        /// <summary>
        /// 构造器：尾结点
        /// </summary>
        /// <param name="val">数据域</param>
        public Node(T val)
        {
            _data = val;
            _next = null;
        }
        /// <summary>
        /// 构造器：无参数
        /// </summary>
        public Node()
        {
            _data = default(T);
            _next = null;
        }
    }
}
