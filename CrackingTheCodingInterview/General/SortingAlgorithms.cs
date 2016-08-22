using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    internal delegate T[] Sort<T>(T[] items);
    internal static partial class SortingAlgorithms<T>  where T : IComparable
    {
    }
}
