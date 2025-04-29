using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // A wiggle sequence is a sequence where the differences between successive numbers strictly alternate between positive and negative.The first difference (if one exists) may be either positive or negative.A sequence with one element and a sequence with two non-equal elements are trivially wiggle sequences.

    // For example, [1, 7, 4, 9, 2, 5] is a wiggle sequence because the differences (6, -3, 5, -7, 3) alternate between positive and negative.
    // In contrast, [1, 4, 7, 2, 5] and[1, 7, 4, 5, 5] are not wiggle sequences.The first is not because its first two differences are positive, and the second is not because its last difference is zero.
    // A subsequence is obtained by deleting some elements(possibly zero) from the original sequence, leaving the remaining elements in their original order.

    // Given an integer array nums, return the length of the longest wiggle subsequence of nums.
    /// </summary>
    public class _00376_WiggleSubsequence
    {
        //        Any element in the array could correspond to only one of the three possible states:

        //up position, it means nums[i]>nums[i?1] nums[i] > nums[i - 1] nums[i]>nums[i?1]
        //down position, it means nums[i]<nums[i?1] nums[i] < nums[i - 1] nums[i]<nums[i?1]
        //equals to position, nums[i]==nums[i?1] nums[i] == nums[i - 1] nums[i]==nums[i?1]
        public int wiggleMaxLength(int[] nums)
        {
            if (nums.Length < 2)
                return nums.Length;
            int[] up = new int[nums.Length];
            int[] down = new int[nums.Length];
            up[0] = down[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    up[i] = down[i - 1] + 1;
                    down[i] = down[i - 1];
                }
                else if (nums[i] < nums[i - 1])
                {
                    down[i] = up[i - 1] + 1;
                    up[i] = up[i - 1];
                }
                else
                {
                    down[i] = down[i - 1];
                    up[i] = up[i - 1];
                }
            }
            return Math.Max(down[nums.Length - 1], up[nums.Length - 1]);
        }


        public int WiggleMaxLength(int[] nums)
        {
            int[,] dp = new int[nums.Length, 2];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i, 0] = 1;
                dp[i, 1] = 1;
            }
            int max = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] > nums[i])
                    {
                        // Need to wiggle
                        dp[i, 0] = Math.Max(dp[i, 0], dp[j, 1] + 1);
                        max = Math.Max(max, dp[i, 0]);
                    }
                    if (nums[j] < nums[i])
                    {
                        // Need to wiggle
                        dp[i, 1] = Math.Max(dp[i, 1], dp[j, 0] + 1);
                        max = Math.Max(max, dp[i, 1]);
                    }
                }
            }
            return max;
        }
    }
}