using System;
using System.Linq;

namespace MagicBox.MF.Models
{
    public sealed partial class ModelType : Model
    {
        #region Method

        #endregion Method

        /// <summary>
        /// 模型元数据的保存区别于一般模型的保存，会产生DDL语句
        /// </summary>
        public void SaveMetadata()
        {
            //根据ModelType实例数据新建表

        }
        /// <summary>
        /// 供ModelFactory调用的构造方法
        /// </summary>
        internal ModelType()
        {
        }

#if DEBUG
        /// <summary>
        /// 创建模型类型表，仅在初始化MF表结构时使用
        /// </summary>
        public void CreateTableModelType()
        {

        }
#endif

        protected internal override ModelType GetModelType()
        {
            var modelType = new ModelType();
            var properties1 = new ModelCollectionByType();
            properties1.AddRange(new Model[]
            {
                new Property()
                {
                    Source = modelType,
                    Name = "Name",
                    SourceDataType = MFDataType.MFString
                },
                new Property()
                {
                    Source = modelType,
                    Name = "Name",
                    SourceDataType = MFDataType.MFString
                },
                new Property()
                {
                    Source = modelType,
                    Name = "Name",
                    SourceDataType = MFDataType.MFString
                },
            });
            properties1.AddRange(base.GetModelType().RMCC["Properties"].ToArray());//要加上父的属性
            modelType.RMCC.Add(properties1);
            return modelType;
        }
    }
}
