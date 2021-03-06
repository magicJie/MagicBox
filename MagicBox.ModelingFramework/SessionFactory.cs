﻿#region License

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
using System.Security.Permissions;
using MagicBox.MF.Models;

namespace MagicBox.MF
{
    /// <summary>
    /// MF核心类，管理会话的全过程，创建和销毁，跟踪每个Session行为。
    /// <para>线程安全</para>
    /// </summary>
    public class SessionFactory
    {
        #region Field
        private static SessionFactory _current;
        private readonly IDictionary<string, object> _data;
        private User _user;
        private bool _isBeingTranscation;
        #endregion Field

        #region Propertity
        /// <summary>
        /// 指示当前上下文是否出于事务中
        /// </summary>
        public bool IsBeingTranscation
        {
            get { return _isBeingTranscation; }
        }

        public User User {
            get { return _user; }
        }

        public object this[string key]
        {
            get
            {
                object obj;
                _data.TryGetValue(key, out obj);//从API设计角度来看这里是给Null好还是抛异常好？
                return obj;
            }
            internal set { _data.Add(new KeyValuePair<string, object>(key,value));}            
        }

        public static SessionFactory Current
        {
            get
            {
                if (_current == null)
                    throw new Exception("当前上下文为空！");
                return _current;
            }
            internal set
            {
                _current = value;   
            }
        }

        #endregion Propertity

        #region Method
        public Session CreateSession()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 接受当前上下文事务
        /// </summary>
        public void Accept()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 丢弃当前上下文事务
        /// </summary>
        public void Discard()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 开始一个事务
        /// </summary>
        public void BeginWithTranscation()
        {
            throw new NotImplementedException();
        }

        #endregion Method

        #region Constructor

        internal SessionFactory()
        {
            _data=new Dictionary<string, object>();
            _isBeingTranscation = false;
        }

        #endregion Constructor

        #region StaticMethod

        #endregion
    }
}
