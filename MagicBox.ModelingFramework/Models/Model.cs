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
using System.Data;
using MagicBox.MF.Id;

namespace MagicBox.MF.Models
{
    /// <summary>
    /// 建模框架的底层模型。底层模型具备建模框架需要的ORM功能。使用MF建模的模型必须继承此模型
    /// </summary>
    public partial class Model : BaseModel
    {
        private string _id;
        private LifeCycleState _state;
        private ModelType _modelType;
        private Dictionary<string, Property> _properties; //存储了模型所有的属性信息

        #region Popertity


        #endregion Propertity

        #region Method
        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 返回一个GUID，将FCL提供的GUID去掉"-"将小写字母转大写得到
        /// </summary>
        /// <returns></returns>
        public static string NewId()
        {
            return Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        }

        /// <summary>
        /// 返回该模型的ModelType，在创建表结构时使用
        /// </summary>
        /// <returns></returns>
        protected internal virtual ModelType GetModelType()
        {
            var modelType=new ModelType();
            var properties = new ModelCollectionByType();
            properties.AddRange(new Model[]
            {
               new Property()
                {
                    Source = this,
                    Name = "Name",
                    SourceDataType = MFDataType.MFString
                },
                new Property()
                {
                    Source = this,
                    Name = "Name",
                    SourceDataType = MFDataType.MFString
                },
                new Property()
                {
                    Source = this,
                    Name = "Name",
                    SourceDataType = MFDataType.MFString
                }, 
            });
            modelType.RMCC.Add(properties);
            return modelType;
        }

        #endregion Method

        #region Constructor

        #endregion Constructor

    }
}
