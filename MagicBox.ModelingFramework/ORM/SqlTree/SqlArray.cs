using System.Collections;
using System.Collections.Generic;

namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 表示一组树节点合成的一个集合结点
    /// </summary>
    internal class SqlArray : SqlNode
    {
        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlArray; }
        }
        /// <summary>
        /// 所有项。其中每个项必须是一个SqlNode
        /// </summary>
        public IList Items { get; set; }

        internal SqlArray(bool initItems)
        {
            if(!initItems)return;
            Items = new List<SqlNode>();
        }

        internal SqlArray() : this(true)
        {
        }
    }
}
