using System.Collections;

namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 表示一个Sql查询语句
    /// </summary>
    internal class SqlSelect : SqlNode
    {
        private IList _orderBy; 

        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlSelect; }
        }
        /// <summary>
        /// 是否只查询数据条数，如果这个属性为真，那么不再需要使用Selection
        /// </summary>
        public bool IsCounting { get; set; }
        /// <summary>
        /// 是否需要查询不同结果
        /// </summary>
        public bool IsDistinct { get; set; }
        /// <summary>
        /// 此属性为真，表示需要查询条数。
        /// <remarks>注意这里有隐患！Oracle不支持使用top</remarks>
        /// </summary>
        public int? Top { get; set; }

        /// <summary>
        /// 要查询的内容。如果此属性为空，表示查询所有列
        /// </summary>
        public SqlNode Selection { get; set; }
        /// <summary>
        /// 要查询的数据源
        /// </summary>
        public SqlSource From { get; set; }
        /// <summary>
        /// 查询的过滤条件
        /// </summary>
        public SqlConstraint Where { get; set; }
        /// <summary>
        /// 查询排序规则。可以指定多个排序条件，其中每一项都必须是一个SqlOrderBy对象
        /// </summary>
        public IList OrderBy
        {
            get { return _orderBy ?? (_orderBy = new ArrayList()); }
            internal set { _orderBy = value; }
        }

        internal bool HasOrdered()
        {
            return _orderBy != null && _orderBy.Count > 0;
        }
    }
}
