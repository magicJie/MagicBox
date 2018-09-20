using System.Diagnostics;
using System.IO;

namespace MagicBox.Data
{
    /// <summary>
    /// 格式化 Sql 构造器
    /// 
    ///             如果想直接面向 Sql 字符串进行操作，可以使用 Append 打头的方法，或者使用 InnerWriter 属性获取内部的 TextWriter 后再进行操作。
    /// 
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class FormattedSql
    {
        private FormattedSqlParameters _parameters = new FormattedSqlParameters();
        /// <summary>
        /// 最终生成的 Sql 字符串的 TextWriter
        /// 
        /// </summary>
        private TextWriter _sql;
        /// <summary>
        /// 内部使用的 TextWriter，可能被外部使用属性 InnerWriter 进行替换。
        /// 
        /// </summary>
        private TextWriter _writer;

        /// <summary>
        /// 当前可用的参数
        /// 
        /// </summary>
        public FormattedSqlParameters Parameters
        {
            get
            {
                return this._parameters;
            }
        }

        /// <summary>
        /// 获取内部的 TextWriter，用于直接面向字符串进行文本输出。
        ///             同时，也可以使用新的 TextWriter 来装饰当前的 TextWriter。
        /// 
        /// </summary>
        public TextWriter InnerWriter
        {
            get
            {
                return this._writer;
            }
            set
            {
                this._writer = value;
            }
        }

        private string DebuggerDisplay
        {
            get
            {
                return this._sql.ToString() + "\r\n\r\nParameters: " + this._parameters.ToString();
            }
        }

        public FormattedSql()
        {
            this._sql = (TextWriter)new StringWriter();
            this._writer = this._sql;
        }

        public static implicit operator string(FormattedSql value)
        {
            return value._sql.ToString();
        }

        public static implicit operator FormattedSql(string value)
        {
            FormattedSql formattedSql = new FormattedSql();
            formattedSql._writer.Write(value);
            return formattedSql;
        }

        public static FormattedSql operator +(FormattedSql writer, string value)
        {
            writer._writer.Write(value);
            return writer;
        }

        /// <summary>
        /// 写入一个参数值。
        /// 
        /// </summary>
        /// <param name="value"/>
        public FormattedSql AppendParameter(object value)
        {
            this._parameters.WriteParameter(this._writer, value);
            return this;
        }

        /// <summary>
        /// 直接添加 " AND "。
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public FormattedSql AppendAnd()
        {
            this._writer.Write(" AND ");
            return this;
        }

        /// <summary>
        /// 直接添加 " OR "。
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public FormattedSql AppendOr()
        {
            this._writer.Write(" OR ");
            return this;
        }

        /// <summary>
        /// 直接添加指定的字符串。
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public FormattedSql Append(string value)
        {
            this._writer.Write(value);
            return this;
        }

        /// <summary>
        /// 直接添加指定的 char 值。
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public FormattedSql Append(char value)
        {
            this._writer.Write(value);
            return this;
        }

        /// <summary>
        /// 直接添加指定的 int 值。
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public FormattedSql Append(int value)
        {
            this._writer.Write(value);
            return this;
        }

        /// <summary>
        /// 直接添加指定的 double 值。
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public FormattedSql Append(double value)
        {
            this._writer.Write(value);
            return this;
        }

        /// <summary>
        /// 直接添加指定的 object 值。
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public FormattedSql Append(object value)
        {
            this._writer.Write(value);
            return this;
        }

        /// <summary>
        /// 直接添加指定的 bool 值。
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public FormattedSql Append(bool value)
        {
            this._writer.Write(value);
            return this;
        }

        /// <summary>
        /// 直接添加指定的字符串值，并添加回车。
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public FormattedSql AppendLine(string value)
        {
            this._writer.WriteLine(value);
            return this;
        }

        /// <summary>
        /// 添加回车
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public FormattedSql AppendLine()
        {
            this._writer.WriteLine();
            return this;
        }

        public override string ToString()
        {
            return this._sql.ToString();
        }
    }
}
