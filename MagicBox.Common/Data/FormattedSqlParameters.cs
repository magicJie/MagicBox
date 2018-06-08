using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MagicBox.Data
{
    /// <summary>
    /// FormattedSql 中的参数列表封装
    /// 
    /// </summary>
    public class FormattedSqlParameters
    {
        private List<object> _parameters = new List<object>();

        /// <summary>
        /// 获取指定位置的参数值
        /// 
        /// </summary>
        /// <param name="index"/>
        /// <returns/>
        public object this[int index]
        {
            get
            {
                return this._parameters[index];
            }
        }

        /// <summary>
        /// 当前参数的个数
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                return this._parameters.Count;
            }
        }

        /// <summary>
        /// 隐式操作符，使得本类的对象可以直接当作 object[] 使用。方便 DBA 类型的操作。
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public static implicit operator object[](FormattedSqlParameters value)
        {
            return value._parameters.ToArray();
        }

        /// <summary>
        /// 添加一个参数，并返回该参数应该使用的索引号
        /// 
        ///             当在 Sql 中直接写入 {0} 时，可以使用本方法直接添加一个参数到参数列表中。
        /// 
        /// </summary>
        /// <param name="value"/>
        /// <returns/>
        public int Add(object value)
        {
            this._parameters.Add(value);
            return this._parameters.Count - 1;
        }

        /// <summary>
        /// 添加一个参数，并在 SQL 中添加相应的索引号
        /// 
        /// </summary>
        /// <param name="sql"/><param name="value"/>
        /// <returns/>
        internal void WriteParameter(StringBuilder sql, object value)
        {
            this._parameters.Add(value);
            int num = this._parameters.Count - 1;
            sql.Append('{').Append(num).Append('}');
        }

        /// <summary>
        /// 添加一个参数，并在 SQL 中添加相应的索引号
        /// 
        /// </summary>
        /// <param name="sql"/><param name="value"/>
        /// <returns/>
        internal void WriteParameter(TextWriter sql, object value)
        {
            this._parameters.Add(value);
            int num = this._parameters.Count - 1;
            sql.Write('{');
            sql.Write(num);
            sql.Write('}');
        }

        /// <summary>
        /// 按照添加时的索引，返回所有的参数值数组。
        ///             此数组可以直接使用在 DBAccesser 方法中。
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public object[] ToArray()
        {
            return this._parameters.ToArray();
        }

        public override string ToString()
        {
            return string.Join<object>(",", (IEnumerable<object>)this._parameters);
        }
    }
}
