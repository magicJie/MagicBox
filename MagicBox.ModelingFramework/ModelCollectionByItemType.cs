using System;
using MagicBox.MF.Models;

namespace MagicBox.MF
{
    public class ModelCollectionByType : ModelCollection
    {
        public ModelCollectionByType()
        {
        }

        public ModelCollectionByType(string modelTypeId)
        {
        }

        public ModelCollectionByType(ModelType modelType, WhereClause whereClause)
        {
            throw new NotImplementedException();
        }

        public ModelCollectionByType(string modelTypeId, string whereClauseStr)
        {
            throw new NotImplementedException();
        }

        public WhereClause WhereClause
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public ModelType ModelType
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        /// <summary>
        /// 从缓存或数据库加载数据
        /// </summary>
        public void Load()
        {
            throw new NotImplementedException();
        }
    }
}
