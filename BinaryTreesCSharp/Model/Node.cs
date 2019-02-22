using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreesCSharp.Model
{
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
}
