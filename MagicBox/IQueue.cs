namespace MagicBox
{
    public interface IQueue<T>
    {
        bool IsEmpty
        {
            get;
        }

        bool IsFull
        {
            get;
        }

        int Length
        {
            get;
        }

        void EnQueue(T item);

        T DeQueue();

        T GetFront();

        void Clear();
    }
}
