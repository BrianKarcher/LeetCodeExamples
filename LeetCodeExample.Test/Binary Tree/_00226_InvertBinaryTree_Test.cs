using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given the root of a binary tree, invert the tree, and return its root.
    /// </summary>
    public class _00226_InvertBinaryTree_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public TreeNode InvertTree(TreeNode root)
        {
            Recurse(root);
            return root;
        }

        public void Recurse(TreeNode node)
        {
            if (node == null)
                return;
            var temp = node.left;
            node.left = node.right;
            node.right = temp;
            Recurse(node.left);
            Recurse(node.right);
        }
    }
}