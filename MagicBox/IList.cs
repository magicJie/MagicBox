namespace MagicBox
{
    public interface IList<T>
    {        
        /// <summary>
        /// 是否为空
        /// </summary>
        bool IsEmpty { get; }
        /// <summary>
        /// 最后一个元素
        /// </summary>
        T Last { get; }
        /// <summary>
        /// 数据元素个数
        /// </summary>
        int Count { get; }
        /// <summary>
        /// 清空线性表
        /// </summary>
        void Clear();
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="operation"></param>
        void Traverse(Func<T> operation);
        /// <summary>
        /// 索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T this[int index] { get; set; }
        /// <summary>
        /// 获取指定索引元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T GetElement(int index);
        /// <summary>
        /// 获取指定元素索引
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        int IndexOf(T element);
        /// <summary>
        /// 获取指定元素前一个元素
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        T PreElement(T element);
        /// <summary>
        /// 获取指定元素后一个元素
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        T NextElement(T element);
        /// <summary>
        /// 线性表尾增加一个元素
        /// </summary>
        /// <param name="element"></param>
        void Append(T element);
        /// <summary>
        /// 在指定元素（之前）插入一个元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        void Insert(int index, T element);
        /// <summary>
        /// 移除指定位置元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T RemoveAt(int index);
        /// <summary>
        /// 反转
        /// </summary>
        void Reverse();
    }
}
