using System;

namespace MagicBox
{
    public interface IList<T>
    {
        int Last { get; }
        bool IsEmpty { get; }

        void Clear();

        int Count();

        T GetElement(int index);

        int IndexOf(T element);

        T PreElement(T element);

        T NextElement(T element);

        void Insert(int index, T element);

        T RemoveAt(int index);

        void Traverse(Func<T> operation);

        void Append(T element);

        void Reverse();
    }
}
