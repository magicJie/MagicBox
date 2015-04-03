using System;
using System.Collections.Generic;
using System.Linq;
using MagicBox.AgileWeb.Domain;
using NHibernate.Linq;
using Spring.Data.NHibernate.Generic.Support;

namespace MagicBox.AgileWeb.Dao.Impl
{
    public class RepositoryBase<T>:HibernateDaoSupport,IRepository<T> where T:IBaseModel 
    {
        /// <summary>
        /// 根据属性名获取对象
        /// </summary>
        /// <param name="id">属性名</param>
        /// <returns></returns>
        public T Get(object id)
        {
            /*var list = HibernateTemplate.Find<T>("from User where account =" +id );
            switch (list.Count)
            {
                case 0:
                    return default(T);
                case 1:
                    return list[0];
                default:
                    throw new Exception("返回多个结果");
            }*/
            return HibernateTemplate.Get<T>(id);
        }

        public T Load(object id)
        {
            return HibernateTemplate.Load<T>(id);
        }

        public object Save(T entity)
        {
            return HibernateTemplate.Save(entity);
        }

        public void Update(T entity)
        {
            HibernateTemplate.Update(entity);
        }

        public void SaveOrUpdate(T entity)
        {
            HibernateTemplate.SaveOrUpdate(entity);
        }

        public void Delete(object id)
        {
            var entity = HibernateTemplate.Get<T>(id);
            if (entity==null)
            {
                return;                
            }
            HibernateTemplate.Delete(entity);
        }

        public void Delete(IList<object> idList)
        {
            foreach (var item in idList)
            {
                Delete(item);
            }
        }

        public IQueryable<T> LoadAll()
        {
            return Session.Query<T>();
        }

        public IQueryable<T> LoadAllWithPage(out long count, int pageIndex, int pageSize)
        {
            var result = Session.Query<T>();
            count = result.LongCount();
            return result.Skip((pageIndex - 1)*pageSize).Take(pageSize);
        }
    }
}