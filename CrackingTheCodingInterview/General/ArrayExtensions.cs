using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    public static class ArrayExtensions
    {
        public static void Rotate<T>(this T[,] value)
        {
            if (value == null || value.Length <= 1) return;
            if (value.GetLength(0) != value.GetLength(1))
                throw new ArgumentException(nameof(value));
            var stack = new Stack<T[]>();
            var index = 0;
            for (index = 0; index < value.GetLength(0); index++)
                stack.Push(value.GetRow(index));
            index = 0;
            while (stack.Peek())
            {
                value.SetColumn(index, stack.Pop());
                index++;
            }     
        }

        private static T[] GetRow<T>(this T[,] value, int rowIndex)
        {
            var row = new T[value.GetLength(0)];
            for (var index = 0; index < value.GetLength(1); index++)
                row[index] = value[rowIndex, index];
            return row;
        }

        private static void SetRowWithValue<T>(this T[,] array, int rowIndex, T value)
        {
            for (var index = 0; index < array.GetLength(1); index++)
                array[rowIndex, index] = value;
        }

        private static void SetColumnWithValue<T>(this T[,] array, int columnIndex, T value)
        {
            for (var index = 0; index < array.GetLength(0); index++)
                array[index, columnIndex] = value;
        }

        private static void SetColumn<T>(this T[,] value, int columnIndex, T[] row)
        {
            for(var index = 0; index < row.Length; index++)
                value[index, columnIndex] = row[index];
        }

        public static void Zero<T>(this T[,] value, T zero)
        {
            if (value == null || value.Length == 0) return;
            var queue = new Queue<Tuple<int, int>>();
            for (var rowIndex = 0; rowIndex < value.GetLength(0); rowIndex++)
                for (var columnIndex = 0; columnIndex < value.GetLength(1); columnIndex++)
                    if (value[rowIndex, columnIndex].Equals(zero)) queue.Push(new Tuple<int, int>(rowIndex, columnIndex));
            while (queue.Peek())
            {
                var point = queue.Pop();
                value.SetRowWithValue(point.Item1, zero);
                value.SetColumnWithValue(point.Item2, zero);
            }
        }
    }
}
