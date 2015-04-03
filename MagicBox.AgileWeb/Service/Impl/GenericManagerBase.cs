using System.Collections.Generic;
using System.Linq;
using MagicBox.AgileWeb.Dao;
using MagicBox.AgileWeb.Domain;

namespace MagicBox.AgileWeb.Service.Impl
{
    /// <summary>
    /// 提供基础服务
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericManagerBase<T>:IGenericManager<T> where T:IBaseModel 
    {
        public IRepository<T> CurrentRepository { get; set; }

        public virtual T Get(object id)
        {
            return id == null ? default(T) : CurrentRepository.Get(id);
        }

        public virtual T Load(object id)
        {
            return id == null ? default(T) : CurrentRepository.Load(id);
        }

        public virtual object Save(T entity)
        {
            return entity==null?null:CurrentRepository.Save(entity);
        }

        public virtual void Updata(T entity)
        {
            if(entity==null)return;
            CurrentRepository.Update(entity);
        }

        public virtual void SaveOrUpdata(T entity)
        {
            if(entity==null)return;
            CurrentRepository.SaveOrUpdate(entity);
        }

        public virtual void Delete(object id)
        {
            if(id==null)return;
            CurrentRepository.Delete(id);
        }

        public virtual void Delete(IList<object> idList)
        {
            if(idList==null||idList.Count==0)return;
            CurrentRepository.Delete(idList);
        }

        public virtual IList<T> LoadAll()
        {
            return CurrentRepository.LoadAll().ToList();
        }

        public virtual IList<T> LoadAllWithPage(out long count, int pageIndex, int pageSize)
        {
            return CurrentRepository.LoadAllWithPage(out count, pageIndex, pageSize).ToList();
        }
    }
}