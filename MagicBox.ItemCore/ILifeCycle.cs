using System;
using System.ComponentModel;

namespace MagicBox.ItemCore
{
    public interface ILifeCycle : IGeneralItem, IBaseItem, IEquatable<IBaseItem>, IComparable<IBaseItem>, INotifyPropertyChanged
    {
        string Description { get; set; }

        string Label { get; set; }

        IRIC LifeCycleState { get; }

        IRIC LifeCycleTransition { get; }

        string Name { get; set; }

        ILifeCycleState StartState { get; }
    }
}
