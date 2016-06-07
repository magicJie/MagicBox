namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 表示一个取反规则条件
    /// </summary>
    internal class SqlNotConstraint : SqlConstraint
    {
        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlNotConstraint; }
        }
        /// <summary>
        /// 要被取反的条件
        /// </summary>
        public SqlConstraint Constraint { get; set; }
    }
}
