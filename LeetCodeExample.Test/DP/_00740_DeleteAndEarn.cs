using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an integer array nums.You want to maximize the number of points you get by performing the following operation any number of times:
    // Pick any nums[i] and delete it to earn nums[i] points.Afterwards, you must delete every element equal to nums[i] - 1 and every element equal to nums[i] + 1.
    // Return the maximum number of points you can earn by applying the above operation some number of times.
    /// </summary>
    public class _00740_DeleteAndEarn
    {
        public int DeleteAndEarn(int[] nums)
        {
            int n = 20000;
            int[] sum = new int[n + 2];
            // Sum up into number buckets
            foreach (int num in nums)
            {
                sum[num] += num;
            }

            int[] dp = new int[n + 2];
            dp[0] = 0;
            dp[1] = sum[1];

            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + sum[i]);
            }

            return dp[n - 1];
        }
    }
}