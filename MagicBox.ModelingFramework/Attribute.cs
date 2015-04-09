using System;
using System.ComponentModel;

namespace MagicBox.MF
{
    public class Attribute : Relationship, IEquatable<BaseModel>, IComparable<BaseModel>, INotifyPropertyChanged
    {
        public bool Equals(BaseModel other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(BaseModel other)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
