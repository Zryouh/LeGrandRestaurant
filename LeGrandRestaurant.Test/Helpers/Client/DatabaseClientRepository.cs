using System.Collections;
using System.Collections.Generic;
using NotImplementedException = System.NotImplementedException;

namespace LeGrandRestaurant.Test.Helpers
{
    internal class DatabaseClientRepository : IList<Client>
    {
        /// <inheritdoc />
        public IEnumerator<Client> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public void Add(Client item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Contains(Client item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void CopyTo(Client[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Remove(Client item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public int Count { get; }

        /// <inheritdoc />
        public bool IsReadOnly { get; }

        /// <inheritdoc />
        public int IndexOf(Client item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Insert(int index, Client item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Client this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
