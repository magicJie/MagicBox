using System;
using System.Data;
using System.IO;
using HGBS.Lib;

namespace MagicBox.Security.Cryptography
{
    public class EncryptDataHelper
    {
        /// <summary>
        /// 逐条对表的数据摘要加密，增加一行用来存储数字签名
        /// 注意：
        ///   加密数据表的第一行为对整个数据表的摘要，监控整个表的数据变动，保证整行删除数据能被发现。由于是对整个表数据摘要，
        ///   所以加密数据表其他列没有数据
        /// </summary>
        /// <param name="dt">原始数据表</param>
        /// <returns>加密数据表</returns>
        public static void Encrypt(DataTable dt,string privateKey)
        {
            StreamReader sr = new StreamReader(privateKey);
            string privateKeyStr = sr.ReadToEnd();
            //增加一列
            dt.Columns.Add(new DataColumn("digest", typeof(String)));
            //逐条生成摘要            
            foreach (DataRow row in dt.Rows)
            {
                string originalData = "";
                for (int i = 0; i < dt.Columns.Count - 1; i++)
                {
                    //这个地方算法合理性有待证明
                    originalData += dt.Columns[i].ColumnName + ":" + row[i].ToString() + ",";
                }
                row[dt.Columns.Count] = Encrypter.HashAndSignString(originalData, privateKeyStr);
            }
        }
    }
}
