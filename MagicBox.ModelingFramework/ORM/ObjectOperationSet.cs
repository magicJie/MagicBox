/* *********************************************** 
* 作者：王杰，创建于2016/1/27 17:20:55 
* 邮箱：wangjie.magic@gmail.com
* QQ ：2354557520 
* ***********************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.MF.ORM
{
    /// <summary>
    /// 隔离实体类差异，提供基本的对象操作集合以及实现Mapping的抽象实现
    /// </summary>
    public abstract class ObjectOperationSet:IObjectOperationSet
    {
        public virtual void CreateTable(DataTable dt)
        {
            throw new NotImplementedException();
        }
    }
}
