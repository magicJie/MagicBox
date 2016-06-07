namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 表示一段文本。
    /// </summary>
    internal class SqlLiteral : SqlConstraint
    {
        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlLiteral; }
        }
        /// <summary>
        /// Sql文本
        /// </summary>
        public string FormattedSql { get; set; }
        /// <summary>
        /// 对应的参数值列表
        /// </summary>
        public object[] Parameters { get; set; }
    }
}
