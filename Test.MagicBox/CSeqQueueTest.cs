using MagicBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MagicBox
{
    [TestClass]
    public class CSeqQueueTest
    {
        private readonly CSeqQueue<int> _cSeqQueue=new CSeqQueue<int>(3);

        public CSeqQueueTest()
        {
            _cSeqQueue.EnQueue(1);
            _cSeqQueue.EnQueue(2);
            _cSeqQueue.EnQueue(3);
        }
        [TestMethod]
        public void EnQueueTest()
        {
            Assert.AreEqual("rear:2;front:-1;1,2,3",_cSeqQueue.ToString());
        }

        [TestMethod]
        public void DeQueueTest()
        {
            var m=_cSeqQueue.DeQueue();
            Assert.AreEqual("rear:2;front:0;0,2,3_1", _cSeqQueue + "_" + m);
        }

        [TestMethod]
        public void GetFrontTest()
        {
            var m = _cSeqQueue.GetFront();
            Assert.AreEqual("rear:2;front:-1;1,2,3_1",_cSeqQueue+"_"+m);
        }
    }
}
