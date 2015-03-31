using System;
using MagicBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MagicBox
{
    [TestClass]
    public class LinkStackTest
    {
        private LinkStack<int> _linkStack=new LinkStack<int>();

        public LinkStackTest()
        {
            _linkStack.Push(1);
            _linkStack.Push(2);
            _linkStack.Push(3);
            _linkStack.Push(4);
        }
         [TestMethod]
        public void PushTest()
        {
            Assert.AreEqual("4,3,2,1",_linkStack.ToString());
        }

        [TestMethod]
        public void PopTest()
        {
            var m=_linkStack.Pop();
            Assert.AreEqual("3,2,1_4",_linkStack+"_"+m);
        }

        [TestMethod]
        public void GetTopTest()
        {
            var m = _linkStack.GetTop();
            Assert.AreEqual("4,3,2,1_4",_linkStack+"_"+m);
        }
    }
}
