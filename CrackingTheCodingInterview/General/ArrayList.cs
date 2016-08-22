using System;

namespace General
{
    public class ArrayList<T>
    {
        private T[] _array = new T[0];
        public int Length { get; private set; }
        public void Add(T item)
        {
            ResizeIfNecessary();
            _array[Length] = item;
            Length++;
        }

        public void Remove(T item)
        {
            var count = 0;
            var remainingArray = new T[Length];
            for(var index = 0; index < Length; index++)
            {
                if(!item.Equals(_array[index]))
                {
                    remainingArray[count] = _array[index];
                    count++;
                }
            }
            _array = remainingArray;
            Length = count;
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index, nameof(index));
                return _array[index];
            }
            set
            {
                ValidateIndex(index, nameof(index));
                _array[index] = value;
            }
        }

        public void Clear()
        {
            _array = new T[0];
            Length = 0;
        }

        private void ResizeIfNecessary()
        {
            if (_array.Length != Length) return;
            var copy = _array;
            _array = new T[_array.Length == 0 ? 1 : _array.Length * 2];
            for (var index = 0; index < copy.Length; index++)
                _array[index] = copy[index];
        }

        private void ValidateIndex(int index, string paramName)
        {
            if (index < 0 || index >= Length)
                throw new ArgumentOutOfRangeException(paramName);
        }
    }
}
