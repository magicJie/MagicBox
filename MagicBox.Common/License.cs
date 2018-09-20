using System;
using MagicBox.Security.Cryptography;
using System.IO;

namespace MagicBox
{
    public class License
    {
        private string _machineCode;
        private string _userName;
        private DateTime _deadLine;
        private readonly string _priKey;

        public License(string filename, string priKey)
        {
            _priKey = priKey;
            Decrypt(File.ReadAllText(filename));
        }

        private void Decrypt(string cipherText)
        {
            var plainText = Encrypter.DecryptByRSA(cipherText, _priKey);
            var ss = plainText.Split(',');
            _machineCode = ss[0].Split(':')[1];
            _userName = ss[1].Split(':')[1];
            _deadLine = DateTime.Parse(ss[2].Split(':')[1]);
        }

        /// <summary>
        /// 校验当前License还剩余的有效时间
        /// </summary>
        /// <returns></returns>
        public int Validate()
        {
            var machineCode = GetMachineCode();
            if (!machineCode.Equals(_machineCode)|| DateTime.Now >= _deadLine)
                return 0;
            return (_deadLine - DateTime.Now).Days;
        }

        /// <summary>
        /// 生成授权码
        /// </summary>
        /// <param name="machineCode">机器码</param>
        /// <param name="username">注册用户名</param>
        /// <param name="deadLine">授权截止日期</param>
        /// <param name="pubKey">公钥</param>
        /// <returns>授权码</returns>
        public static string Genarate(string machineCode, string username, DateTime deadLine, string pubKey)
        {
            var str = $"machineCode:{machineCode},username:{username},deadLine:{deadLine.ToString("yy-MM-dd")}";
            return Encrypter.EncryptByRSA(str, pubKey);
        }
        public static string GetMachineCode()
        {
            return Encrypter.EncryptByMD5(EnvironmentHelper.GetMachineInfo());
        }
    }
}
