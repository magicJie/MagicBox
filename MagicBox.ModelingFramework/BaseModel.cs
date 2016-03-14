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
using System.Runtime.Serialization;

namespace MagicBox.MF.Models
{
    public abstract partial class BaseModel : ISerializable
    {
        /// <summary>
        /// RMC的集合
        /// </summary>
        public abstract RMCC RMCC { get; set; }

        public abstract string Id { get; }

        public abstract LifeCycleState State { get; }

        public abstract ModelType Type { get; }

        public abstract DateTime CreatedTime { get; }

        public abstract DateTime ModifiedTime { get; }

        public abstract User Creator { get; }

        public abstract User Modifier { get; }
        public abstract void Delete();

        public abstract void Save();

        public abstract void Load();
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
    }
}