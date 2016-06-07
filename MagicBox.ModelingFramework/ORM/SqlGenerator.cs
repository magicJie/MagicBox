using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Text.RegularExpressions;
using MagicBox.Common.Data;
using MagicBox.MF.ORM.SqlTree;

namespace MagicBox.MF.ORM
{
    /// <summary>
    /// 为SqlNode语法树生成相应Sql的生成器
    /// </summary>
    internal abstract class SqlGenerator : SqlNodeVisitor
    {
        private FormattedSql _sql;

        /// <summary>
        /// 当前需要的缩进量
        /// </summary>
        protected int Indent {
            get
            {
                var innerWriter = _sql.InnerWriter as IndentedTextWriter;
                return innerWriter == null ? 0 : innerWriter.Indent;
            }
            set
            {
                var innerWriter = _sql.InnerWriter as IndentedTextWriter;
                if (innerWriter != null) 
                    innerWriter.Indent = value;
            }
        }
        /// <summary>
        /// 是否自动添加标示符的括号
        /// </summary>
        public bool AutoQuota { get; set; }
        /// <summary>
        /// 生成完毕后的Sql语句及参数
        /// </summary>
        public FormattedSql Sql {
            get { return _sql; }
        }

        public SqlGenerator()
        {
            _sql=new FormattedSql();
            _sql.InnerWriter = new IndentedTextWriter(_sql.InnerWriter);
            AutoQuota = true;
        }
        /// <summary>
        /// 为指定的原始查询生成指定分页效果的新查询
        /// </summary>
        /// <param name="raw">原始查询</param>
        /// <param name="pkColumn">需要指定的主键列</param>
        /// <param name="pagingInfo">分页信息</param>
        /// <returns></returns>
        public virtual SqlSelect ModifyToPagingTree(SqlSelect raw, SqlColumn pkColumn, PagingInfo pagingInfo)
        {
            if(PagingInfo.IsNullOrEmpty(pagingInfo))
                throw new ArgumentException("pagingInfo");
            if(!raw.HasOrdered())
                throw new InvalidProgramException("必须排序后才能使用分页功能");
            if (pagingInfo.PageNumber == 1)
            {
                raw.Top = pagingInfo.PageSize;
                return raw;
            }
            var sqlSelect1 = new SqlSelect
            {
                Top = (pagingInfo.PageNumber - 1)*pagingInfo.PageSize,
                Selection = pkColumn,
                From = raw.From,
                Where = raw.Where,
                OrderBy = raw.OrderBy
            };
            var sqlSelect2 = new SqlSelect
            {
                Top = pagingInfo.PageSize,
                Selection = raw.Selection,
                From = raw.From,
                OrderBy = raw.OrderBy
            };
            SqlColumnConstraint columnConstraint = new SqlColumnConstraint
            {
                Column = pkColumn,
                Operator = SqlColumnConstraintOperator.NotIn,
                Value = sqlSelect1
            };
            if (raw.Where != null)
                sqlSelect2.Where = new SqlBinaryConstraint
                {
                    Left = raw.Where,
                    Operator = SqlBinaryConstraintType.And,
                    Right = columnConstraint
                };
            else
                sqlSelect2.Where = columnConstraint;
            return sqlSelect2;
        }
        /// <summary>
        /// 访问sql语法树中的每一个节点，并生成相应的Sql语句
        /// </summary>
        /// <param name="tree"></param>
        public void Generate(SqlNode tree)
        {
            Visit(tree);
        }

        protected override SqlLiteral VisitSqlLiteral(SqlLiteral sqlLiteral)
        {
            if (sqlLiteral.Parameters != null && sqlLiteral.Parameters.Length > 0)
                sqlLiteral.FormattedSql = Regex.Replace(sqlLiteral.FormattedSql, "\\{(?<index>\\d+)\\}",
                    m => "{" + _sql.Parameters.Add(sqlLiteral.Parameters[Convert.ToInt32(m.Groups["index"].Value)]) +
                         "}");
            _sql.Append(sqlLiteral.FormattedSql);
            return sqlLiteral;
        }

