using System.Data;

namespace MagicBox.MF.ORM
{
    /// <summary>
    /// 定义了ORM中对象能够提供的操作集合
    /// </summary>
    interface IObjectOperationSet
    {

        void CreateTable(DataTable dt);
    }
}
