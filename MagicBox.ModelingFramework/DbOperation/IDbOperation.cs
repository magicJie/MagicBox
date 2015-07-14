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
    /// <summary>
    /// 定义了数据库通用的操作
    /// </summary>
    public interface IDbOperation
    {
        #region Propertity

        DatabaseType DatabaseType { get; }
        String ConnectingString { get; }

        #endregion Propertity

        #region Method

        object ExecuteScalar(string sql);
        int ExecuteNonQuery();
        IDataReader ExecuteReader();
        IAsyncResult BeginExecuteNonQuery();
        IAsyncResult BeginExecuteReader();
        int EndExecuteNonQuery(IAsyncResult asyncResult);
        IAsyncResult EndExecuteReader(IAsyncResult asyncResult);

        #endregion Method
    }
    public enum DatabaseType
    {
        Oracle,
        MySql,
        MsSqlServer,
        Db2
    }
}
