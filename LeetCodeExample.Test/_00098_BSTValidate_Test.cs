using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given the root of a binary tree, determine if it is a valid binary search tree(BST).
    // A valid BST is defined as follows:
    // The left subtree of a node contains only nodes with keys less than the node's key.
    // The right subtree of a node contains only nodes with keys greater than the node's key.
    // Both the left and right subtrees must also be binary search trees.
    /// </summary>
    public class _00098_BSTValidate_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var ans = IsValidBST(new TreeNode(2, new TreeNode(1), new TreeNode(3)));
            Assert.AreEqual(true, ans);

            ans = IsValidBST(new TreeNode(5, new TreeNode(1), new TreeNode(4, new TreeNode(3), new TreeNode(6))));
            Assert.AreEqual(false, ans);
        }

        public bool IsValidBST(TreeNode root)
        {
            cache = new HashSet<int>();
            return Recurse(root, Int32.MinValue, Int32.MaxValue);
        }

        HashSet<int> cache;

        // min and max keep track of the valid "window" as we go down the BST. This keeps the sub nodes within the bounds
        // of their acenstor nodes
        public bool Recurse(TreeNode node, int min, int max)
        {
            if (node == null)
                return true;

            if (cache.Contains(node.val))
                return false;

            // Out of bounds check
            if (node.val < min)
                return false;

            if (node.val > max)
                return false;

            cache.Add(node.val);

            // Shrink the valid window a little each step
            if (!Recurse(node.left, min, node.val))
                return false;

            if (!Recurse(node.right, node.val, max))
                return false;

            return true; 
        }
    }
}