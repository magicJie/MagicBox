using System;
using System.Collections.Generic;

namespace MagicBox.MF
{
   [Serializable]
    public class DbNativeQuery
    {
        private Dictionary<string, NamedSqlParameter> _parameters;
        private string _sql;
        
        public DbNativeQuery(string sql)
        {
            _sql = sql;
            _parameters = new Dictionary<string, NamedSqlParameter>();
        }
        
        public DbNativeQuery AddParameter(NamedSqlParameter parameter)
        {
            NamedSqlParameter parameter2;
            if (_parameters.TryGetValue(parameter.Key, out parameter2))
            {
                _parameters.Remove(parameter.Key);
            }
            _parameters.Add(parameter.Key, parameter);
            return this;
        }
        
        public override string ToString()
        {
            return _sql;
        }
        
        public Dictionary<string, NamedSqlParameter> Parameters
        {
            get
            {
                return _parameters;
            }
        }
        
        public string SqlString
        {
            get
            {
                return _sql;
            }
            set
            {
                _sql = value;
            }
        }
    }
}
