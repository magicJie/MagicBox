using MagicBox;

namespace Demo.Console.MagicBox.Common
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var str1 = "OD0029294-02-30";
            var str2 = "OD0029294-01";
            var str3 = str1.Substring(str1.LastIndexOf('-') + 1);
            var str4 = str2 + "-"+str3;*/
            /*var input = new FileSystemResource(AppDomain.CurrentDomain.BaseDirectory + "../../object.xml");
            var factory = new XmlObjectFactory(input);
            var obj = factory.GetObject("PersonDao") as PersonDao;
             * 
            var ctx = ContextRegistry.GetContext();
            var obj = ctx.GetObject("PersonDao") as PersonDao;
            var cfg = new NHibernate.Cfg.Configuration().Configure("hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory()) { }
            var a = 3.1415926;
            var b = Math.Round(a, 3);*/

            var singleLinkList = new SingleLinkList<int>(0, 1, 2, 3, 4);
            singleLinkList.Reverse();
            System.Console.WriteLine(singleLinkList.ToString());
        }
    }
}
