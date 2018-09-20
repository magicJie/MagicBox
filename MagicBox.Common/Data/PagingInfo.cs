using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace MagicBox.Data
{
    /// <summary>
    /// this indicates a pager info,
    ///             includes page number, page size, and total count;
    /// 
    ///             Note!
    ///             Don't use null to indicates a empty paging information, use <see cref="F:Rafy.PagingInfo.Empty"/> instead.
    /// 
    /// </summary>
    [DataContract]
    [Serializable]
    public class PagingInfo
    {
        /// <summary>
        /// A singleton instance indicates there is no paging action.
        /// 
        /// </summary>
        public static readonly PagingInfo Empty = (PagingInfo)new EmptyPagingInfo();
        private int _pageNumber;
        private int _pageSize;
        /// <summary>
        /// If this value is positive or zero, it indicates the count.
        ///             Otherwise, it means "need count all items".
        /// 
        /// </summary>
        private int _totalCount;

        /// <summary>
        /// Whether need to retrieve count of all records
        ///             (if it's true, it means the DAL should retrieve count info from database.)
        /// 
        /// </summary>
        [DataMember]
        public bool IsNeedCount
        {
            get
            {
                return this._totalCount < 0;
            }
            set
            {
                if (value)
                {
                    if (this._totalCount < 0)
                        return;
                    this._totalCount = -1;
                }
                else if (this._totalCount < 0)
                    this._totalCount = 0;
            }
        }

        /// <summary>
        /// Count of all records
        /// 
        /// </summary>
        public int TotalCount
        {
            get
            {
                if (this._totalCount == -1)
                    return 0;
                return this._totalCount;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "value can not be negative.");
                this._totalCount = value;
            }
        }

        /// <summary>
        /// size of a page
        /// 
        /// </summary>
        [DataMember]
        public int PageSize
        {
            get
            {
                return this._pageSize;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value", "value should be positive.");
                this._pageSize = value;
            }
        }

        /// <summary>
        /// current page number.
        ///             start from 1.
        /// 
        /// </summary>
        [DataMember]
        public int PageNumber
        {
            get
            {
                return this._pageNumber;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value", "value should be positive.");
                this._pageNumber = value;
            }
        }

        /// <summary>
        /// Gets the total page count, if <see cref="P:Rafy.PagingInfo.TotalCount"/> has positive value.
        /// 
        /// </summary>
        public int PageCount
        {
            get
            {
                int num = this._totalCount / this._pageSize;
                if (this._totalCount % this._pageSize != 0)
                    ++num;
                return num;
            }
        }

        /// <summary>
        /// Indicates whether current page is not the first one.
        /// 
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return this._pageNumber > 1;
            }
        }

        /// <summary>
        /// Indicates whether current page is not the last one.
        /// 
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return this._pageNumber < this.PageCount;
            }
        }

        /// <summary>
        /// this constructor indicate that no need to retrieve count information from database
        /// 
        /// </summary>
        /// <param name="pageNumber"/><param name="pageSize"/>
        public PagingInfo(int pageNumber, int pageSize)
            : this(pageNumber, pageSize, false)
        {
        }

        /// <summary>
        /// this constructor indicate whether to retrieve count information from database
        /// 
        /// </summary>
        /// <param name="pageNumber"/><param name="pageSize"/><param name="isNeedCount">is need retrieve count of all records(if it is true,it will retrieve count info from database)</param>
        public PagingInfo(int pageNumber, int pageSize, bool isNeedCount)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.IsNeedCount = isNeedCount;
        }

        /// <summary>
        /// construct with a totalCount
        /// 
        /// </summary>
        /// <param name="pageNumber"/><param name="pageSize"/><param name="totalCount"/>
        public PagingInfo(int pageNumber, int pageSize, int totalCount)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
        }

        /// <summary>
        /// 反序列化构造函数。
        /// 
        ///             需要更高安全性，加上以下这句：
        /// 
        /// </summary>
        /// <param name="info"/><param name="context"/>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected PagingInfo(SerializationInfo info, StreamingContext context)
        {
        }

        /// <summary>
        /// Indicates is this pagingInfo a nonsence.
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public bool IsEmpty()
        {
            return this is EmptyPagingInfo;
        }

        /// <summary>
        /// Indicates is this pagingInfo a nonsence.
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public static bool IsNullOrEmpty(PagingInfo pagingInfo)
        {
            return pagingInfo == null || pagingInfo is EmptyPagingInfo;
        }
    }
}
