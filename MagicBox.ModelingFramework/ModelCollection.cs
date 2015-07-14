using System;
using System.Collections;
using System.Collections.Generic;
using MagicBox.MF.Domain;

namespace MagicBox.MF
{
    public class ModelCollection: ICollection
    {
        public ModelCollection()
        {
        }

        public ModelCollection(DbNativeQuery dbNativeQuery)
        {
            throw new System.NotImplementedException();
        }

        public DbNativeQuery DbNativeQuery
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public void Add(Model model)
        {
            throw new System.NotImplementedException();
        }

        public void AddRange(List<Model> listModel)
        {
            throw new System.NotImplementedException();
        }

        public void Load()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new System.NotImplementedException();
        }

        public Model RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public void SaveAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
