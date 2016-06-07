/* *********************************************** 
* 作者：姓名，创建于2016/1/27 15:06:13 
* 邮箱：邮箱地址 
* QQ ：QQ号码 
* ***********************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicBox.MF.ORM;

namespace MagicBox.MF
{
    /// <summary>
    /// 定义了MF中Model操作集合。调用Sql转换器将Model操作转换为Sql
    /// </summary>
    public class ModelOperationSet:ObjectOperationSet
    {
        public override void CreateTable(DataTable dt)
        {
            throw new NotImplementedException();
        }
    }
}
