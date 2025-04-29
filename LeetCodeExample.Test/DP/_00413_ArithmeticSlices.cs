using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    An integer array is called arithmetic if it consists of at least three elements and if the difference between any two consecutive elements is the same.

    //    For example, [1,3,5,7,9], [7,7,7,7], and[3, -1, -5, -9] are arithmetic sequences.
    //  Given an integer array nums, return the number of arithmetic subarrays of nums.

    //    A subarray is a contiguous subsequence of the array.
    /// </summary>
    public class _00413_ArithmeticSlices
    {
        public int NumberOfArithmeticSlices(int[] nums)
        {
            if (nums.Length < 3)
            {
                return 0;
            }
            // Store the consecutive count at this level (where the same split level continues).
            int[] dp = new int[nums.Length];
            dp[0] = 0;
            dp[1] = 0;
            int count = 0;
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - 1] == nums[i - 1] - nums[i - 2])
                {
                    // Same split continued
                    dp[i] = dp[i - 1] + 1;
                    count += dp[i];
                }
            }
            return count;
        }
    }
}