        protected override SqlBinaryConstraint VisitSqlBinaryConstraint(SqlBinaryConstraint node)
        {
            SqlBinaryConstraint binaryConstraint1 = node.Left as SqlBinaryConstraint;
            SqlBinaryConstraint binaryConstraint2 = node.Right as SqlBinaryConstraint;
            bool flag1 = binaryConstraint1 != null && binaryConstraint1.Operator == SqlBinaryConstraintType.Or;
            bool flag2 = binaryConstraint2 != null && binaryConstraint2.Operator == SqlBinaryConstraintType.Or;
            switch (node.Operator)
            {
                case SqlBinaryConstraintType.And:
                    if (flag1)
                        _sql.Append("(");
                    Visit(node.Left);
                    if (flag1)
                        _sql.Append(")");
                    _sql.AppendAnd();
                    if (flag2)
                        _sql.Append("(");
                    Visit(node.Right);
                    if (flag2)
                        _sql.Append(")");
                    break;
                case SqlBinaryConstraintType.Or:
                    Visit(node.Left);
                    _sql.AppendOr();
                    Visit(node.Right);
                    break;
                default:
                    throw new NotSupportedException();
            }
            return node;
        }

        protected override SqlSelect VisitSqlSelect(SqlSelect sqlSelect)
        {
            _sql.Append("SELECT");
            if (sqlSelect.IsCounting)
                _sql.Append("COUNT(0)");
            else
            {
                if (sqlSelect.IsDistinct)
                    _sql.Append("DISTINCT");
                else if(sqlSelect.Top.HasValue)
                {
                    _sql.Append("TOP ");//注意这里使用top关键字不符合数据库通用标准，比如Oracle就不支持使用top
                    _sql.Append(sqlSelect.Top.Value);
                    _sql.Append(" ");
                }
                if (sqlSelect.Selection == null)
                    _sql.Append("*");
                else
                    Visit(sqlSelect.Selection);
            }
            _sql.AppendLine();
            _sql.Append("FROM");
            Visit(sqlSelect.From);
            if (sqlSelect.Where != null)
            {
                _sql.AppendLine();
                _sql.Append("WHERE ");
                Visit(sqlSelect.Where);
            }
            if (!sqlSelect.IsCounting && sqlSelect.OrderBy != null && sqlSelect.OrderBy.Count > 0)
            {
                _sql.AppendLine();
                _sql.Append("ORDER BY ");
                var count = sqlSelect.OrderBy.Count;
                for (int index = 0; index < count; index++)
                {
                    if (index > 0)
                        _sql.Append(", ");
                    Visit(sqlSelect.OrderBy[index] as SqlOrderBy);
                }

            }
            return sqlSelect;
        }

        protected override SqlColumn VisitSqlColumn(SqlColumn sqlColumn)
        {
            AppendColumnDeclaration(sqlColumn);
            return sqlColumn;
        }

        protected override SqlTable VisitSqlTable(SqlTable sqlTable)
        {
            QuoteAppend(sqlTable.TableName);
            if (!String.IsNullOrEmpty(sqlTable.Alias))
            {
                _sql.Append(" AS ");
                QuoteAppend(sqlTable.Alias);
            }
            return sqlTable;
        }

        protected override SqlJoin VisitSqlJoin(SqlJoin sqlJoin)
        {
            Visit(sqlJoin.Left);
            switch (sqlJoin.JoinType)
            {
                case SqlJoinType.Inner:
                    _sql.AppendLine();
                    ++Indent;
                    _sql.Append("INNER JOIN ");
                    --Indent;
                    break;
                case SqlJoinType.LeftOuter:
                    _sql.AppendLine();
                    ++Indent;
                    _sql.Append("LEFT OUTER JOIN ");
                    --Indent;
                    break;
                default:
                    throw new NotSupportedException();
            }
            Visit(sqlJoin.Right);
            _sql.Append(" ON　");
            Visit(sqlJoin.Condition);
            return sqlJoin;
        }

        protected override SqlArray VisitSqlArray(SqlArray sqlArray)
        {
            var count = sqlArray.Items.Count;
            for (int i = 0; i < count; i++)
            {
                var node = sqlArray.Items[i] as SqlNode;
                if (i > 0)
                    _sql.Append(", ");
                Visit(node);
            }
            return sqlArray;
        }

