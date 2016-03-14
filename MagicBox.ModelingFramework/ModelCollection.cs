using System;
using System.Collections;
using System.Collections.Generic;
using MagicBox.MF.Models;

namespace MagicBox.MF
{
    public class ModelCollection: ICollection<Model>
    {

        public void AddRange(Model[] models)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Model> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Model item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Model item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Model[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Model item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }
    }
}
