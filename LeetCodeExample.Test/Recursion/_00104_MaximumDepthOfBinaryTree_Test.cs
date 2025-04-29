using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given the root of a binary tree, return its maximum depth.
    // A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
    /// </summary>
    public class _00104_MaximumDepthOfBinaryTree_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            return Recurse(root, 1);
        }

        public int Recurse(TreeNode node, int level)
        {
            // Base case - a leaf, return the depth
            if (node.right == null && node.left == null)
                return level;

            int rightDepth = Int32.MinValue;
            if (node.right != null)
            {
                rightDepth = Recurse(node.right, level + 1);
            }

            int leftDepth = Int32.MinValue;
            if (node.left != null)
            {
                leftDepth = Recurse(node.left, level + 1);
            }

            return Math.Max(rightDepth, leftDepth);
        }

    }
}