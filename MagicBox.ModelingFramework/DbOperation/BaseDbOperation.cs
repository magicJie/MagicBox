#region License

/*
 * Copyright 2002-2010 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.MF.DbOperation
{
    public class BaseDbOperation:IDbOperation
    {
        #region Field
        #endregion Field

        #region Propertity
        #endregion Propertity

        #region Method
        #endregion Method

        #region Constructor
        #endregion Constructor

        public DatabaseType DatabaseType
        {
            get { throw new NotImplementedException(); }
        }

        public string ConnectingString
        {
            get { throw new NotImplementedException(); }
        }

        public object ExecuteScalar(string sql)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public IDataReader ExecuteReader()
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginExecuteReader()
        {
            throw new NotImplementedException();
        }

        public int EndExecuteNonQuery(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult EndExecuteReader(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }
    }
}
