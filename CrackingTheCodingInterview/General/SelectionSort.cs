using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    internal static partial class SortingAlgorithms<T>
    {
        public static Sort<T> SelectionSort = (items) =>
        {
            if (items == null || items.Length == 0) return new T[0];
            var list = new T[items.Length];
            for(var index = 0; index < items.Length; index++)
                list[index] = items[index];
            for(var index = 0; index < items.Length - 1; index++)
            {
                var minIndex = index;
                for(var compareIndex = index + 1; compareIndex < items.Length; compareIndex++)
                {
                    if (list[minIndex].CompareTo(list[compareIndex]) > 0)
                        minIndex = compareIndex;
                }
                if(minIndex != index)
                {
                    var value = list[index];
                    list[index] = list[minIndex];
                    list[minIndex] = value;
                }
            }
            return list;
        };
    }
}
