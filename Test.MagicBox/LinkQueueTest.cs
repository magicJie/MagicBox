using System.Diagnostics;
using MagicBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MagicBox
{
    [TestClass]
    public class LinkQueueTest
    {
        private readonly LinkQueue<int> _linkQueue=new LinkQueue<int>();

        public LinkQueueTest()
        {
            _linkQueue.EnQueue(1);
            _linkQueue.EnQueue(2);
            _linkQueue.EnQueue(3);
        }
        [TestMethod]
        public void EnQueueTest()
        {
            Assert.AreEqual("1,2,3",_linkQueue.ToString());
        }

        [TestMethod]
        public void DeQueueTest()
        {
            var m = _linkQueue.DeQueue();
            Assert.AreEqual("2,3_1",_linkQueue+"_"+m);
        }

        [TestMethod]
        public void GetFrontTest()
        {
            var m = _linkQueue.GetFront();
            Assert.AreEqual("1,2,3_1",_linkQueue+"_"+m);
        }
    }
}
