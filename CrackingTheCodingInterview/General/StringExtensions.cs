using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    public static class StringExtensions
    {
        public static char[] ToAlphabeticOrder(this string value)
        {
            if (string.IsNullOrEmpty(value)) return new char[0];
            var array = value.ToLowerInvariant().ToCharArray();
            SortFactory.SelectionSort<char>().Invoke(array);
            return array;
        }

        public static bool IsUnique(this string value)
        {
            var chars = value.ToAlphabeticOrder();
            for (var index = 0; index < chars.Length - 1; index++)
                if (chars[index] == chars[index + 1]) return false;
            return true;
        }

        public static bool IsPermutation(this string value, string other)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(other) || value.Length != other.Length)
                return false;
            var valueChars = value.ToAlphabeticOrder();
            var otherChars = other.ToAlphabeticOrder();
            for (var index = 0; index < valueChars.Length; index++)
                if (valueChars[index] != otherChars[index])
                    return false;
            return true;
        }

        public static string Urlify(this string value, int length)
        {
            var chars = value.ToCharArray();
            var builder = new StringBuilder();
            for (var index = 0; index < Math.Min(chars.Length, length); index++)
            {
                if (chars[index] == ' ')
                    builder.Append("%20");
                else
                    builder.Append(chars[index]);
            }
            return builder.ToString();
        }

        public static bool IsPalindromePermutation(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            var chars = value.ToAlphabeticOrder();
            var foundSingleCharacter = false;
            var oddThreeOrMoreGroups = 0;
            var lastChar = ' ';
            var characters = 0;
            for(var index = 0; index < chars.Length; index++)
            {
                if (chars[index] == ' ')
                    continue;
                if (lastChar == ' ')
                    lastChar = chars[index];
                if (lastChar == chars[index])
                    characters++;
                if (lastChar != chars[index])
                {
                    if (characters == 1)
                    {
                        if (foundSingleCharacter)
                            return false;
                        else
                            foundSingleCharacter = true;
                    }
                    else if (characters % 2 == 1)
                        oddThreeOrMoreGroups++;
                    characters = 1;
                }
                lastChar = chars[index];
            }
            if (foundSingleCharacter && characters == 1)
                return false;
            return !(foundSingleCharacter && oddThreeOrMoreGroups % 2 == 1);
        }

        public static bool IsOneEditAway(this string value, string compare)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (compare == null)
                throw new ArgumentNullException(nameof(compare));
            if (value == string.Empty && compare == string.Empty) return false;
            if (Math.Abs(value.Length - compare.Length) > 1) return false;
            var largerValue = value.Length < compare.Length ? compare.ToCharArray() : value.ToCharArray();
            var smallerValue = value.Length >= compare.Length ? compare.ToCharArray() : value.ToCharArray();
            var difference = 0;
            var inserts = 0;
            for(var index = 0; index < smallerValue.Length; index++)
            {
                if (smallerValue[index] == largerValue[index + inserts])
                    continue;
                if (smallerValue.Length < largerValue.Length && smallerValue[index] == largerValue[index + 1])
                    inserts = 1;
                difference++;
                if (difference > 1)
                    return false;
            }
            if (smallerValue.Length < largerValue.Length && inserts == 0)
                difference++;
            return difference == 1;
        }

        public static string Compress(this string value)
        {
            if(value == null)
                throw new ArgumentNullException(nameof(value));
            if (value.Length == 0) return string.Empty;
            var chars = value.ToCharArray();
            var count = 1;
            var builder = new StringBuilder();
            var lastChar = chars[0];
            for(var index = 1; index < value.Length; index++)
            {
                if (lastChar == chars[index])
                    count++;
                else
                {
                    builder.Append(lastChar);
                    builder.Append(count.ToString());
                    lastChar = chars[index];
                    count = 1;
                }
            }
            builder.Append(lastChar);
            builder.Append(count.ToString());
            var compressed = builder.ToString();
            return compressed.Length < value.Length ? compressed : value;
        }

        public static bool IsRotation(this string value, string other)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(other) || value.Length != other.Length) return false;
            var valueQueue = Queue.FromArray(value.ToCharArray());
            var otherArray = other.ToCharArray();
            var beginQueue = new Queue<char>();
            var endQueue = new Queue<char>();
            var matches = 0;
            while(valueQueue.Peek())
            {
                var letter = valueQueue.Pop();
                if (letter == otherArray[matches])
                {
                    beginQueue.Push(letter);
                    matches++;
                }
                else
                {
                    if (matches > 0)
                        while (beginQueue.Peek())
                            endQueue.Push(beginQueue.Pop());
                    endQueue.Push(letter);
                    matches = 0;
                }
            }
            if (matches == 0) return false;
            for (var index = matches; index < otherArray.Length; index++)
                if (!endQueue.Peek() || otherArray[index] != endQueue.Pop())
                    return false;
            return true;

        }
    }
}
