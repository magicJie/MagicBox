using System.Collections.Generic;
using System.Linq;
using MagicBox.AgileWeb.Dao;
using MagicBox.MF;

namespace MagicBox.AgileWeb.Service.Impl
{
    /// <summary>
    /// 定义服务的基础功能
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericManager<T> : IGenericManager<T> where T : BaseModel 
    {

    }
}