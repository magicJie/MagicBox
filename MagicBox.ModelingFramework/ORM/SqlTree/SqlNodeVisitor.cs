using System;

namespace MagicBox.MF.ORM.SqlTree
{
    /// <summary>
    /// SqlNode语法树访问器
    /// </summary>
    internal abstract class SqlNodeVisitor
    {
        protected SqlNode Visit(SqlNode node)
        {
            switch (node.NodeType)
            {
                case SqlNodeType.SqlLiteral:
                    return VisitSqlLiteral(node as SqlLiteral);
                case SqlNodeType.SqlArray:
                    return VisitSqlArray(node as SqlArray);
                case SqlNodeType.SqlSelect:
                    return VisitSqlSelect(node as SqlSelect);
                case SqlNodeType.SqlTable:
                    return VisitSqlTable(node as SqlTable);
                case SqlNodeType.SqlColumn:
                    return VisitSqlColumn(node as SqlColumn);
                case SqlNodeType.SqlJoin:
                    return VisitSqlJoin(node as SqlJoin);
                case SqlNodeType.SqlOrderBy:
                    return VisitSqlOrderBy(node as SqlOrderBy);
                case SqlNodeType.SqlSelectAll:
                    return VisitSqlSelectAll(node as SqlSelectAll);
                case SqlNodeType.SqlSubSelect:
                    return VisitSqlSubSelect(node as SqlSubSelect);
                case SqlNodeType.SqlColumnConstraint:
                    return VisitSqlColumnConstraint(node as SqlColumnConstraint);
                case SqlNodeType.SqlBinaryConstraint:
                    return VisitSqlBinaryConstraint(node as SqlBinaryConstraint);
                case SqlNodeType.SqlColumnsComparisonConstraint:
                    return VisitSqlColumnsComparisonConstraint(node as SqlColumnsComparisonConstraint);
                case SqlNodeType.SqlExistsConstraint:
                    return VisitSqlExistsConstraint(node as SqlExistsConstraint);
                case SqlNodeType.SqlNotConstraint:
                    return VisitSqlNotConstraint(node as SqlNotConstraint);
                default:
                    throw new NotImplementedException();
            }
        }

        protected virtual SqlJoin VisitSqlJoin(SqlJoin sqlJoin)
        {
            Visit(sqlJoin.Left);
            Visit(sqlJoin.Right);
            Visit(sqlJoin.Condition);
            return sqlJoin;
        }

        protected virtual SqlBinaryConstraint VisitSqlBinaryConstraint(SqlBinaryConstraint node)
        {
            Visit(node.Left);
            Visit(node.Right);
            return node;
        }

        protected virtual SqlSelect VisitSqlSelect(SqlSelect sqlSelect)
        {
            if (sqlSelect.Selection != null)
                Visit(sqlSelect.Selection);
            Visit(sqlSelect.From);
            if (sqlSelect.Where != null)
                Visit(sqlSelect.Where);
            if (sqlSelect.HasOrdered())
            {
                int count = sqlSelect.OrderBy.Count;                
                for ( var index = 0;index < count; ++index)
                    Visit(sqlSelect.OrderBy[index] as SqlNode);
            }
            return sqlSelect;
        }

        protected virtual SqlTable VisitSqlTable(SqlTable sqlTable)
        {
            return sqlTable;
        }
        protected virtual SqlColumn VisitSqlColumn(SqlColumn sqlColumn)
        {
            return sqlColumn;
        }
        protected virtual SqlColumnConstraint VisitSqlColumnConstraint(SqlColumnConstraint sqlColumnConstraint)
        {
            Visit(sqlColumnConstraint.Column);
            return sqlColumnConstraint;
        }

        protected virtual SqlLiteral VisitSqlLiteral(SqlLiteral sqlLiteral)
        {
            return sqlLiteral;
        }

        protected virtual SqlArray VisitSqlArray(SqlArray sqlArray)
        {
            int count = sqlArray.Items.Count;            
            for (var index = 0; index < count; ++index)
                Visit(sqlArray.Items[index] as SqlNode);
            return sqlArray;
        }

        protected virtual SqlSelectAll VisitSqlSelectAll(SqlSelectAll sqlSelectAll)
        {
            return sqlSelectAll;
        }

        protected virtual SqlColumnsComparisonConstraint VisitSqlColumnsComparisonConstraint(
            SqlColumnsComparisonConstraint sqlColumnsComparisonConstraint)
        {
            Visit(sqlColumnsComparisonConstraint.LeftColumn);
            Visit(sqlColumnsComparisonConstraint.RightColumn);
            return sqlColumnsComparisonConstraint;
        }

        protected virtual SqlExistsConstraint VisitSqlExistsConstraint(SqlExistsConstraint sqlExistsConstraint)
        {
            Visit(sqlExistsConstraint.Select);
            return sqlExistsConstraint;
        }

        protected virtual SqlNotConstraint VisitSqlNotConstraint(SqlNotConstraint sqlNotConstraint)
        {
            Visit(sqlNotConstraint.Constraint);
            return sqlNotConstraint;
        }

        protected virtual SqlSubSelect VisitSqlSubSelect(SqlSubSelect subSelect)
        {
            Visit(subSelect.Select);
            return subSelect;
        }

        protected virtual SqlOrderBy VisitSqlOrderBy(SqlOrderBy sqlOrderBy)
        {
            return sqlOrderBy;
        }
    }
}
