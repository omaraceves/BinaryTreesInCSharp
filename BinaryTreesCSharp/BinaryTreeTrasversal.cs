using System;
using System.Collections.Generic;
using BinaryTreesCSharp.Model;

namespace BinaryTreesCSharp
{
    public partial class BinaryTree
    {
        /// <summary>
        /// Traverse Top Down
        /// </summary>
        public void TraverseTopDown()
        {
            TopDownHelper(Root);
        }

        /// <summary>
        /// Top down helper
        /// </summary>
        /// <param name="node">Root or current node</param>
        private void TopDownHelper(Node node)
        {
            Console.WriteLine(node.strValue);
            if (node.Left != null)
            {
                TopDownHelper(node.Left);
            }
            if (node.Right != null)
            {
                TopDownHelper(node.Right);
            }
        }

        /// <summary>
        /// Traverse Bottom Up
        /// </summary>
        public void TraverseBottomUp()
        {
            BottomUpHelper(Root);
        }

        /// <summary>
        /// Bottom up helper 
        /// </summary>
        /// <param name="node">Root or current node</param>
        private void BottomUpHelper(Node node)
        {
            if (node.Left != null)
            {
                BottomUpHelper(node.Left);
            }

            if (node.Right != null)
            {
                BottomUpHelper(node.Right);
            }

            Console.WriteLine(node.strValue);
        }

        /// <summary>
        /// Traverse in order
        /// </summary>
        public void TraverseInOrder()
        {
            InOrderHelper(Root);
        }

        /// <summary>
        /// In order helper
        /// </summary>
        /// <param name="node">Root or current node</param>
        private void InOrderHelper(Node node)
        {
            if (node == null)
            {
                return;
            }

            InOrderHelper(node.Left);
            Console.WriteLine(node.strValue);
            InOrderHelper(node.Right);
        }

        /// <summary>
        /// Traverse by level
        /// </summary>
        public void TraverseLevelOrder()
        {
            Queue<Node> queue = new Queue<Node>();

            if (Root != null)
            {
                queue.Enqueue(Root);
                Node currentNode;

                while (queue.Count > 0)
                {
                    int size = queue.Count;

                    for (int i = 0; i < size; i++)
                    {
                        currentNode = queue.Dequeue();
                        Console.WriteLine(currentNode.strValue);

                        if (currentNode.Left != null)
                        {
                            queue.Enqueue(currentNode.Left);
                        }
                        if (currentNode.Right != null)
                        {
                            queue.Enqueue(currentNode.Right);
                        }
                    }
                }
            }
        }
    }
}
