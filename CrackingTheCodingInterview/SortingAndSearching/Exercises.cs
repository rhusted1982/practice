using General;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    [TestClass]
    public class Exercises
    {
        [TestMethod]
        public void SelectionSort()
        {
            Sort(SortFactory.SelectionSort<int>());
        }

        [TestMethod]
        public void BubbleSort()
        {
            Sort(SortFactory.BubbleSort<int>());
        }

        [TestMethod]
        public void MergeSort()
        {
            Sort(SortFactory.MergeSort<int>());
        }

        [TestMethod]
        public void QuickSort()
        {
            Sort(SortFactory.QuickSort<int>());
        }

        private void Sort(Sort<int> sorter)
        {
            var actual = new int[] { 1, 5, 3, 6, 4, 7, 9, 8, 2 };
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Sort(sorter, actual, expected);
        }

        [TestMethod]
        public void RadixSort()
        {
            var actual = new int[] { 170, 45, 75, 90, 802, 2, 24, 66 };
            var expected = new int[] { 2, 24, 45, 66, 75, 90, 170, 802 };
            Sort(SortFactory.RadixSort(), actual, expected);
        }

        private void Sort(Sort<int> sorter, int[] actual, int[] expected)
        {
            sorter.Invoke(actual);
            Assert.AreEqual(expected.Length, actual.Length);
            for (var index = 0; index < actual.Length; index++)
                Assert.AreEqual(expected[index], actual[index]);
        }
    }
}
