using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MagicBox.ItemCore
{
    public interface IAttribute : IRelationship, IGeneralItem, IBaseItem, IEquatable<IBaseItem>, IComparable<IBaseItem>, INotifyPropertyChanged
    {
        string GetLowerLimit(out bool included);
        string GetSingleValue();
        string GetUpperLimit(out bool included);
        List<string> GetValueSet();
        AttributeValueType GetValueType();

        string Description { get; set; }

        string Name { get; set; }

        IUnitofMeasure Unit { get; set; }

        string Value { get; set; }
    }
}
