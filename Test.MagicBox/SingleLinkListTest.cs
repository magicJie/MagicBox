using MagicBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MagicBox
{
    [TestClass]
    public class SingleLinkListTest
    {
        private SingleLinkList<int> singleLinkList=new SingleLinkList<int>(0, 1, 2, 3, 4);
        [TestMethod]
        public void ThisTest()
        {
            Assert.AreEqual(0,singleLinkList[0]);
        }
        [TestMethod]
        public void LastTest()
        {
            Assert.AreEqual(4,singleLinkList.Last);
        }
        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(5,singleLinkList.Count);
        }
        [TestMethod]
        public void GetElementTest()
        {
            Assert.AreEqual(4,singleLinkList.GetElement(4));
        }
        [TestMethod]
        public void IndexOfTest()
        {
            Assert.AreEqual(4,singleLinkList.IndexOf(4));
        }
        [TestMethod]
        public void PreElementTest()
        {
            Assert.AreEqual(3,singleLinkList.PreElement(4));
        }
        [TestMethod]
        public void NextElementTest()
        {
            Assert.AreEqual(4,singleLinkList.NextElement(3));
        }
        [TestMethod]
        public void AppendTest()
        {
            singleLinkList.Append(5);
            Assert.AreEqual(5,singleLinkList.Last);
        }
        [TestMethod]
        public void InsertTest()
        {
            singleLinkList.Insert(0,6);
            Assert.AreEqual(6,singleLinkList[0]);
        }
        [TestMethod]
        public void RemoveAtTest()
        {
            singleLinkList.RemoveAt(0);
            Assert.AreEqual(1,singleLinkList[0]);
        }
        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("0,1,2,3,4",singleLinkList.ToString());
        }
        [TestMethod]
        public void ReverseTest()
        {
            singleLinkList.Reverse();
            Assert.AreEqual("4,3,2,1,0",singleLinkList.ToString());
        }
    }
}
