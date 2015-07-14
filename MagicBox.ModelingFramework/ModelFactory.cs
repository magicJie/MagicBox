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
using System.IO;
using MagicBox.MF.Cfg;
using MagicBox.MF.Domain;

namespace MagicBox.MF
{
    /// <summary>
    /// MF核心类型。提供对模型实例的创建、获取。单例、线程安全
    /// </summary>
    public class ModelFactory
    {
        #region Field
        private static ModelFactory _current;
        private ModelFactoryState _state;
        private Configuration _configuration;
        private RuntimeContext _runtimeContext;
        #endregion Field

        #region Propertity

        public ModelFactoryState State
        {         
            get { return _state; }
        }

        public static ModelFactory Current
        {
            get
            {
                if(_current==null)
                    throw new Exception("模型工厂未初始化！");
                return _current;
            }
            internal set { _current = value; }
        }        

        #endregion Propertity

        #region Method

        /// <summary>
        /// 新建一个模型实例（元数据实例除外）
        /// </summary>
        /// <param name="modelTypeId">模型类型Id</param>
        /// <returns></returns>
        public Model NewModelById(string modelTypeId)
        {
            //1 根据modelTypeId到ModelType表中获取该模型的元数据Metadata
            //2 根据Metadata获取该模型的列名、关联、属性...
            throw new NotImplementedException();
            

        }

        public Model NewModel(string modelTypeName)
        {
            //1 根据modelName到ModelType表中获取该模型的元数据Metadata
            //2 根据Metadata获取该模型的列名、关联、属性...
            throw new NotImplementedException();
        }

        public Model GetModel(string id, string modelTypeId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据属性值尝试获取一个模型，若不存在对应模型则返回空
        /// </summary>
        /// <param name="modelTypeId"></param>
        /// <param name="cells">属性值对</param>
        /// <returns></returns>;
        public Model GetModelWithPropertityValue(string modelTypeId, params Cell[] cells)
        {
            throw new NotImplementedException();
        }

        #endregion Method

        #region Constructor

        internal ModelFactory(Configuration configuration)
        {
            _state = ModelFactoryState.LoadingConfig;
            _configuration = configuration;

        }

        #endregion Constructor

        #region Event
        #endregion Event
    }

    public enum ModelFactoryState
    {
        LoadingConfig,
        Checking,
        Constructing,
        Responseing,
        Default
    }
}
