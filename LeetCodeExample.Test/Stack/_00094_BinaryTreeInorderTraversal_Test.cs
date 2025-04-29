using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given the root of a binary tree, return the inorder traversal of its nodes' values.
    /// </summary>
    public class _00094_BinaryTreeInorderTraversal_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = InorderTraversal(new TreeNode(1, null, new TreeNode(2, new TreeNode(3))));
            Assert.AreEqual(new List<int> { 1, 3, 2 }, answer);
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> rtn = new List<int>();

            if (root == null)
                return rtn;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            HashSet<TreeNode> visited = new HashSet<TreeNode>();
            // Inorder = add left node, add this, add right
            // In order to accomplish iteratively, we need to traverse all the way down the left branch
            // Until can go no more left, then print the node, then traverse the right branch, then to its left
            // branches, and so on.

            stack.Push(root);
            while (stack.Any())
            {
                // Peek, don't pop in case there is a node to the left
                var node = stack.Peek();
                // Anything to the left?
                if (node.left != null && !visited.Contains(node.left))
                {
                    visited.Add(node.left);
                    stack.Push(node.left);
                    continue;
                }
                // No more left that hasn't been visited, can finally add the value and pop the node from the stack
                rtn.Add(node.val);
                stack.Pop();
                // Try the right side
                if (node.right != null && !visited.Contains(node.right))
                {
                    visited.Add(node.right);
                    stack.Push(node.right);
                    continue;
                }
            }
            return rtn;
        }

        // Similar to above, but less code. Uses a pointer + stack instead of just a stack.
        public List<int> inorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode curr = root;
            while (curr != null || stack.Any())
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }
                curr = stack.Pop();
                res.Add(curr.val);
                curr = curr.right;
            }
            return res;
        }

        public void Recurse(TreeNode node, IList<int> list)
        {
            if (node == null)
                return;
            Recurse(node.left, list);
            list.Add(node.val);
            Recurse(node.right, list);
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