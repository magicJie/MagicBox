namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// 对比操作符
    /// 
    /// </summary>
    internal enum SqlColumnConstraintOperator
    {
        Equal,
        NotEqual,
        Greater,
        GreaterEqual,
        Less,
        LessEqual,
        Like,
        NotLike,
        Contains,
        NotContains,
        StartsWith,
        NotStartsWith,
        EndsWith,
        NotEndsWith,
        In,
        NotIn
    }
}
