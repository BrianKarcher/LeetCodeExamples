using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given a binary tree, determine if it is height-balanced.
    // For this problem, a height-balanced binary tree is defined as:
    // a binary tree in which the left and right subtrees of every node differ in height by no more than 1.
    /// </summary>
    public class _00110_BalancedBinaryTree
    {
        int maxHeightDiff = 0;
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            else
            {
                FindHeight(root, 0);
                return maxHeightDiff <= 1;
            }
        }

        private int FindHeight(TreeNode root, int h)
        {
            if (root == null)
            {
                return h;
            }

            int leftH = FindHeight(root.left, h);
            int rightH = FindHeight(root.right, h);

            maxHeightDiff = Math.Max(maxHeightDiff, Math.Abs(leftH - rightH));

            return Math.Max(leftH, rightH) + 1;
        }
    }
}