        protected override SqlColumnConstraint VisitSqlColumnConstraint(SqlColumnConstraint node)
        {
            SqlColumnConstraintOperator @operator = node.Operator;
            object obj1 = node.Value;
            switch (@operator)
            {
                case SqlColumnConstraintOperator.Like:
                case SqlColumnConstraintOperator.Contains:
                case SqlColumnConstraintOperator.StartsWith:
                case SqlColumnConstraintOperator.EndsWith:
                    if (string.IsNullOrEmpty(obj1 as string))
                    {
                        _sql.Append("1 = 1");
                        return node;
                    }
                    break;
                case SqlColumnConstraintOperator.NotLike:
                case SqlColumnConstraintOperator.NotContains:
                case SqlColumnConstraintOperator.NotStartsWith:
                case SqlColumnConstraintOperator.NotEndsWith:
                    if (string.IsNullOrEmpty(obj1 as string))
                    {
                        _sql.Append("1 != 1");
                        return node;
                    }
                    break;
                case SqlColumnConstraintOperator.In:
                case SqlColumnConstraintOperator.NotIn:
                    var enumerable = obj1 as IEnumerable;
                    if (enumerable != null)
                    {
                        bool flag = false;
                        IEnumerator enumerator = enumerable.GetEnumerator();
                        try
                        {
                            if (enumerator.MoveNext())
                            {
                                object current = enumerator.Current;
                                flag = true;
                            }
                        }
                        finally
                        {
                            IDisposable disposable = enumerator as IDisposable;
                            if (disposable != null)
                                disposable.Dispose();
                        }
                        if (!flag)
                        {
                            if (@operator == SqlColumnConstraintOperator.In)
                                _sql.Append("0 = 1");
                            else
                                _sql.Append("1 = 1");
                            return node;
                        }
                    }
                    break;
            }
            AppendColumnUsage(node.Column);
            switch (@operator)
            {
                case SqlColumnConstraintOperator.Equal:
                    if (obj1 == null || obj1 == DBNull.Value)
                    {
                        _sql.Append(" IS NULL");
                        break;
                    }
                    _sql.Append(" = ");
                    _sql.AppendParameter(obj1);
                    break;
                case SqlColumnConstraintOperator.NotEqual:
                    if (obj1 == null || obj1 == DBNull.Value)
                    {
                        _sql.Append(" IS NOT NULL");
                        break;
                    }
                    _sql.Append(" != ");
                    _sql.AppendParameter(obj1);
                    break;
                case SqlColumnConstraintOperator.Greater:
                    _sql.Append(" > ");
                    _sql.AppendParameter(obj1);
                    break;
                case SqlColumnConstraintOperator.GreaterEqual:
                    _sql.Append(" >= ");
                    _sql.AppendParameter(obj1);
                    break;
                case SqlColumnConstraintOperator.Less:
                    _sql.Append(" < ");
                    _sql.AppendParameter(obj1);
                    break;
                case SqlColumnConstraintOperator.LessEqual:
                    _sql.Append(" <= ");
                    _sql.AppendParameter(obj1);
                    break;
                case SqlColumnConstraintOperator.Like:
                    _sql.Append(" LIKE ");
                    _sql.AppendParameter(obj1);
                    break;
                case SqlColumnConstraintOperator.NotLike:
                    _sql.Append(" NOT LIKE ");
                    _sql.AppendParameter(obj1);
                    break;
                case SqlColumnConstraintOperator.Contains:
                    _sql.Append(" LIKE ");
                    _sql.AppendParameter("%" + obj1 + "%");
                    break;
                case SqlColumnConstraintOperator.NotContains:
                    _sql.Append(" NOT LIKE ");
                    _sql.AppendParameter("%" + obj1 + "%");
                    break;
                case SqlColumnConstraintOperator.StartsWith:
                    _sql.Append(" LIKE ");
                    _sql.AppendParameter((string)obj1 + (object)"%");
                    break;
                case SqlColumnConstraintOperator.NotStartsWith:
                    _sql.Append(" NOT LIKE ");
                    _sql.AppendParameter((string)obj1 + (object)"%");
                    break;
                case SqlColumnConstraintOperator.EndsWith:
                    _sql.Append(" LIKE ");
                    _sql.AppendParameter("%" + obj1);
                    break;
                case SqlColumnConstraintOperator.NotEndsWith:
                    _sql.Append(" NOT LIKE ");
                    _sql.AppendParameter("%" + obj1);
                    break;
                case SqlColumnConstraintOperator.In:
                case SqlColumnConstraintOperator.NotIn:
                    _sql.Append(" ").Append(@operator == SqlColumnConstraintOperator.In ? "IN" : "NOT IN").Append(" (");
                    if (obj1 is IEnumerable)
                    {
                        bool flag1 = true;
                        bool flag2 = false;
                        foreach (object obj2 in obj1 as IEnumerable)
                        {
                            if (flag1)
                            {
                                flag1 = false;
                                flag2 = obj2 is string || obj2 is DateTime;
                            }
                            else
                                _sql.Append(',');
                            if (flag2)
                                _sql.Append('\'').Append(obj2).Append('\'');
                            else
                                _sql.Append(obj2);
                        }
                    }
                    else if (obj1 is SqlNode)
                    {
                        _sql.AppendLine();
                        ++Indent;
                        Visit(obj1 as SqlNode);
                        --Indent;
                        _sql.AppendLine();
                    }
                    _sql.Append(')');
                    break;
                default:
                    throw new NotSupportedException();
            }
            return node;
        }

