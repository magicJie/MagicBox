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
        public void LastText()
        {
            Assert.AreEqual(singleLinkList.Last,4);
        }
        [TestMethod]
        public void CountText()
        {
            Assert.AreEqual(singleLinkList.Count, 5);
        }
        [TestMethod]
        public void GetElementText()
        {
            Assert.AreEqual(singleLinkList.GetElement(4), 4);
        }
        [TestMethod]
        public void IndexOfText()
        {
            Assert.AreEqual(singleLinkList.IndexOf(4), 4);
        }
        [TestMethod]
        public void PreElementText()
        {
            Assert.AreEqual(singleLinkList.PreElement(4), 3);
        }
        [TestMethod]
        public void NextElementText()
        {
            Assert.AreEqual(singleLinkList.NextElement(3), 4);
        }
        [TestMethod]
        public void AppendText()
        {
            singleLinkList.Append(5);
            Assert.AreEqual(singleLinkList.Last, 5);
        }
        [TestMethod]
        public void InsertText()
        {
            singleLinkList.Insert(0,6);
            Assert.AreEqual(singleLinkList[0],6);
        }
        [TestMethod]
        public void RemoveAtText()
        {
            singleLinkList.RemoveAt(0);
            Assert.AreEqual(singleLinkList[0], 1);
        }
        [TestMethod]
        public void ToStringText()
        {
            Assert.AreEqual(singleLinkList.ToString(), "0,1,2,3,4");
        }
        [TestMethod]
        public void ReverseText()
        {
            singleLinkList.Reverse();
            Assert.AreEqual(singleLinkList.ToString(), "4,3,2,1,0");
        }
    }
}
