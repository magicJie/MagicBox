namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 表示作用于两个操作结点的二位运算结点
    /// </summary>
    internal class SqlBinaryConstraint : SqlConstraint
    {
        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlBinaryConstraint; }
        }
        /// <summary>
        /// 二位运算的左操作节点
        /// </summary>
        public SqlConstraint Left { get; set; }
        /// <summary>
        /// 二位运算类型
        /// </summary>
        public SqlBinaryConstraintType Operator { get; set; }
        /// <summary>
        /// 二位运算右操作节点
        /// </summary>
        public SqlConstraint Right { get; set; }
    }

    /// <summary>
    /// 二位运算类型
    /// </summary>
    internal enum SqlBinaryConstraintType
    {
        And,
        Or
    }
}
