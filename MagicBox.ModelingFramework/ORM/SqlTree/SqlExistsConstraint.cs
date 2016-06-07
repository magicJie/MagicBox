namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 表示对指定的查询进行是否存在在查询行的判断
    /// </summary>
    internal class SqlExistsConstraint : SqlConstraint
    {
        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlExistsConstraint; }
        }
        /// <summary>
        /// 要检查的查询
        /// </summary>
        public SqlSelect Select { get; set; }
    }
}
