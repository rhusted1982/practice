using General;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LinkedLists
{
    [TestClass]
    public class Exercises
    {
        [TestMethod]
        public void RemoveDuplicatesWithoutHash()
        {
            var linkedList = LinkedList.CreateFromArray(new[] { 1, 3, 2, 1, 2 });
            linkedList.RemoveDuplicatesWithoutHash();
            var actual = linkedList.GetAll().ToArray();
            var expected = new[] { 1, 3, 2 };
            Assert.AreEqual(expected.Length, actual.Length);
            for (var index = 0; index < actual.Length; index++)
                Assert.AreEqual(expected[index], actual[index]);
        }

        [TestMethod]
        public void RemoveDuplicatesWithHash()
        {
            var linkedList = LinkedList.CreateFromArray(new[] { 1, 3, 2, 1, 2 });
            linkedList.RemoveDuplicatesWithHash();
            var actual = linkedList.GetAll().ToArray();
            var expected = new[] { 1, 3, 2 };
            Assert.AreEqual(expected.Length, actual.Length);
            for (var index = 0; index < actual.Length; index++)
                Assert.AreEqual(expected[index], actual[index]);
        }

        [TestMethod]
        public void FindLastElement()
        {
            var linkedList = LinkedList.CreateFromArray(new[] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(5, linkedList.FindLast());
            Assert.AreEqual(2, linkedList.FindLast(3));
            Assert.AreEqual(0, linkedList.FindLast(5));
        }

        [TestMethod]
        public void RemoveElement()
        {
            var linkedList = LinkedList.CreateFromArray(new[] { 1, 2, 3, 4, 5 });
            linkedList.Remove(3);
            var expected = new[] { 1, 2, 4, 5 };
            var actual = linkedList.GetAll().ToArray();
            Assert.AreEqual(expected.Length, actual.Length);
            for (var index = 0; index < actual.Length; index++)
                Assert.AreEqual(expected[index], actual[index]);
            linkedList.Remove(6);
            actual = linkedList.GetAll().ToArray();
            Assert.AreEqual(expected.Length, actual.Length);
            for (var index = 0; index < actual.Length; index++)
                Assert.AreEqual(expected[index], actual[index]);
        }

        //[TestMethod]
        //public void Partition()
        //{
        //    var linkedList = LinkedList.CreateFromArray(new[] { 3, 5, 8, 5, 10, 2 , 1});
        //    var expected = new[] { 3, 1, 2, 10, 5, 5, 8 };
        //    linkedList.Partition(5);
        //    var actual = linkedList.GetAll().ToArray();
        //    Assert.AreEqual(expected.Length, actual.Length);
        //    for (var index = 0; index < actual.Length; index++)
        //        Assert.AreEqual(expected[index], actual[index]);
        //}
    }
}
