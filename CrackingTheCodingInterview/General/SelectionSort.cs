using System;

namespace General
{
    public static partial class SortFactory
    {
        //O(n^2) all time and O(n) space
        public static Sort<T> SelectionSort<T>() where T : IComparable
        {
            return (items) =>
            {
                if (items == null || items.Length <= 1) return;
                for(var i = 0; i < items.Length - 1; i++)
                {
                    var minIndex = i;
                    for(var j = i + 1; j < items.Length; j++)
                    {
                        if (items[minIndex].CompareTo(items[j]) > 0)
                            minIndex = j;
                    }
                    items.Swap(i, minIndex);
                }
            };
        }
    }
}
