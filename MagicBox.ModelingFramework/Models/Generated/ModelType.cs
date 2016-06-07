using System;

namespace MagicBox.MF.Models
{
    public sealed partial class ModelType : Model
    {
        public const string TypeId = "";
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
            internal set
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
    }
}
