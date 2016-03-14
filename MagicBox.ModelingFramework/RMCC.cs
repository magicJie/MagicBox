using System.Collections;
using System.Collections.Generic;
using MagicBox.MF.Models;

namespace MagicBox.MF
{
    public class RMCC: ICollection<ModelCollection>
    {
        public IEnumerator<ModelCollection> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ModelCollection item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(ModelCollection item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(ModelCollection[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(ModelCollection item)
        {
            throw new System.NotImplementedException();
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }

        public ModelCollection this[string modelCollectionName]
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
