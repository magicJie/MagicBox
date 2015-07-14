﻿namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 表示一个具体的表
    /// </summary>
    internal class SqlTable : SqlNamedSource
    {
        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlTable; }
        }
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 查询中使用的别名
        /// </summary>
        public string  Alias { get; set; }

        internal override string GetName()
        {
            return Alias ?? TableName;
        }
    }
}
