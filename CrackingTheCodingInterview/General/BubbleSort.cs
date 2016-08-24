using System;

namespace General
{
    public static partial class SortFactory
    {
        //O(n) best, O(n^2) rest time, O(n) space
        public static Sort<T> BubbleSort<T>() where T : IComparable
        {
            return (items) =>
            {
                if (items == null || items.Length <= 1) return;
                var swapped = false;
                do
                {
                    swapped = false;
                    for (var index = 0; index < items.Length - 1; index++)
                    {
                        if(items[index].CompareTo(items[index + 1]) > 0)
                        {
                            items.Swap(index, index + 1);
                            swapped = true;
                        }
                    }

                } while (swapped);

            };
        }
    }
}
