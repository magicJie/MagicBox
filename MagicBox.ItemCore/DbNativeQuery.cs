using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicBox.ItemCore
{
   [Serializable]
    public class DbNativeQuery
    {
        private Dictionary<string, NamedSqlParameter> parameters;
        private string sql;
        
        public DbNativeQuery(string sql)
        {
            this.sql = sql;
            this.parameters = new Dictionary<string, NamedSqlParameter>();
        }
        
        public DbNativeQuery AddParameter(NamedSqlParameter parameter)
        {
            NamedSqlParameter parameter2;
            if (this.parameters.TryGetValue(parameter.Key, out parameter2))
            {
                this.parameters.Remove(parameter.Key);
            }
            this.parameters.Add(parameter.Key, parameter);
            return this;
        }
        
        public override string ToString()
        {
            return this.sql;
        }
        
        public Dictionary<string, NamedSqlParameter> Parameters
        {
            get
            {
                return this.parameters;
            }
        }
        
        public string SqlString
        {
            get
            {
                return this.sql;
            }
            set
            {
                this.sql = value;
            }
        }
    }
}
