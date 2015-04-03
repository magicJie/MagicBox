using MagicBox;

namespace Demo.Console.MagicBox.Common
{
    public class JosephRingDemo
    {
        private struct Data
        {
            /// <summary>
            /// 
            /// </summary>
            public int Id;
            public int Step;

            public Data(int id, int step)
            {
                Id = id;
                Step = step;
            }
        }

        public static void JosephRingTest()
        {
            var circleLinkList = new CircleLinkList<Data>(new CircleLinkList<Data>.Node(new Data(1, 5)));
            circleLinkList.Append(new CircleLinkList<Data>.Node(new Data(2, 7)));
            circleLinkList.Append(new CircleLinkList<Data>.Node(new Data(3, 10)));
            circleLinkList.Append(new CircleLinkList<Data>.Node(new Data(4, 2)));
            circleLinkList.Append(new CircleLinkList<Data>.Node(new Data(5, 7)));
            circleLinkList.Append(new CircleLinkList<Data>.Node(new Data(6, 5)));
            circleLinkList.Append(new CircleLinkList<Data>.Node(new Data(7, 9)));
            var step = circleLinkList.Point.Data.Step;
            while (circleLinkList.Count>1)
            {
                while (step > 0)
                {
                    circleLinkList.Point = circleLinkList.Point.NextNode;
                    step--;
                }
                System.Console.WriteLine("序号为{0}的结点被踢出", circleLinkList.Point.Data.Id);
                step = circleLinkList.Delete().Data.Step;
            }
            System.Console.WriteLine("剩下的结点序号为{0}", circleLinkList.Point.Data.Id);
        }
    }
}
