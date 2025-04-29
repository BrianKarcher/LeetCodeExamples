using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //Given the root of a binary tree, the level of its root is 1, the level of its children is 2, and so on.

    //Return the smallest level x such that the sum of all the values of nodes at level x is maximal.
    /// </summary>
    public class _01161_MaxLevelSumInBinaryTree
    {
        public int MaxLevelSum(TreeNode root)
        {
            int level = 0; // start at Root
            Queue<TreeNode> queue = new Queue<TreeNode>();
            // Start up BFS, which is best for levels of data in a search
            queue.Enqueue(root);
            int maxSumLevel = -1;
            int maxSum = Int32.MinValue;

            while (queue.Any())
            {
                level++;
                int size = queue.Count;
                int currentLevelSum = 0;
                for (int i = 0; i < size; i++)
                {
                    var item = queue.Dequeue();
                    currentLevelSum += item.val;
                    if (item.left != null)
                        queue.Enqueue(item.left);
                    if (item.right != null)
                        queue.Enqueue(item.right);
                }
                if (currentLevelSum > maxSum)
                {
                    maxSum = currentLevelSum;
                    maxSumLevel = level;
                }
            }
            return maxSumLevel;
        }
    }
}