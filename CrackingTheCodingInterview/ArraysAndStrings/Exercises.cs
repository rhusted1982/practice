using General;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArraysAndStrings
{
    [TestClass]
    public class Exercises
    {
        [TestMethod]
        public void IsUnique()
        {
            Assert.IsTrue("cab".IsUnique());
            Assert.IsTrue(string.Empty.IsUnique());
            Assert.IsFalse("cCab".IsUnique());
        }

        [TestMethod]
        public void IsPermutation()
        {
            Assert.IsTrue("cab".IsPermutation("abc"));
            Assert.IsFalse("".IsPermutation(""));
            Assert.IsFalse("abd".IsPermutation("abc"));
            Assert.IsFalse("abcc".IsPermutation("abc"));
        }

        [TestMethod]
        public void Urlify()
        {
            Assert.AreEqual("Mr%20John%20Smith", "Mr John Smith  ".Urlify(13));
        }

        [TestMethod]
        public void Palindrome()
        {
            Assert.IsTrue("Tact Coa".IsPalindromePermutation());
            Assert.IsTrue("A a".IsPalindromePermutation());
            Assert.IsFalse(string.Empty.IsPalindromePermutation());
            Assert.IsFalse("Tac Coa".IsPalindromePermutation());
        }

        [TestMethod]
        public void OneAway()
        {
            Assert.IsTrue("pale".IsOneEditAway("ple"));
            Assert.IsTrue("pales".IsOneEditAway("pale"));
            Assert.IsTrue("pale".IsOneEditAway("bale"));
            Assert.IsFalse("pale".IsOneEditAway("bake"));
        }

        [TestMethod]
        public void Compress()
        {
            Assert.AreEqual("a2b1c5a3", "aabcccccaaa".Compress());
            Assert.AreEqual("aa", "aa".Compress());
        }

        [TestMethod]
        public void Rotate()
        {
            var array = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var expectedArray = new int[,] { { 7, 4, 1 }, { 8, 5, 2 }, { 9, 6, 3 } };
            array.Rotate();
            for (var rowIndex = 0; rowIndex < array.GetLength(0); rowIndex++)
                for (var columnIndex = 0; columnIndex < array.GetLength(1); columnIndex++)
                    Assert.AreEqual(expectedArray[rowIndex, columnIndex], array[rowIndex, columnIndex]);
            
        }

        [TestMethod]
        public void Zero()
        {
            var array = new int[,] { { 0, 1, 1 }, { 1, 1, 1 }, { 1, 1, 0 } };
            var expectedArray = new int[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
            array.Zero(0);
            for (var rowIndex = 0; rowIndex < array.GetLength(0); rowIndex++)
                for (var columnIndex = 0; columnIndex < array.GetLength(1); columnIndex++)
                    Assert.AreEqual(expectedArray[rowIndex, columnIndex], array[rowIndex, columnIndex]);
        }

        [TestMethod]
        public void StringRotation()
        {
            Assert.IsTrue("erbottlewat".IsRotation("waterbottle"));
            Assert.IsFalse("rbootlewat".IsRotation("waterbottle"));
        }
    }
}
