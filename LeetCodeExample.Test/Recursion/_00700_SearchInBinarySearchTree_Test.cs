using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // You are given the root of a binary search tree(BST) and an integer val.
    // Find the node in the BST that the node's value equals val and return the subtree rooted with that node. If such a node does not exist, return null.
    /// </summary>
    public class _00700_SearchInBinarySearchTree_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;
            if (root.val == val)
                return root;

            if (val < root.val)
                return SearchBST(root.left, val);
            else
                return SearchBST(root.right, val);
        }


        // Definition for a binary tree node.
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