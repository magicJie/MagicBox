using System;
using System.IO;
using MagicBox.Common.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MaigcBox.Common
{
    [TestClass]
    public class EncrypterTest
    {
        [TestMethod]
        public void EncryptByMD5Test()
        {
            const string path = @"d:\1.txt";
            var sr = new StreamReader(path, System.Text.Encoding.Default);
            var str = sr.ReadToEnd();
            var m = Encrypter.EncryptByMD5(str);
        }
    }
}
