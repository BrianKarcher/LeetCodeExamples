using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an integer array nums where the elements are sorted in ascending order, convert it to a height-balanced binary search tree.
    // A height-balanced binary tree is a binary tree in which the depth of the two subtrees of every node never differs by more than one.
    /// </summary>
    public class _00108_ConvertSortedArrayToBST
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return Recurse(nums, 0, nums.Length - 1);
        }

        TreeNode Recurse(int[] nums, int left, int right)
        {
            // base case
            if (left > right)
                return null;

            // This node is the middle value to keep it balanced
            int mid = (left + right) / 2;
            TreeNode node = new TreeNode(nums[mid]);
            node.left = Recurse(nums, left, mid - 1);
            node.right = Recurse(nums, mid + 1, right);
            return node;
        }
    }
}