        protected override SqlSelectAll VisitSqlSelectAll(SqlSelectAll sqlSelectStar)
        {
            if (sqlSelectStar.Table != null)
            {
                QuoteAppend(sqlSelectStar.Table.GetName());
                _sql.Append(".*");
            }
            else
                _sql.Append("*");
            return sqlSelectStar;
        }

        protected override SqlColumnsComparisonConstraint VisitSqlColumnsComparisonConstraint(SqlColumnsComparisonConstraint node)
        {
            AppendColumnUsage(node.LeftColumn);
            switch (node.Operator)
            {
                case SqlColumnConstraintOperator.Equal:
                    _sql.Append(" = ");
                    break;
                case SqlColumnConstraintOperator.NotEqual:
                    _sql.Append(" != ");
                    break;
                case SqlColumnConstraintOperator.Greater:
                    _sql.Append(" > ");
                    break;
                case SqlColumnConstraintOperator.GreaterEqual:
                    _sql.Append(" >= ");
                    break;
                case SqlColumnConstraintOperator.Less:
                    _sql.Append(" < ");
                    break;
                case SqlColumnConstraintOperator.LessEqual:
                    _sql.Append(" <= ");
                    break;
                default:
                    throw new NotSupportedException("两个属性之间的对比，只能使用 6 类基本对比。");
            }
            AppendColumnUsage(node.RightColumn);
            return node;
        }

        protected override SqlExistsConstraint VisitSqlExistsConstraint(SqlExistsConstraint sqlExistsConstraint)
        {
            _sql.Append("EXISTS (");
            _sql.AppendLine();
            ++Indent;
            Visit(sqlExistsConstraint.Select);
            --Indent;
            _sql.AppendLine();
            _sql.Append(")");
            return sqlExistsConstraint;
        }

        protected override SqlNotConstraint VisitSqlNotConstraint(SqlNotConstraint sqlNotConstraint)
        {
            _sql.Append("NOT (");
            Visit(sqlNotConstraint.Constraint);
            _sql.Append(")");
            return sqlNotConstraint;
        }

        protected override SqlSubSelect VisitSqlSubSelect(SqlSubSelect sqlSelectRef)
        {
            _sql.Append("(");
            _sql.AppendLine();
            ++Indent;
            Visit(sqlSelectRef.Select);
            --Indent;
            _sql.AppendLine();
            _sql.Append(") AS ");
            _sql.Append(sqlSelectRef.Alias);
            return sqlSelectRef;
        }

        protected override SqlOrderBy VisitSqlOrderBy(SqlOrderBy sqlOrderBy)
        {
            AppendColumnUsage(sqlOrderBy.Column);
            _sql.Append(" ");
            _sql.Append(sqlOrderBy.Direction == OrderDirection.Ascending ? "ASC" : "DESC");
            return sqlOrderBy;
        }

        /// <summary>
        /// 把标识符添加到 Sql 语句中。
        ///             子类可重写此方法来为每一个标识符添加引用符。
        ///             SqlServer 生成 [identifier]
        ///             Oracle 生成 "IDENTIFIER"
        /// 
        /// </summary>
        /// <param name="identifier"/>
        protected virtual void QuoteAppend(string identifier)
        {
            identifier = PrepareIdentifier(identifier);
            _sql.Append(identifier);
        }

        /// <summary>
        /// 准备所有标识符。
        ///             Oracle 可重写此方法，使得标识符都是大写的。
        /// 
        /// </summary>
        /// <param name="identifier"/>
        /// <returns/>
        protected virtual string PrepareIdentifier(string identifier)
        {
            return identifier;
        }

        private void AppendColumnDeclaration(SqlColumn sqlColumn)
        {
            QuoteAppend(sqlColumn.Table.GetName());
            _sql.Append(".");
            QuoteAppend(sqlColumn.ColumnName);
            if (string.IsNullOrEmpty(sqlColumn.Alias))
                return;
            _sql.Append(" AS ");
            QuoteAppend(sqlColumn.Alias);
        }

        private void AppendColumnUsage(SqlColumn sqlColumn)
        {
            QuoteAppend(sqlColumn.Table.GetName());
            _sql.Append(".");
            QuoteAppend(sqlColumn.ColumnName);
        }
    }
}
