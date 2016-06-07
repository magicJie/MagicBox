namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 表示两个列进行对比的约束条件
    /// </summary>
    internal class SqlColumnsComparisonConstraint : SqlConstraint
    {
        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlColumnsComparisonConstraint; }
        }

        /// <summary>
        /// 第一个待对比的列
        /// </summary>
        public SqlColumn LeftColumn { get; set; }

        /// <summary>
        /// 第二个待对比的列
        /// </summary>
        public SqlColumn RightColumn { get; set; }

        /// <summary>
        /// 对比条件
        /// </summary>
        public SqlColumnConstraintOperator Operator { get; set; }

        public SqlColumnsComparisonConstraint()
        {
            Operator = SqlColumnConstraintOperator.Equal;
        }
    }
}
