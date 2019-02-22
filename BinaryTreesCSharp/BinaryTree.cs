using System;
using System.Collections.Generic;
using System.Text;
using BinaryTreesCSharp.Model;

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

            return MyVersionOfBuidBninaryTreeWithInOrderAndPostOrder(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1, map);
        }

        /// <summary>
        /// Builds a tree given inOrder and postOrder values
        /// </summary>
        /// <param name="inorder">inOrder values</param>
        /// <param name="postorder">postOrder values</param>
        /// <returns>Root node</returns>
        public Node BuildTreeWithInOrderAndPreOrder(int[] inorder, int[] preorder)
        {
            if (inorder == null || preorder == null || inorder.Length != preorder.Length)
                return null;

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < inorder.Length; i++)
            {
                map.Add(inorder[i], i);
            }

            return MyVersionOfBuidBninaryTreeWithInOrderAndPreOrder(inorder, 0, inorder.Length - 1, preorder, 0, preorder.Length - 1, map);
        }

        /// <summary>
        /// Finds lower common ancestor of p, q
        /// </summary>
        /// <param name="root">Tree's root node</param>
        /// <param name="p">Node p</param>
        /// <param name="q">Node q</param>
        /// <returns>LCS of p,q</returns>
        public Node FindLCA(Node root, Node p, Node q)
        {
            //find p, q or terminal
            if(root == null)
            {
                return root;
            }
            if(root == p || root == q)
            {
                return root;
            }

            //Recurse on left and right subtree 
            var left = FindLCA(root.Left, p, q);
            var right = FindLCA(root.Right, p, q);

            //Chances are q, p or both were found
            if (left == null) 
                return right; //nothing was found on the left subtree, recursion reached all its terminal nodes. That means the an
            else if (right == null)
                return left; //nothing was found on the right subtree, recursion reached all its terminal nodes.
            else
                return root; //p and q were found
        }

        /// <summary>
        /// Serialized tree into string
        /// </summary>
        /// <param name="root">Tree root</param>
        /// <returns>Serialized string</returns>
        public string Serialize(Node root)
        {
            if(root == null)
            {
                return ".";
            }

            StringBuilder sb = new StringBuilder();
            SerializeHelper(root, sb);
            sb.Append(","); //append finisher
            return sb.ToString();
        }

        public Node Deserialize(String s)
        {
            if(s.Equals(".") || String.IsNullOrEmpty(s))
            {
                return null;
            }

            int i = 0;

            return DeserializeHelper(s, ref i);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Deserializer helper
        /// </summary>
        /// <param name="s">Serialized string</param>
        /// <param name="i">Reference/Pointer to position index value</param>
        /// <returns>Binary tree</returns>
        private Node DeserializeHelper(String s, ref int i)
        {
            if (s[i] == '.')
            {
                i++;
                return null;
            }
            else
            {
                Node root = new Node();
                string value = string.Empty;

                while (!s[i].Equals(','))
                {
                    value = value + s[i];
                    i++;
                }

                i++;
                root.Left = DeserializeHelper(s, ref i);
                i++;
                root.Right = DeserializeHelper(s, ref i);

                root.intValue = int.Parse(value);
                return root;
            }
        }

        /// <summary>
        /// Serializer helper
        /// </summary>
        /// <param name="root">Tree root</param>
        /// <param name="sb">StringBuider instance</param>
        private void SerializeHelper(Node root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append(".");
            }
            else
            {
                sb.Append(root.intValue);
                sb.Append(",");
                SerializeHelper(root.Left, sb);
                sb.Append(",");
                SerializeHelper(root.Right, sb);
            }

        }

        /// <summary>
        /// Core logic to build a tree given inOrder and postOrder values
        /// </summary>
        /// <param name="inOrder">in order value collection</param>
        /// <param name="inOrderStart">in order start index</param>
        /// <param name="inOrderEnd">in order end index</param>
        /// <param name="postOrder">post order value collection</param>
        /// <param name="postOrderStart">post order start index</param>
        /// <param name="postOrderEnd">post order end index</param>
        /// <param name="inOrderIndexes">Dictionary with in order position indexes</param>
        /// <returns>Root node with subtrees</returns>
        private Node MyVersionOfBuidBninaryTreeWithInOrderAndPostOrder(int[] inOrder, int inOrderStart, int inOrderEnd, int[] postOrder, int postOrderStart, int postOrderEnd, Dictionary<int, int> inOrderIndexes)
        {
            //return null if start > end
            if (inOrderStart > inOrderEnd && postOrderStart > postOrderEnd)
            {
                return null;
            }

            //Get root and index from postOrder latest value
            Node root = new Node();
            root.intValue = postOrder[postOrderEnd];
            int index = inOrderIndexes[root.intValue];

            //Get left and right subtrees of root
            root.Left = MyVersionOfBuidBninaryTreeWithInOrderAndPostOrder(inOrder, inOrderStart, index - 1, postOrder, postOrderStart, postOrderStart + ((index - 1) - inOrderStart), inOrderIndexes);
            root.Right = MyVersionOfBuidBninaryTreeWithInOrderAndPostOrder(inOrder, index + 1, inOrderEnd, postOrder, postOrderStart + (index - inOrderStart), postOrderEnd - 1, inOrderIndexes);

            //Add node to tree
            this.Tree.Add(root);

            //return node
            return root;
        }

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
        private Node MyVersionOfBuidBninaryTreeWithInOrderAndPreOrder(int[] inOrder, int inOrderStart, int inOrderEnd, int[] preOrder, int preOrderStart, int preOrderEnd, Dictionary<int, int> inOrderIndexes)
        {
            //return null if start > end
            if (inOrderStart > inOrderEnd && preOrderStart > preOrderEnd)
            {
                return null;
            }

            //Get root and index from postOrder latest value
            Node root = new Node();
            root.intValue = preOrder[preOrderStart];
            int index = inOrderIndexes[root.intValue];

            //Get left and right subtrees of root
            root.Left = MyVersionOfBuidBninaryTreeWithInOrderAndPreOrder(inOrder, inOrderStart, index - 1, preOrder, preOrderStart + 1, preOrderStart + (index - inOrderStart), inOrderIndexes);
            root.Right = MyVersionOfBuidBninaryTreeWithInOrderAndPreOrder(inOrder, index + 1, inOrderEnd, preOrder, preOrderStart + (index - inOrderStart) + 1, preOrderEnd, inOrderIndexes);

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
    }
}
