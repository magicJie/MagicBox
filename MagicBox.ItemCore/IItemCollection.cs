using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicBox.ItemCore
{
    public interface IItemCollection : IList<IBaseItem>, ICollection<IBaseItem>, IEnumerable<IBaseItem>, IEnumerable
    {
        void BatchLoadItemPropertyItems(IProperty property);
        void DeleteAll();
        void FirstPage();
        void ForwardPage();
        List<ItemRef> GetItemRefs();
        void GotoPage(int pageIndex);
        void LastPage();
        void Load();
        void NextPage();
        void Reload();
        void Reset();
        void ResetAll();
        void SaveAll();

        Wisense.Common.Item.DbNativeQuery DbNativeQuery { get; }

        bool IsIdentityControl { get; set; }

        bool IsPagination { get; }

        bool ItemsBatchLoading { get; set; }

        bool Loaded { get; }

        Wisense.Common.Item.Pagination Pagination { get; }
    }
}
