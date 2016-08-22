using System;

namespace General
{
    public class Queue<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public void Push(T item)
        {
            _list.AddTail(item);
        }

        public T Pop()
        {
            return _list.RemoveHead();
        }

        public bool Peek()
        {
            return !_list.IsEmpty();
        }
    }

    public static class Queue
    {
        public static Queue<T> FromArray<T>(T[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            var queue = new Queue<T>();
            for (var index = 0; index < items.Length; index++)
                queue.Push(items[index]);
            return queue;
        }
    }
}
