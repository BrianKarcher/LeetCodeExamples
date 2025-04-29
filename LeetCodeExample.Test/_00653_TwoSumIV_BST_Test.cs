using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given the root of a Binary Search Tree and a target number k, return true if there exist two elements in the BST 
    // such that their sum is equal to the given target.
    /// </summary>
    public class _00653_TwoSumIV_BST_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var two = new TreeNode(2, null, null);
            var four = new TreeNode(4, null, null);
            var three = new TreeNode(3, two, four);
            var seven = new TreeNode(7, null, null);
            var six = new TreeNode(6, null, seven);
            var five = new TreeNode(5, three, six);

            var answer = FindTarget_BFS(five, 9);
            Assert.AreEqual(true, answer);

            answer = FindTarget_BFS(five, 28);
            Assert.AreEqual(false, answer);

            var q2_1 = new TreeNode(1, null, null);
            var q2_3 = new TreeNode(3, null, null);
            var q2_2 = new TreeNode(2, q2_1, q2_3);
            answer = FindTarget_BFS(q2_2, 4);
            Assert.AreEqual(true, answer);

            answer = FindTarget_BFS(q2_2, 1);
            Assert.AreEqual(false, answer);

            answer = FindTarget_BFS(q2_2, 3);
            Assert.AreEqual(true, answer);
        }

        // val
        HashSet<int> values = new HashSet<int>();

        public bool FindTarget_Recursive(TreeNode root, int k)
        {
            // O(n) solution - brute force approach, potentially checks every node

            if (root == null)
                return false;

            var target = k - root.val;
            // Does the target exist in the Dictionary?
            if (values.Contains(target))
            {
                return true;
            }

            values.Add(root.val);
            // Recursively check both nodes
            if (FindTarget_Recursive(root.left, k))
                return true;

            if (FindTarget_Recursive(root.right, k))
                return true;

            return false;
        }

        public bool FindTarget_BFS(TreeNode root, int k)
        {
            // O(n) solution - brute force approach, potentially checks every node

            if (root == null)
                return false;

            values = new HashSet<int>();

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var node = queue.Dequeue();
                if (node == null)
                    continue;

                var target = k - node.val;
                // Does the target exist in the Dictionary?
                if (values.Contains(target))
                {
                    return true;
                }
                values.Add(node.val);
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

            return false;
        }

    }
}