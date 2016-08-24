using General;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreesAndGraphs
{
    [TestClass]
    public class Exercises
    {
        [TestMethod]
        public void BinarySearch()
        {
            var node = BinaryTree.CreateFromArray(new[] { 50, 30, 20, 40, 70, 60, 80 });
            Assert.AreEqual(50, BinaryTree.Search(node, 50));
            Assert.AreEqual(40, BinaryTree.Search(node, 40));
            Assert.AreEqual(60, BinaryTree.Search(node, 60));
            Assert.AreEqual(default(int), BinaryTree.Search(node, 90));
            Assert.AreEqual(default(int), BinaryTree.Search(node, 10));
        }
    }
}
