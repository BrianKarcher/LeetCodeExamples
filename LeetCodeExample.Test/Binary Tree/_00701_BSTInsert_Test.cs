using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00701_BSTInsert_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //var answer = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            //Assert.AreEqual(0, answer[0]);
            //Assert.AreEqual(1, answer[1]);

            //answer = TwoSum(new int[] { 3, 2, 4 }, 6);
            //Assert.AreEqual(1, answer[0]);
            //Assert.AreEqual(2, answer[1]);

            //answer = TwoSum(new int[] { 3, 3 }, 6);
            //Assert.AreEqual(0, answer[0]);
            //Assert.AreEqual(1, answer[1]);
        }

        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
            {
                return new TreeNode(5, null, null);
            }

            var node = root;

            while (true)
            {
                if (val < node.val)
                {
                    // Going left
                    if (node.left == null)
                    {
                        // Found an empty leaf to insert into
                        var newNode = new TreeNode(val, null, null);
                        node.left = newNode;
                        break;
                    }
                    node = node.left;
                }
                else if (val > node.val)
                {
                    if (node.right == null)
                    {
                        var newNode = new TreeNode(val, null, null);
                        node.right = newNode;
                        break;
                    }
                    node = node.right;
                }

            }

            return root;
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