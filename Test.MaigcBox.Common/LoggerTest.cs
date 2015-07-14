using System;
using System.Threading;
using MagicBox.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MaigcBox.Common
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void WriteTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var thread = new Thread(Worker);
                thread.Name = "调用写日志的第" + i + "个线程";
                thread.Start(i);
            }            
        }

        private void Worker(object i)
        {
            Logger.Instance.Write("这是第"+i+"个线程的日志信息");
        }
    }
}
