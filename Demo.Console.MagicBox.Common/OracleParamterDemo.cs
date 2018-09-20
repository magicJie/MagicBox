using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
using System.IO;

namespace Demo.Console.MagicBox.
{
    public class OracleParamterDemo
    {
        public static void Test()
        {
            const string sqlStr =
                "insert into \"DB_UPGRADE_SCRIPT_LOG\" ( " +
                "\"ABSTRACT\" ,\"HASHCODE\" ,\"NAME\" ,\"LOGTYPE\" ,\"LOGTYPE_ITI\" ," +
                "\"DESCRIPTION\",\"ITEM_TYPE_ID\" ,\"ID\" ,\"CREATED_ON\" ,\"CREATED_BY_ID\" ," +
                "\"CREATED_BY_ID_ITI\" ,\"MODIFIED_ON\" ,\"MODIFIED_BY_ID\" ,\"MODIFIED_BY_ID_ITI\" ,\"STATE\" ," +
                "\"STATE_ITI\" ,\"IS_CURRENT\" ,\"IS_RELEASED\" ,\"NOT_LOCKABLE\" ,\"GENERATION\" ," +
                "\"NEW_VERSION\" ,\"CONFIG_ID\" ,\"CONFIG_ID_ITI\" ,\"LAYER\" ,\"LAYER_ITI\" ) " +
                "values (" +
                "'{0}' ,'{1}' ,'{2}' ,'{3}' ,'8651DCAB4D714EF6AA747BB8F50719BA' ," +
                "'{4}','E17603E59E11458B821AE7D92D6E85F5' ,'{5}',:\"CREATED_ON\" ,'430180A86E644C3DA113D38389C71E2B' ," +
                "'45E899CD2859442982EB22BB2DF683E5' ,:\"MODIFIED_ON\" ,'430180A86E644C3DA113D38389C71E2B' ,'45E899CD2859442982EB22BB2DF683E5' ,'25BF3959E757414F97E0E4CCA971E714' ," +
                "'5EFB53D35BAE468B851CD388BEA46B30' ,'0' ,'0' ,'0' ,'0' ," +
                "'0' ,'151A4427234A407DB19C1F595E71CEA2' ,'E17603E59E11458B821AE7D92D6E85F5' ,'E4618AD55DB8436B8EB414E47FFF5458' ,'8651DCAB4D714EF6AA747BB8F50719BA' )";
            const string dbconnectStr =
                "Data Source=10.100.3.55/orcl;User ID=mes_standard;Password=fpp;Min Pool Size=25;Unicode=True";
            var conn = new OracleConnection(dbconnectStr);
        }

        public static void Test1()
        {
            try
            {
                WriteDbUpdateLog("1231hashcode05281", "名称");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                throw;
            }

        }

        public static bool Test2()
        {
            const string sqlStr =
                "insert into \"DB_UPGRADE_SCRIPT_LOG\" ( " +
                "\"ABSTRACT\" ,\"HASHCODE\" ,\"NAME\" ,\"LOGTYPE\" ,\"LOGTYPE_ITI\" ," +
                "\"DESCRIPTION\",\"ITEM_TYPE_ID\" ,\"ID\" ,\"CREATED_ON\" ,\"CREATED_BY_ID\" ," +
                "\"CREATED_BY_ID_ITI\" ,\"MODIFIED_ON\" ,\"MODIFIED_BY_ID\" ,\"MODIFIED_BY_ID_ITI\" ,\"STATE\" ," +
                "\"STATE_ITI\" ,\"IS_CURRENT\" ,\"IS_RELEASED\" ,\"NOT_LOCKABLE\" ,\"GENERATION\" ," +
                "\"NEW_VERSION\" ,\"CONFIG_ID\" ,\"CONFIG_ID_ITI\" ,\"LAYER\" ,\"LAYER_ITI\" ) " +
                "values (" +
                "'{0}' ,'{1}' ,'{2}' ,'{3}' ,'8651DCAB4D714EF6AA747BB8F50719BA' ," +
                "'{4}','E17603E59E11458B821AE7D92D6E85F5' ,'E560BA72FA76430492FFEA1A253BF14F',:\"CREATED_ON\" ,'430180A86E644C3DA113D38389C71E2B' ," +
                "'45E899CD2859442982EB22BB2DF683E5' ,:\"MODIFIED_ON\" ,'430180A86E644C3DA113D38389C71E2B' ,'45E899CD2859442982EB22BB2DF683E5' ,'25BF3959E757414F97E0E4CCA971E714' ," +
                "'5EFB53D35BAE468B851CD388BEA46B30' ,'0' ,'0' ,'0' ,'0' ," +
                "'0' ,'151A4427234A4,07DB19C1F595E71CEA2' ,'E17603E59E11458B821AE7D92D6E85F5' ,'E4618AD55DB8436B8EB414E47FFF5458' ,'8651DCAB4D714EF6AA747BB8F50719BA' )";
            var hasLeftQuote = false;
            var sb = new StringBuilder(sqlStr);
            var length = sb.Length;
            for (int i = 0; i < length; i++)
            {
                var c = sb[i];
                if (c == 39) hasLeftQuote = !hasLeftQuote;
                else if (c == 44 && hasLeftQuote)
                {
                    sb[i] = '!';
                }
            }
            var sqlStr1 = sb.ToString();
            var firstBracketIndex = sqlStr1.IndexOf('(');
            var firstBackBracketIndex = sqlStr1.IndexOf(')');
            var columnStr = sqlStr1.Substring(firstBracketIndex + 1, firstBackBracketIndex - firstBracketIndex - 1);
            var secondBracketIndex = sqlStr1.IndexOf('(', firstBackBracketIndex);
            var lastBackBracketIndex = sqlStr1.LastIndexOf(')');
            var valueStr = sqlStr1.Substring(secondBracketIndex + 1, lastBackBracketIndex - secondBracketIndex - 1);
            var ss = columnStr.Split(',');
            var idIndex = 0;
            for (int i = 0; i < ss.Length; i++)
            {
                if (ss[i].Equals("\"ID\" ")) idIndex = i;
            }
            var id = valueStr.Split(',')[idIndex];

            var index1 = sqlStr.IndexOf('"');
            var index2 = sqlStr.IndexOf('"', index1 + 1);
            var tableName = sqlStr.Substring(index1, index2 - index1 + 1);
            var sqlStr2 = string.Format("select count(*) from {0} where \"ID\"={1}", tableName, id);
            var num = ((OracleNumber)ExecuteSql(sqlStr2)).Value;
            return num > 0;
        }

