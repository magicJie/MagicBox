using System;

namespace MagicBox.MF.Domain
{
    public sealed class ModelType : Model
    {
        #region Method

        #endregion Method


        public ModelType(string modelTypeId) : base(modelTypeId)
        {
        }

        public ModelType(string id, string modelTypeId):base(id,modelTypeId)
        {
        }

        public ModelType AncestorType
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Assembly
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string FullName
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool IsAbstract
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool IsSealed
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Model Parent
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
            }
        }

        public String TableName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// 模型元数据的保存区别于一般模型的保存，会产生DDL语句
        /// </summary>
        public void SaveMetadata()
        {
            //根据ModelType实例数据新建表

        }

#if DEBUG
        /// <summary>
        /// 创建模型类型表，仅在初始化MF表结构时使用
        /// </summary>
        public void CreateTableModelType()
        {

        }
#endif

    }
}
