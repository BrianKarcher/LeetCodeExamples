using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an array of distinct integers nums and a target integer target, return the number of possible combinations that add up to target.
    // The test cases are generated so that the answer can fit in a 32-bit integer.
    /// </summary>
    public class _00377_CombinationSumIV
    {
        int?[] memo;

        public int CombinationSum4(int[] nums, int target)
        {
            memo = new int?[target + 1];
            return dp(nums, target);
        }

        public int dp(int[] nums, int remain)
        {
            // base case
            if (remain == 0)
            {
                return 1;
            }
            if (remain < 0)
            {
                return 0;
            }
            if (memo[remain] != null)
            {
                return memo[remain].Value;
            }
            int count = 0;
            foreach (int num in nums)
            {
                count += dp(nums, remain - num);
            }
            memo[remain] = count;
            return count;
        }
    }
}