using System;
using NHibernate;
using NHibernate.Cfg;
using Spring.Context.Support;
using Spring.Core.IO;
using Spring.Objects.Factory.Xml;

namespace Demo.Console.MagicBox.
{
    public class NhibernateDemo
    {
        public static void Matheod()
        {
            var input = new FileSystemResource(AppDomain.CurrentDomain.BaseDirectory + "../../object.xml");
            var factory = new XmlObjectFactory(input);
            var obj = factory.GetObject("PersonDao") as PersonDao; 
        }

        public static void Matheod1()
        {
            var ctx = ContextRegistry.GetContext();
            var obj = ctx.GetObject("PersonDao") as PersonDao;
            var cfg = new Configuration().Configure("hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory()) { }
        }
    }
}
