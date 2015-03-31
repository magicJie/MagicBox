namespace MagicBox
{
    public class SingleLinkNode<T>
    {
        public T Data { get; set; }
        public SingleLinkNode<T> Next { get; set; }

        public SingleLinkNode()
        {
            Data = default(T);
            Next = null;
        }

        public SingleLinkNode(T val)
        {
            Data = val;
            Next = null;
        }

        public SingleLinkNode(T val, SingleLinkNode<T> next)
        {
            Data = val;
            Next = next;
        }
    }
}
