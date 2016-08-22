using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    public class LinkedList<T>
    {
        private LinkedListItem<T> _head;
        private LinkedListItem<T> _tail;
        private int _length = 0;

        public void AddTail(T item)
        {
            Add(item, @new =>
            {
                @new.Previous = _tail;
                _tail = _tail.Next = @new;
             });
        }

        public void AddHead(T item)
        {
            Add(item, @new =>
            {
                @new.Next = _head;
                _head.Previous = @new;
                _head = @new;
            });
        }

        public T RemoveHead()
        {
            var head = _head;
            if (head == null) return default(T);
            _head = _head.Next;
            if (_head != null)
                _head.Previous = null;
            _length--;
            return head.Value;
        }

        public void Remove(T item)
        {
            if (_length == 0) return;
            var match = FindNext(value => value.Equals(item), _head);
            if (match == null) return;
            if (match.Previous != null)
                match.Previous.Next = match.Next;
            if (match.Next != null)
                match.Next.Previous = match.Previous;
            _length--;
        }

        public bool IsEmpty()
        {
            return _length <= 0;
        }

        public T Find(Func<T, bool> match)
        {
            var item = FindNext(match, _head);
            return item == null ? default(T) : item.Value;
        }

        private void Add(T item, Action<LinkedListItem<T>> add)
        {
            var @new = new LinkedListItem<T> { Value = item };
            if (_head == null)
                _head = _tail = @new;
            else
                add(@new);
            _length++;
        }

        public IEnumerable<T> GetAll()
        {
            var array = new T[_length];
            var index = 0;
            var current = _head;
            while(current != null)
            {
                array[index] = current.Value;
                index++;
                current = current.Next;
            }
            return array;
        }

        public void RemoveDuplicatesWithoutHash()
        {
            if (_length <= 0) return;
            var current = _head;
            while(current != null)
            {
                var first = true;
                FindAndProcessMatches(value => value.Equals(current.Value), item =>
                {
                    if (!first)
                    {
                        if(item.Previous != null)
                            item.Previous.Next = item.Next;
                        if(item.Next != null)
                            item.Next.Previous = item.Previous;
                        _length--;
                    }
                    else
                        first = false;
                });
                current = current.Next;
            }
        }

        public void RemoveDuplicatesWithHash()
        {
            if (_length <= 0) return;
            var current = _head;
            var existing = new HashTable<T, T>();
            while(current != null)
            {
                if (existing.Exists(current.Value))
                {
                    if(current.Next != null)
                        current.Next.Previous = current.Previous;
                    if(current.Previous != null)
                    current.Previous.Next = current.Next;
                    _length--;
                }
                else
                    existing.Add(current.Value, current.Value);
                current = current.Next;
            }
        }

        public T FindLast(int index = 0)
        {
            var count = 0;
            var current = _tail;
            while(count < index)
            {
                if (current.Previous == null) return default(T);
                current = current.Previous;
                count++;
            }
            return current.Value;
        }

        private void FindAndProcessMatches(Func<T, bool> match, Action<LinkedListItem<T>> update)
        {
            var current = FindNext(match, _head);
            while(current != null)
            {
                update(current);
                current = FindNext(match, current.Next);
            }
        }

        private LinkedListItem<T> FindNext(Func<T, bool> match, LinkedListItem<T> current)
        {
            if (current == null) return null;
            if (match(current.Value)) return current;
            if (current.Next == null) return null;
            return FindNext(match, current.Next);
        }
    }

    public class LinkedListItem<T>
    {
        public LinkedListItem<T> Next { get; set; }
        public LinkedListItem<T> Previous { get; set; }
        public T Value { get; set; }
    }

    public static class LinkedList
    {
        public static LinkedList<T> CreateFromArray<T>(T[] items)
        {
            var list = new LinkedList<T>();
            if (items == null || items.Length == 0) return list;
            for (var index = 0; index < items.Length; index++)
                list.AddTail(items[index]);
            return list;
        }
    }
}
