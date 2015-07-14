namespace MagicBox.MF.ORM.SqlTree
{
    internal abstract class SqlNode
    {
        /// <summary>
        /// 获取当前树节点类型
        /// </summary>
        public abstract SqlNodeType NodeType { get; }      
    }
}
