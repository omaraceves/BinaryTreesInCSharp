using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreesCSharp
{
    /// <summary>
    /// Main class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">String arguments</param>
        static void Main(string[] args)
        {

            BinaryTree tree = new BinaryTree();
            string[] elements = { "Lewis", "Chloe", "Imogen", "Harry", "Tracy", "Xavier", "James", "Rachel"};
            tree.Build(elements);

            //Traverse with different methods
            Console.WriteLine("Top Down:---------------------------");
            tree.TraverseTopDown();

            Console.WriteLine("Bottom Up:---------------------------");
            tree.TraverseBottomUp();

            Console.WriteLine("In Order:---------------------------");
            tree.TraverseInOrder();

            Console.WriteLine("Tree Level Order:---------------------------");
            tree.TraverseLevelOrder();

            Console.ReadLine();

        }

       


    }
}
