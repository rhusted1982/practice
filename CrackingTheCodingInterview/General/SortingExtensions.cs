using System;

namespace General
{
    internal static class SortingExtensions
    {
        public static void Swap<T>(this T[] items, int first, int second) where T : IComparable
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (first < 0 || first >= items.Length) throw new ArgumentOutOfRangeException(nameof(first));
            if (second < 0 || second >= items.Length) throw new ArgumentOutOfRangeException(nameof(second));
            if (first == second) return;
            var swap = items[first];
            items[first] = items[second];
            items[second] = swap;
        }

        public static T[][] Split<T>(this T[] items) where T : IComparable
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (items.Length <= 1) throw new ArgumentException(nameof(items));
            var midpoint = items.Length / 2;
            var firstSet = new T[midpoint];
            for (var index = 0; index < midpoint; index++)
                firstSet[index] = items[index];
            var secondSet = new T[items.Length - midpoint];
            for (var index = midpoint; index < items.Length; index++)
                secondSet[index - midpoint] = items[index];
            return new T[2][] { firstSet, secondSet };
        }
    }
}
