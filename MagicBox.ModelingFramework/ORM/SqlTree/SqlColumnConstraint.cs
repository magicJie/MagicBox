namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 表示某个列与某个值进行对比的约束条件。
    /// 
    /// </summary>
    internal class SqlColumnConstraint : SqlConstraint
    {
        public override SqlNodeType NodeType
        {
            get
            {
                return SqlNodeType.SqlColumnConstraint;
            }
        }

        /// <summary>
        /// 要对比的列。
        /// 
        /// </summary>
        public SqlColumn Column { get; set; }

        /// <summary>
        /// 对比操作符
        /// 
        /// </summary>
        public SqlColumnConstraintOperator Operator { get; set; }

        /// <summary>
        /// 要对比的值。
        /// 
        /// </summary>
        public object Value { get; set; }
    }
}
