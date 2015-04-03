using System.Collections.Generic;
using MagicBox.AgileWeb.Domain;

namespace MagicBox.AgileWeb.Service
{
    public interface IGenericManager<T> where T:IBaseModel
    {
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        T Get(object id);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        T Load(object id);
        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        object Save(T entity);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Updata(T entity);

        void SaveOrUpdata(T entity);
        void Delete(object id);
        void Delete(IList<object> idList);
        /// <summary>
        /// 获取全部集合
        /// </summary>
        /// <returns></returns>
        IList<T> LoadAll();
        /// <summary>
        /// 分页获取全部集合
        /// </summary>
        /// <param name="count">记录总数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns>实体集合</returns>
        IList<T> LoadAllWithPage(out long count, int pageIndex, int pageSize);
    }
}
