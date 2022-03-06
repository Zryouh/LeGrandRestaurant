using System.Collections;
using System.Collections.Generic;
using NotImplementedException = System.NotImplementedException;

namespace LeGrandRestaurant.Test.Helpers
{
    internal class DatabaseRestaurantRepository : IList<Restaurant>
    {
        /// <inheritdoc />
        public IEnumerator<Restaurant> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public void Add(Restaurant item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Contains(Restaurant item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void CopyTo(Restaurant[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Remove(Restaurant item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public int Count { get; }

        /// <inheritdoc />
        public bool IsReadOnly { get; }

        /// <inheritdoc />
        public int IndexOf(Restaurant item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Insert(int index, Restaurant item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Restaurant this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
