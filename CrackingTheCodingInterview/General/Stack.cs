namespace General
{
    public class Stack<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public void Push(T item)
        {
            _list.AddHead(item);
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
}
