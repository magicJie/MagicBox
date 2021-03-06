﻿namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 用于表示选择所有列、或者表示选择某个表的所有列
    /// </summary>
    internal class SqlSelectAll : SqlNode
    {
        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlSelectAll; }
        }
        /// <summary>
        /// 若此属性为空，表示选择所有数据源的所有列；否则表示指定的列
        /// </summary>
        public SqlNamedSource Table { get; set; }
    }
}
