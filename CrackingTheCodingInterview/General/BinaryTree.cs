using System;

namespace General
{
    public class BinaryTreeNode<T> where T : IComparable
    {
        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public T Value { get; set; }
    }

    public static class BinaryTree
    {
        public static BinaryTreeNode<T> CreateFromArray<T>(T[] items) where T : IComparable
        {
            if (items == null || items.Length <= 0 ) return null;
            var node = new BinaryTreeNode<T>() { Value = items[0] };
            for (var index = 1; index < items.Length; index++)
                AddNode(items[index], node);
            return node;
        }

        public static T Search<T>(BinaryTreeNode<T> node, T value) where T : IComparable
        {
            if (node == null) return default(T);
            var current = node;
            while(current != null)
            {
                var compare = current.Value.CompareTo(value);
                if (compare == 0)
                    return value;
                else if (compare > 0)
                    current = current.Left;
                else
                    current = current.Right;
            }
            return default(T);
        }

        private static void AddNode<T>(T value, BinaryTreeNode<T> node) where T : IComparable
        {
            if (node == null) return;
            if(value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                    node.Left = new BinaryTreeNode<T>() { Value = value };
                else
                    AddNode(value, node.Left);

            }
            else if(value.CompareTo(node.Value) > 0)
            {
                if (node.Right == null)
                    node.Right = new BinaryTreeNode<T>() { Value = value };
                else
                    AddNode(value, node.Right);
            }
        }
    }
}
