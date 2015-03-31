using MagicBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MagicBox
{
    [TestClass]
    public class SequenceStackTest
    {
        private SequenceStack<int> _sequenceStack=new SequenceStack<int>(5);

        public SequenceStackTest()
        {
            _sequenceStack.Push(1);
            _sequenceStack.Push(2);
            _sequenceStack.Push(3);
        }


        [TestMethod]
        public void PushTest()
        {
            _sequenceStack.Push(4);
            _sequenceStack.Maxsize = 6;
            _sequenceStack.Push(5);
            _sequenceStack.Push(6);
            Assert.AreEqual("6,5,4,3,2,1", _sequenceStack.ToString());
        }

        [TestMethod]
        public void PopTest()
        {
            var m=_sequenceStack.Pop();
            Assert.AreEqual("2,1_3",_sequenceStack+"_"+m);
        }

        [TestMethod]
        public void GetTopTest()
        {
            var m = _sequenceStack.GetTop();
            Assert.AreEqual("3,2,1_3",_sequenceStack+"_"+m);
        }
    }
}
