using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace MagicBox.Common.Data
{
    /// <summary>
    /// 不进行分页查询的分页信息。
    /// 
    ///             一般情况下，效果等同于传入 null 值的 PagingInfo。
    ///             在使用多参数查询时，则只能使用这个对象，而不能使用 null 查询。
    /// 
    /// </summary>
    [Serializable]
    internal class EmptyPagingInfo : PagingInfo, ISerializable
    {
        internal EmptyPagingInfo()
            : base(1, 1)
        {
        }

        /// <summary>
        /// 反序列化构造函数。
        /// 
        ///             需要更高安全性，加上以下这句：
        /// 
        /// </summary>
        /// <param name="info"/><param name="context"/>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected EmptyPagingInfo(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(SSH));
        }

        /// <summary>
        /// Singleton Serialization Helper
        /// 
        /// </summary>
        [Serializable]
        private sealed class SSH : IObjectReference
        {
            public object GetRealObject(StreamingContext context)
            {
                return (object)Empty;
            }
        }
    }
}
