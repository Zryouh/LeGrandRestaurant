using System.Collections;
using System.Collections.Generic;
using NotImplementedException = System.NotImplementedException;

namespace LeGrandRestaurant.Test.Helpers
{
    internal class DatabaseTableRepository : IList<Table>
    {
        /// <inheritdoc />
        public IEnumerator<Table> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public void Add(Table item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Contains(Table item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void CopyTo(Table[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Remove(Table item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public int Count { get; }

        /// <inheritdoc />
        public bool IsReadOnly { get; }

        /// <inheritdoc />
        public int IndexOf(Table item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Insert(int index, Table item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Table this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
