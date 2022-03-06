using System.Collections;
using System.Collections.Generic;
using NotImplementedException = System.NotImplementedException;

namespace LeGrandRestaurant.Test.Helpers
{
    internal class DatabaseServeurRepository : IList<Serveur>
    {
        /// <inheritdoc />
        public IEnumerator<Serveur> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public void Add(Serveur item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Contains(Serveur item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void CopyTo(Serveur[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Remove(Serveur item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public int Count { get; }

        /// <inheritdoc />
        public bool IsReadOnly { get; }

        /// <inheritdoc />
        public int IndexOf(Serveur item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Insert(int index, Serveur item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Serveur this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
