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

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}