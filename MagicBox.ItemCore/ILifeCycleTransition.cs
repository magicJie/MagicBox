using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicBox.ItemCore
{
    public interface ILifeCycleTransition : IRelationship, IGeneralItem, IBaseItem, IEquatable<IBaseItem>, IComparable<IBaseItem>, INotifyPropertyChanged
    {
    }
}
