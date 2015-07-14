using System;
using MagicBox.MF.Domain;

namespace MagicBox.MF
{
    public class ModelCollectionByModelType : ModelCollection
    {
        public ModelCollectionByModelType()
        {
        }

        public ModelCollectionByModelType(ModelType modelType, WhereCause whereCause)
        {
            throw new NotImplementedException();
        }

        public ModelCollectionByModelType(string modelTypeId, string whereCauseStr)
        {
            throw new NotImplementedException();
        }

        public WhereCause WhereCause
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
    }
}
