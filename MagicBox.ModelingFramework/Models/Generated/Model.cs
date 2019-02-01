#region License

/*
 * Copyright 2002-2010 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using System.Collections.Generic;
using MagicBox.MF.Id;

namespace MagicBox.MF.Models
{
    /// <summary>
    /// 建模框架的底层模型。底层模型具备建模框架需要的ORM功能。使用MF建模的模型必须继承此模型
    /// </summary>
    public partial class Model : BaseModel
    {
        protected Model DecorateModel;

        #region Popertity
        public override RMCC RMCC
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Id
        {
            get { return _id; }
        }

        public override LifeCycleState State
        {
            get { return _state; }
        }

        public override ModelType Type
        {
            get { return _modelType; }
        }

        public override DateTime CreatedTime
        {
            get { throw new NotImplementedException(); }
        }

        public override DateTime ModifiedTime
        {
            get { throw new NotImplementedException(); }
        }

        public override User Creator
        {
            get
            {
                throw new NotImplementedException(); 
            }
        }

        public override User Modifier
        {
            get { throw new NotImplementedException(); }
        }

        #endregion Propertity

        #region Method

        #endregion Method

        #region Constructor

        internal Model()
        {
            _id = NewId();            
        }

        internal Model(string modelTypeId)
        {

        }

        internal Model(string id, string modelTypeId)
        {
            _id = id;
            _modelType = ModelFactory.Current.GetModel(modelTypeId, ModelTypeId.ModelType) as ModelType;
        }
        #endregion Constructor

        public T GetProperty<T>(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void SetProperty(string propertyName, object value)
        {
            throw new NotImplementedException();
        }

        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            throw new NotImplementedException();
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

        public LifeCycle LifeCycle
        {
            get => default(LifeCycle);
            set
            {
            }
        }
    }
}
