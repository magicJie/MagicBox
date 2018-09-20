using System;
using System.IO;
using System.Text;
using MagicBox.Security.Cryptography;
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

        [TestMethod]
        public void CreateRSAKeyTest()
        {
            var keyPair = Encrypter.CreateRSAKey();
            File.WriteAllText("pubKey.txt", keyPair.Key, Encoding.UTF8);
            File.WriteAllText("priKey.txt", keyPair.Value, Encoding.UTF8);
            Assert.IsTrue(File.Exists("pubKey.txt") && File.Exists("priKey.txt"));
        }

        [TestMethod]
        public void EncryptByRSATest()
        {
            const string plainText = "machineCode:7ceae9aa6f6ba099e30c596894b8f5b4,username:WJ,deadLine:2018/6/7 14:03:38";
            var pubKey = File.ReadAllText("pubKey.txt", Encoding.UTF8);
            var priKey = File.ReadAllText("priKey.txt", Encoding.UTF8);
            Assert.IsNotNull(Encrypter.EncryptByRSA(plainText, priKey));
        }

        [TestMethod]
        public void DecryptByRSATest()
        {
            const string plainText = "machineCode:7ceae9aa6f6ba099e30c596894b8f5b4,username:WJ,deadLine:2018/6/7 14:03:38";
            var pubKey = File.ReadAllText("pubKey.txt", Encoding.UTF8);
            var priKey = File.ReadAllText("priKey.txt", Encoding.UTF8);
            var ciphertext = Encrypter.EncryptByRSA(plainText, pubKey);
            Assert.AreEqual(plainText, Encrypter.DecryptByRSA(ciphertext, priKey));
        }
    }
}
