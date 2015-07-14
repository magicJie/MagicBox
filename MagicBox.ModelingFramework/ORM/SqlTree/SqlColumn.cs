namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 表示某个表、或者查询结果中的某一列
    /// </summary>
    internal class SqlColumn : SqlNode
    {
        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlColumn; }
        }
        /// <summary>
        /// 只能是<see cref="T:MagicBox.MF.ORM.SqlTree.SqlTable"/>、<see cref="T:MagicBox.MF.ORM.SqlTree.SqlSubSelect"/>
        /// </summary>
        public SqlNamedSource Table { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 别名。列的别名只能用在Select语句之后
        /// </summary>
        public string Alias { get; set; }
    }
}
