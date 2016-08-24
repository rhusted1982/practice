using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    public static partial class SortFactory
    {
        public static Sort<int> RadixSort()
        {
            return items =>
            {
                if (items == null || items.Length <= 1) return;
                var buckets = new Queue<int>[10];
                for (var index = 0; index < buckets.Length; index++)
                    buckets[index] = new Queue<int>();
                var divisor = 1;
                var anotherIterationNeeded = true;
                while (anotherIterationNeeded)
                {
                    anotherIterationNeeded = false;
                    for (var index = 0; index < items.Length; index++)
                        buckets[items[index] / divisor % 10].Push(items[index]);
                    var itemIndex = 0;
                    divisor *= 10;
                    for (var index = 0; index < buckets.Length; index++)
                        while(buckets[index].Peek())
                        {
                            var value = buckets[index].Pop();
                            if (value / divisor % 10 > 0) anotherIterationNeeded = true;
                            items[itemIndex] = value;
                            itemIndex++;
                        }
                    
                }
            };
        }
    }
}
