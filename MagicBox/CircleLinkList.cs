namespace MagicBox
{
    public class CircleLinkList<T>
    {
        public class Node
        {
            public Node NextNode { get; set; }

            public Node PreNode { get; set; }
            public T Data { get; set; }

            public int Index { get; set; }

            public Node(Node preNode,Node nextNode,T data)
            {
                PreNode = preNode;
                NextNode = nextNode;
                Data = data;
            }

            public Node(T data)
            {
                PreNode =NextNode= null;
                Data = data;
            }
        }

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public Node Point {
            get { return _point; }
            set { _point = value; }
        }

        private Node _point;
        private int _count;
        private Node _head;
        private Node _tail;

        /// <summary>
        /// 在Point后增加一个节点
        /// </summary>
        /// <param name="node"></param>
        public void Append(Node node)
        {
            if (_count < 1)
            {
                _point = node;
                _head = node;
                _tail = node;
            }
            else if (_count==1)
            {
                _point = node;
                _head.NextNode = node;
                node.PreNode = _head;
                node.NextNode = _tail;
            }
            else
            {
                var x = _point;
                var y = _point.NextNode;
                x.NextNode = node;
                node.PreNode = x;
                node.NextNode = y;
                y.PreNode = node;
                _point = node;
            }
            _count++;
        }

        /// <summary>
        /// 删除Point处的一个节点
        /// </summary>
        public Node Delete()
        {
            var node = _point;
            if (_count>2)
            {
                var x = _point.PreNode;
                var y = _point.NextNode;
                x.NextNode = y;
                y.PreNode = x;
                _point = y;
            }
            else if (_count==2)
            {
                _point = _point.NextNode;
                _point.PreNode = _point.NextNode = null;
            }
            else
            {
                _point = null;
                _head = null;
            }
            _count--;
            return node;
        }

        public CircleLinkList(Node node)
        {
            _point = node;
            _head = node;
            _count = 1;
        }
    }
}