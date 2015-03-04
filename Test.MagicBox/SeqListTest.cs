using System;
using System.Collections.Generic;
using MagicBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MagicBox
{
    [TestClass]
    public class SeqListTest
    {
        [TestMethod]
        public void IsEmptyTest()
        {
            var seqList = new SeqList<int>(3);
            seqList.Append(1);
            seqList.Append(2);
            seqList.Append(3);
            seqList.Traverse(x=>++x);
            var a = seqList.Count();
            var b=seqList.GetElement(2);
            var c = seqList.IndexOf(2);
            seqList.Maxsize=5;
            seqList.Insert(2, 0);
            var d=seqList.IsEmpty;
            var e = seqList.IsFull;
            seqList.NextElement(2);
            seqList.PreElement(1);
            seqList.Reverse();
            seqList.RemoveAt(2);
        }

    }
}
