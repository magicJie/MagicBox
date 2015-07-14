namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 一个数据源与一个具体表的连接结果，同时它也是一个新的数据源
    /// </summary>
    internal class SqlJoin : SqlSource
    {
        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlJoin; }
        }
        /// <summary>
        /// 左边需要连接的数据源
        /// </summary>
        public SqlSource Left { get; set; }
        /// <summary>
        /// 连接方式
        /// </summary>
        public SqlJoinType JoinType { get; set; }
        /// <summary>
        /// 右边需要连接的数据源
        /// </summary>
        public SqlTable Right { get; set; }
        /// <summary>
        /// 连接使用的约束条件
        /// </summary>
        public SqlConstraint Condition { get; set; }
    }
}
