namespace MagicBox.MF.ORM.SqlTree
{
    internal enum SqlNodeType
    {
        SqlLiteral,
        SqlArray,
        SqlSelect,
        SqlTable,
        SqlColumn,
        SqlJoin,
        SqlOrderBy,
        SqlSelectAll,
        SqlSubSelect,
        SqlColumnConstraint,
        SqlBinaryConstraint,
        SqlColumnsComparisonConstraint,
        SqlExistsConstraint,
        SqlNotConstraint
    }
}
