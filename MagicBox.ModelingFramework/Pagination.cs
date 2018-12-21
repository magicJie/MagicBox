using System;

namespace MagicBox.MF
{
    [Serializable]
    public class Pagination
    {
        private int _pageCount;
        private int _pageIndex;
        private int _pageSize;
        private long _rowCount;

        public Pagination(int pageIndex, int pageSize)
        {
            this._pageIndex = pageIndex;
            this._pageSize = pageSize;
        }

        public Pagination(int pageIndex, int pageSize, int pageCount, int rowCount)
            : this(pageIndex, pageSize)
        {
            this._pageCount = pageCount;
            this._rowCount = rowCount;
        }

        public bool IsPagination
        {
            get
            {
                return (this._pageIndex > 0);
            }
        }

        public int PageCount
        {
            get
            {
                return this._pageCount;
            }
            set
            {
                this._pageCount = value;
            }
        }

        public int PageIndex
        {
            get
            {
                return this._pageIndex;
            }
            set
            {
                this._pageIndex = value;
            }
        }

        public int PageSize
        {
            get
            {
                return this._pageSize;
            }
            set
            {
                this._pageSize = value;
            }
        }

        public long RowCount
        {
            get
            {
                return this._rowCount;
            }
            set
            {
                this._rowCount = value;
            }
        }
    }
}
