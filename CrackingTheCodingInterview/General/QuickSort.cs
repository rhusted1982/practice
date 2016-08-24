using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    public static partial class SortFactory
    {
        public static Sort<T> QuickSort<T>() where T : IComparable
        {
            return items =>
            {
                if (items == null || items.Length <= 1) return;
                QuickSort(items, 0, items.Length - 1);
            };
        }

        private static void QuickSort<T>(T[] items, int left, int right) where T : IComparable
        {
            if (left >= right) return;
            var pivot = (right - left) / 2 + left;
            var value = items[pivot];
            var currentLeft = left;
            var currentRight = right;
            while(currentLeft != currentRight)
            {
                while (currentLeft < pivot && items[currentLeft].CompareTo(value) <= 0) currentLeft++;
                while (currentRight > pivot && items[currentRight].CompareTo(value) > 0) currentRight--;
                if (currentLeft != pivot && currentRight != pivot)
                    items.Swap(currentLeft, currentRight);
                else if(currentLeft != pivot)
                {
                    items.Swap(currentLeft, pivot);
                    pivot = currentLeft;
                }
                else if(currentRight != pivot)
                {
                    items.Swap(pivot, currentRight);
                    pivot = currentRight;
                }
                else
                {
                    QuickSort(items, left, pivot - 1);
                    QuickSort(items, pivot + 1, right);
                }
            }
        }
    }
}
