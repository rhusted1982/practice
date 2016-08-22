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
    }
}
