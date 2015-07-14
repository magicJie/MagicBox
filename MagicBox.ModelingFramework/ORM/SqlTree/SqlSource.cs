namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 可查询的数据源，可用于 From 语句之后 。
    ///             目前有：SqlTable、SqlJoin、SqlSubSelect。
    /// 
    /// </summary>
    internal abstract class SqlSource : SqlNode
    {
    }
}
