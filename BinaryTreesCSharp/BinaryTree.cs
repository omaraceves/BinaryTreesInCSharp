using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreesCSharp
{
    /// <summary>
    /// Binary Tree class
    /// </summary>
    public partial class BinaryTree
    {
        #region Private Fields
        private List<Node> _tree;
        #endregion

        #region Properties
        /// <summary>
        /// Tree 
        /// </summary>
        public List<Node> Tree
        {
            get
            {
                if (_tree == null)
                {
                    _tree = new List<Node>();
                }

                return _tree;
            }

        }

        /// <summary>
        /// Root
        /// </summary>
        public Node Root
        {
            get
            {
                if (_tree == null)
                {
                    return null;
                }

                return _tree[0];
            }
        }
        #endregion

        #region Ctor
        /// <summary>
        /// Ctor
        /// </summary>
        public BinaryTree()
        { }
        #endregion

        #region Public Methods
        /// <summary>
        /// Builds tree
        /// </summary>
        /// <param name="elements">Array of elements</param>
        /// <returns>Tree</returns>
        public List<Node> Build(string[] elements)
        {
            for (int i = 0; i <= (elements.Length - 1); i++)
            {
                var newNode = GetNewNode(elements[i]);
                Tree.Add(newNode);
                CompareAndInsertNext(newNode, Root);

            }
            return Tree;
        }

        /// <summary>
        /// Add node to the left of root
        /// </summary>
        /// <param name="root">Root node</param>
        /// <param name="node">Node to be added</param>
        public void AddLeft(Node root, Node node)
        {
            if (root.Left != null)
            {
                return;
            }
            else
            {
                root.Left = node;
                Tree.Add(node);
            }
        }

        /// <summary>
        /// Add node to the right of root
        /// </summary>
        /// <param name="root">Root node</param>
        /// <param name="node">Node to be added</param>
        public void AddRight(Node root, Node node)
        {
            if (root.Right != null)
            {
                return;
            }
            else
            {
                root.Right = node;
                Tree.Add(node);
            }
        }

        /// <summary>
        /// Returns max depth of a tree
        /// </summary>
        /// <param name="root">Root node</param>
        /// <returns>Max depth value</returns>
        public int MaxDepth(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            int resultleft = MaxDepth(root.Left);
            int resultright = MaxDepth(root.Right);

            return Math.Max(resultleft, resultright) + 1;
        }

        /// <summary>
        /// Evaluates if a tree is symmetric
        /// </summary>
        /// <param name="root">Root node</param>
        /// <returns>Symmetric evaluation result</returns>
        public bool IsSymmetric(Node root)
        {
            if (root == null)
            {
                return true;
            }


            return IsSymmetric(root.Left, root.Right);
        }

        /// <summary>
        /// Evaluates if a tree is symmetric
        /// </summary>
        /// <param name="left">Left node</param>
        /// <param name="right">Right node</param>
        /// <returns>Symmetric evaluation result</returns>
        public bool IsSymmetric(Node left, Node right)
        {
            if (left == null && right == null)
            {
                return true;
            }
            else if (left == null || right == null)
            {
                return false;
            }

            if (left.strValue == right.strValue)
            {
                if (IsSymmetric(left.Left, right.Right))
                {
                    return IsSymmetric(left.Right, right.Left);
                }
            }

            return false;
        }

        /// <summary>
        /// Determines if a tree has a path such that adding up all the values along the path equals the given target.
        /// </summary>
        /// <param name="root">Root node</param>
        /// <param name="target">Target value</param>
        /// <returns>Sum path evaluation</returns>
        public bool HasSumPath(Node root, int target)
        {
            if(root == null)
            {
                return false;
            }

            if(root.Left == null && root.Right == null)
            {
                return root.intValue == target;
            }

            return (HasSumPath(root.Left, target - root.intValue) || HasSumPath(root.Right, target - root.intValue));
        }

        /// <summary>
        /// Counts the number of unival subtrees
        /// </summary>
        /// <param name="root">Root node</param>
        /// <param name="count">Count value</param>
        /// <returns>Number of unival subtrees</returns>
        public bool UnivalCount(Node root, ref int count)
        {
            if(root == null)
            {
                return true;
            }

            var left = UnivalCount(root.Left, ref count);
            var right = UnivalCount(root.Right, ref count);

            if(left == false || right == false)
            {
                return false;
            }

            if(root.Left != null && root.intValue != root.Left.intValue)
            {
                return false;
            }

            if (root.Right != null && root.intValue != root.Right.intValue)
            {
                return false;
            }

            count++;
            return true;
        }

        /// <summary>
        /// Builds a tree given inOrder and postOrder values
        /// </summary>
        /// <param name="inorder">inOrder values</param>
        /// <param name="postorder">postOrder values</param>
        /// <returns>Root node</returns>
        public Node BuildTreeWithInOrderAndPostOrder(int[] inorder, int[] postorder)
        {
            if (inorder == null || postorder == null || inorder.Length != postorder.Length)
                return null;

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < inorder.Length; i++)
            {
                map.Add(inorder[i], i);
            }

            return MyVersionOfBuidBninaryTree(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1, map);
        }




        #endregion

        #region Private Methods

        /// <summary>
        /// Core logic to build a tree given inOrder and postOrder values
        /// </summary>
        /// <param name="inOrder">in order value collection</param>
        /// <param name="inOrderStart">in order start index</param>
        /// <param name="inOrderEnd">in order end index</param>
        /// <param name="postOder">post order value collection</param>
        /// <param name="postOrderStart">post order start index</param>
        /// <param name="postOrderEnd">post order end index</param>
        /// <param name="inOrderIndexes">Dictionary with in order position indexes</param>
        /// <returns>Root node with subtrees</returns>
        private Node MyVersionOfBuidBninaryTree(int[] inOrder, int inOrderStart, int inOrderEnd, int[] postOder, int postOrderStart, int postOrderEnd, Dictionary<int, int> inOrderIndexes)
        {
            //return null if start > end
            if (inOrderStart > inOrderEnd && postOrderStart > postOrderEnd)
            {
                return null;
            }

            //Get root and index from postOrder latest value
            Node root = new Node();
            root.intValue = postOder[postOrderEnd];
            int index = inOrderIndexes[root.intValue];

            //Get left and right subtrees of root
            root.Left = MyVersionOfBuidBninaryTree(inOrder, inOrderStart, index - 1, postOder, postOrderStart, postOrderStart + ((index - 1) - inOrderStart), inOrderIndexes);
            root.Right = MyVersionOfBuidBninaryTree(inOrder, index + 1, inOrderEnd, postOder, postOrderStart + (index - inOrderStart), postOrderEnd - 1, inOrderIndexes);

            //Add node to tree
            this.Tree.Add(root);

            //return node
            return root;
        }

        /// <summary>
        /// Gets new node
        /// </summary>
        /// <param name="strValue">String value</param>
        /// <returns>Node</returns>
        private Node GetNewNode(string strValue)
        {
            return new Node()
            {
                strValue = strValue
            };
        }

        /// <summary>
        /// Tree builder helper
        /// </summary>
        /// <param name="newNode">New node</param>
        /// <param name="currentNode">Root or current node</param>
        private void CompareAndInsertNext(Node newNode, Node currentNode)
        {
            switch (string.Compare(newNode.strValue, currentNode.strValue))
            {
                case -1:

                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                    }
                    else
                    {
                        CompareAndInsertNext(newNode, currentNode.Left);
                    }
                    break;

                case 1:

                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                    }
                    else
                    {
                        CompareAndInsertNext(newNode, currentNode.Right);
                    }
                    break;

                default:
                    break;
            }
        }

       
        #endregion

        #region Node Class
        /// <summary>
        /// Node Calss
        /// </summary>
        public class Node
        {
            /// <summary>
            /// Left pointer
            /// </summary>
            public Node Left { get; set; }

            /// <summary>
            /// Right pointer
            /// </summary>
            public Node Right { get; set; }

            /// <summary>
            /// String value
            /// </summary>
            public string strValue { get; set; }

            /// <summary>
            /// String value
            /// </summary>
            public int intValue { get; set; }

            /// <summary>
            /// Ctor
            /// </summary>
            public Node() { }

            /// <summary>
            /// Ctor
            /// </summary>
            /// <param name="value">int value</param>
            public Node(int value)
            {
                intValue = value;
                strValue = value.ToString();   
            }
        }
        #endregion
    }
}
