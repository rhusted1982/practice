using System.Collections.Generic;

namespace General
{
    public class HashTable<TKey, TValue>
    {
        private LinkedList<HashItem<TKey, TValue>>[] _array = new LinkedList<HashItem<TKey, TValue>>[0];
        private const double LoadFactor = 0.75;
        private int _count;
        public void Add(TKey key, TValue value)
        {
            ResizeAndRehashIfNecessary();
            var item = new HashItem<TKey, TValue> { Key = key, Value = value };
            Add(item);
        }

        public bool Exists(TKey key)
        {
            if (_array.Length == 0) return false;
            var list = _array[GetHashCode(key)];
            if (list == null) return false;
            return list.Find(item => item.Key.Equals(key)) != null;
        }

        private void Add(HashItem<TKey, TValue> item)
        {
            var index = GetHashCode(item);
            var list = _array[index] = _array[index] ?? new LinkedList<HashItem<TKey, TValue>>();
            list.AddTail(item);
            _count++;
        }

        private void ResizeAndRehashIfNecessary()
        {
            if (_array.Length == 0)
                _array = new LinkedList<HashItem<TKey, TValue>>[2];
            else if(((double)_count + 1)/_array.Length > LoadFactor)
            {
                var items = GetAllItems();
                _array = new LinkedList<HashItem<TKey, TValue>>[_array.Length * 2];
                _count = 0;
                foreach (var item in items)
                    Add(item);
            }
        }

        private IEnumerable<HashItem<TKey, TValue>> GetAllItems()
        {
            var items = new HashItem<TKey, TValue>[_count];
            var itemIndex = 0;
            for(var index = 0; index < _array.Length; index++)
            {
                if (_array[index] == null) continue;
                foreach(var item in _array[index].GetAll())
                {
                    items[itemIndex] = item;
                    itemIndex++;
                }
            }
            return items;
        }

        private int GetHashCode(HashItem<TKey, TValue> item)
        {
            return GetHashCode(item.Key);
        }

        private int GetHashCode(TKey key)
        {
            return key.GetHashCode() % _array.Length;
        }
    }

    public class HashItem<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}