        private static object ExecuteSql(string sqlStr)
        {
            string connStr =
                "Data Source=orcl;User ID=mes_standard;Password=fpp;Min Pool Size=25;Unicode=True";
            var conn = new OracleConnection(connStr);
            try
            {
                conn.Open();
                var cmd = new OracleCommand(sqlStr) { Connection = conn };
                return cmd.ExecuteOracleScalar();
            }
            finally
            {
                conn.Close();
            }
        }

        private static void WriteDbUpdateLog(string hashCode, string name)
        {
            const string dbconnectStr =
                "Data Source=orcl;User ID=mes_standard;Password=fpp;Min Pool Size=25;Unicode=True";
            var conn = new OracleConnection(dbconnectStr);
            conn.Open();
            var tran = conn.BeginTransaction();
            try
            {
                const string sqlStr =
                    "insert\r\ninto \"DB_UPGRADE_SCRIPT_LOG\" (" +
                    "\"HASHCODE\" ,\"NAME\" ," +
                    "\"ITEM_TYPE_ID\" ,\"ID\" ,\"CREATED_ON\" ,\"CREATED_BY_ID\" ," +
                    "\"CREATED_BY_ID_ITI\" ,\"MODIFIED_ON\" ,\"MODIFIED_BY_ID\" ,\"MODIFIED_BY_ID_ITI\" ,\"STATE\" ," +
                    "\"STATE_ITI\" ,\"IS_CURRENT\" ,\"IS_RELEASED\" ,\"NOT_LOCKABLE\" ,\"GENERATION\" ," +
                    "\"NEW_VERSION\" ,\"CONFIG_ID\" ,\"CONFIG_ID_ITI\" ,\"LAYER\" ,\"LAYER_ITI\" ) " +
                    "values (" +
                    ":\"HASHCODE\" ,:\"NAME\"," +
                    "'E17603E59E11458B821AE7D92D6E85F5' ,:\"ID\",:\"CREATED_ON\" ,'430180A86E644C3DA113D38389C71E2B' ," +
                    "'45E899CD2859442982EB22BB2DF683E5' ,:\"MODIFIED_ON\" ,'430180A86E644C3DA113D38389C71E2B' ,'45E899CD2859442982EB22BB2DF683E5' ,'25BF3959E757414F97E0E4CCA971E714' ," +
                    "'5EFB53D35BAE468B851CD388BEA46B30' ,'0' ,'0' ,'0' ,'0' ," +
                    "'0' ,'151A4427234A407DB19C1F595E71CEA2' ,'E17603E59E11458B821AE7D92D6E85F5' ,'E4618AD55DB8436B8EB414E47FFF5458' ,'8651DCAB4D714EF6AA747BB8F50719BA' )";
                var cmd = new OracleCommand
                {
                    Connection = conn,
                    Transaction = tran,
                    CommandText = sqlStr
                };
                cmd.Parameters.Add(new OracleParameter("\"HASHCODE\"", OracleType.VarChar) {Value = hashCode});
                cmd.Parameters.Add(new OracleParameter("\"NAME\"", OracleType.NVarChar) {Value = name});
                cmd.Parameters.Add(new OracleParameter("\"ID\"", OracleType.VarChar)
                {
                    Value = Guid.NewGuid().ToString().Replace("-", "").ToUpper()
                });
                cmd.Parameters.Add(new OracleParameter("\"MODIFIED_ON\"", OracleType.DateTime)
                {
                    Value = new OracleDateTime(DateTime.Now)
                });
                cmd.Parameters.Add(new OracleParameter("\"CREATED_ON\"", OracleType.DateTime)
                {
                    Value = new OracleDateTime(DateTime.Now)
                });

                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("zhi",e);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
