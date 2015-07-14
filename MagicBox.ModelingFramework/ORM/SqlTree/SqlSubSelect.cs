namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 子查询。对一个子查询分配别名后，可作为一个新的数据源
    /// </summary>
    internal class SqlSubSelect : SqlNamedSource
    {
        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlSubSelect; }
        }
        /// <summary>
        /// 子查询
        /// </summary>
        public SqlSelect Select { get; set; }
        /// <summary>
        /// 别名，必须
        /// </summary>
        public string Alias { get; set; }
        internal override string GetName()
        {
            return Alias;
        }
    }
}
