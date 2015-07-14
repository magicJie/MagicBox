namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 排序节点
    /// </summary>
    internal class SqlOrderBy : SqlNode
    {
        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlOrderBy; }
        }
        /// <summary>
        /// 使用这个列进行排序
        /// </summary>
        public SqlColumn Column { get; set; }
        /// <summary>
        /// 使用这个方向进行排序
        /// </summary>
        public OrderDirection Direction { get; set; }
    }
}
