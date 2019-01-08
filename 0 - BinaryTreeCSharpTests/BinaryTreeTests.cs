using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BinaryTreesCSharp.BinaryTree;
using BinaryTreesCSharp;

namespace BinaryTreeCSharpTests
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void Given_A_Tree_When_MaxDepth_Then_ReturnMaxDepth()
        {
            //arrange
            string[] elements = { "Lewis", "Chloe", "Imogen", "Harry", "Tracy", "Xavier", "James", "Rachel" };
            BinaryTree tree = new BinaryTree();
            tree.Build(elements);

            //act
            int result = tree.MaxDepth(tree.Root);

            //assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Given_A_RootNode_And_NextNode_When_AddLeft_Then_InsertNextNodeLeftOfRoot()
        {
            //arrange
            Node root = new Node()
            {
                intValue = 0,
                strValue = "0"
            };
            BinaryTree tree = new BinaryTree();
            tree.Tree.Add(root);
            Node next = new Node()
            {
                intValue = 1,
                strValue = "1"
            };

            //act
            tree.AddLeft(tree.Root, next);

            //assert
            Assert.AreEqual(tree.Root.Left, next);
        }

        [TestMethod]
        public void Given_A_RootNode_And_NextNode_When_AddRight_Then_InsertNextNodeRightOfRoot()
        {
            //arrange
            Node root = new Node()
            {
                intValue = 0,
                strValue = "0"
            };
            BinaryTree tree = new BinaryTree();
            tree.Tree.Add(root);
            Node next = new Node()
            {
                intValue = 1,
                strValue = "1"
            };

            //act
            tree.AddRight(tree.Root, next);

            //assert
            Assert.AreEqual(tree.Root.Right, next);
        }

        [TestMethod]
        public void Given_A_StringList_When_Build_Then_TreeShouldGetBuilt()
        {
            //arrange
            string[] elements = { "Lewis", "Chloe", "Imogen", "Harry", "Tracy", "Xavier", "James", "Rachel" };
            BinaryTree tree = new BinaryTree();

            //act
            tree.Build(elements);


            //assert
            Assert.AreEqual(tree.Tree.Count, elements.Length);
            Assert.AreEqual(tree.Root.strValue, elements[0]);

        }

        [TestMethod]
        public void IsSymmetricShouldBeTrue()
        {
            //arrange
            var tree = GetSymmetricTree();

            //act
            var result = tree.IsSymmetric(tree.Root);

            //assert
            Assert.IsTrue(result);  
        }

        [TestMethod]
        public void HasPathSumShouldBeTrue()
        {
            //arrange
            var tree = GetIntTree();
            var target = 26;

            //act
            var result = tree.HasSumPath(tree.Root, target);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasPathSumShouldBeFalse()
        {
            //arrange
            var tree = GetIntTree();
            var target = 49;

            //act
            var result = tree.HasSumPath(tree.Root, target);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UnivalCountShoudBe4()
        {
            //arrange
            var tree = GetUnivalTree();
            var target = 4;
            var count = 0;

            //act
            tree.UnivalCount(tree.Root, ref count);

            //assert4
            Assert.AreEqual(target, count);
        }

        private BinaryTree GetUnivalTree()
        {
            BinaryTree tree = new BinaryTree();

            Node root = new Node()
            {
                intValue = 5
            };
            Node five1 = new Node()
            {
                intValue = 5
            };
            Node five2 = new Node()
            {
                intValue = 5
            };
            Node five3 = new Node()
            {
                intValue = 5
            };
            Node five4 = new Node()
            {
                intValue = 5
            };
            Node one = new Node()
            {
                intValue = 1
            };

            tree.Tree.Add(root);
            tree.AddLeft(root, one);
            tree.AddLeft(one, five2);
            tree.AddRight(one, five3);
            tree.AddRight(root, five1);
            tree.AddRight(five1, five4);

            return tree;
        }

        private BinaryTree GetIntTree()
        {
            BinaryTree tree = new BinaryTree();
            Node root = new Node()
            {
                intValue = 5
            };
            Node four = new Node()
            {
                intValue = 4
            };
            Node eight = new Node()
            {
                intValue = 8
            };
            Node eleven = new Node()
            {
                intValue = 11
            };
            Node seven = new Node()
            {
                intValue = 7
            };
            Node two = new Node()
            {
                intValue = 2
            };
            Node thirteen = new Node()
            {
                intValue = 13
            };
            Node four2 = new Node()
            {
                intValue = 4
            };
            Node one = new Node()
            {
                intValue = 1
            };
            tree.Tree.Add(root);
            tree.AddLeft(root, four);
            tree.AddRight(root, eight);
            tree.AddLeft(four, eleven);
            tree.AddLeft(eleven, seven);
            tree.AddRight(eleven, two);
            tree.AddLeft(eight, thirteen);
            tree.AddRight(eight, four2);
            tree.AddRight(eight, one);

            return tree;
        }

        private BinaryTree GetSymmetricTree()
        {
            BinaryTree tree = new BinaryTree();
            Node root = new Node()
            {
                strValue = "1"
            };
            Node twoLeft = new Node()
            {
                strValue = "2"
            };
            Node twoRight = new Node()
            {
                strValue = "2"
            };
            Node threeLeft = new Node()
            {
                strValue = "3"
            };
            Node threeRight = new Node()
            {
                strValue = "3"
            };
            Node fourLeft = new Node()
            {
                strValue = "4"
            };
            Node fourRight = new Node()
            {
                strValue = "4"
            };
            tree.Tree.Add(root);
            tree.AddLeft(root, twoLeft);
            tree.AddRight(root, twoRight);
            tree.AddLeft(twoLeft, threeLeft);
            tree.AddRight(twoLeft, fourLeft);
            tree.AddLeft(twoRight, fourRight);
            tree.AddRight(twoRight, threeRight);

            return tree;
        }
    }
}