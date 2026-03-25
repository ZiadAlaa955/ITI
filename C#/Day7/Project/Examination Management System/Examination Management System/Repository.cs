using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System
{
    public class Repository<T> where T : ICloneable, IComparable<T>
    {
        private T[] _items;
        public int Count { get; private set; }

        public Repository(int initialSize = 5)
        {
            _items = new T[initialSize];
            Count = 0;
        }

        public void Add(T item)
        {
            if (Count == _items.Length)
                Array.Resize(ref _items, _items.Length * 2);
            _items[Count] = item;
            Count++;
        }

        public void Remove(T item)
        {
            int index = Array.IndexOf(_items, item, 0, Count);
            if (index >= 0)
            {
                for (int i = index; i < Count - 1; i++)
                    _items[i] = _items[i + 1];

                _items[Count - 1] = default;
                Count--;
            }
        }

        public void Sort()
        {
            Array.Sort(_items, 0, Count);
        }

        public T[] GetAll()
        {
            T[] result = new T[Count];
            for (int i = 0; i < Count; i++)
                result[i] = (T)_items[i].Clone();
            return result;
        }
    }
}
