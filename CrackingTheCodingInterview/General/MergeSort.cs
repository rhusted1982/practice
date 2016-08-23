using System;

namespace General
{
    internal static partial class SortFactory
    {
        public static Sort<T> MergeSort<T>() where T : IComparable
        {
            return items =>
            {
                if (items == null || items.Length <= 1) return;
                items = MergeSort(items);
            };
        }

        private static T[] MergeSort<T>(T[] items) where T : IComparable
        {
            if (items.Length == 1) return items;
            var splitItems = items.Split();
            for (var index = 0; index < 2; index++)
                splitItems[index] = MergeSort(splitItems[index]);
            return Merge(splitItems[0], splitItems[1]);
        }

        private static T[] Merge<T>(T[] first, T[] second) where T : IComparable
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (first.Length <= 0) throw new ArgumentException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            if (second.Length <= 0) throw new ArgumentException(nameof(second));
            var result = new T[first.Length + second.Length];
            var firstIndex = 0;
            var secondIndex = 0;
            var compare = 0;
            while (firstIndex + secondIndex < result.Length)
            {
                if (firstIndex == first.Length)
                    compare = 1;
                else if (secondIndex == second.Length)
                    compare = -1;
                else
                    compare = first[firstIndex].CompareTo(second[secondIndex]);
                if (compare <= 0)
                {
                    result[firstIndex + secondIndex] = first[firstIndex];
                    firstIndex++;
                }
                if (compare >= 0)
                {
                    result[firstIndex + secondIndex] = second[secondIndex];
                    secondIndex++;
                }
            }
            return result;
        }

    }
}
