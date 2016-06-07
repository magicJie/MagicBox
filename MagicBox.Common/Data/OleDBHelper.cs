using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HGBS.Lib
{
    public class OleDBHelper
    {
        private string connStr;

        public OleDBHelper(string connStr)
        {
            // TODO: Complete member initialization
            this.connStr = connStr;
        }

        public System.Data.DataTable GetTable(string sqlStr)
        {
            throw new NotImplementedException();
        }
    }
}
