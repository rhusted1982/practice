using System;

namespace General
{
    public class StringBuilder
    {
        private ArrayList<string> _strings = new ArrayList<string>();
        private int _length = 0;

        public void Append(string @string)
        {
            if (string.IsNullOrEmpty(@string))
                throw new ArgumentException(nameof(@string));
            _length += @string.Length;
            _strings.Add(@string);
        }

        public void Append(char[] chars)
        {
            if (chars == null || chars.Length == 0)
                throw new ArgumentException(nameof(chars));
            Append(new string(chars));
        }

        public void Append(char @char)
        {
            Append(@char.ToString());
        }

        public override string ToString()
        {
            if (_length == 0) return string.Empty;
            var array = new char[_length];
            var currentIndex = 0;
            for(var index = 0; index < _strings.Length; index++)
            {
                var currentString = _strings[index];
                for(var stringIndex = 0; stringIndex < currentString.Length; stringIndex++)
                {
                    array[currentIndex] = currentString[stringIndex];
                    currentIndex++;
                }
            }
            var @string = new string(array);
            _strings.Clear();
            _strings.Add(@string);
            return @string;
        }
    }
}
