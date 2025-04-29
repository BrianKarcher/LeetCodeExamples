using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given the root of a binary tree and an integer targetSum, return true if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.
    //A leaf is a node with no children.
    /// </summary>
    public class _00112_PathSum
    {
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            return Recurse(root, 0, targetSum);
        }

        bool Recurse(TreeNode root, int currentSum, int targetSum)
        {
            if (root == null)
                return false;

            // Reached a leaf, check sums
            if (root.left == null && root.right == null)
                return currentSum + root.val == targetSum;

            if (Recurse(root.left, currentSum + root.val, targetSum))
                return true;
            return Recurse(root.right, currentSum + root.val, targetSum);
        }
    }
}