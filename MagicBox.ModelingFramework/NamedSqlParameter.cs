using System;

namespace MagicBox.MF
{
    [Serializable]
    public class NamedSqlParameter
    {
        private string name;
        private object value;
        private string wisenseDataType;

        public NamedSqlParameter(string name, string wisenseDataType, object value)
        {
            this.name = name;
            this.wisenseDataType = wisenseDataType;
            this.value = value;
        }

        public string DataType
        {
            get
            {
                return this.wisenseDataType;
            }
        }

        public string Key
        {
            get
            {
                return this.name.ToUpper();
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public object Value
        {
            get
            {
                return this.value;
            }
        }
    }
}
