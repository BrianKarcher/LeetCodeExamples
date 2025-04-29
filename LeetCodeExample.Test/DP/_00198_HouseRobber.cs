using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // You are a professional robber planning to rob houses along a street.Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.
    // Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.
    /// </summary>
    public class _00198_HouseRobber
    {
        public int Rob(int[] nums)
        {
            // We can start at house 1 or house 2, return the max profit if we start at either of those
            return Math.Max(dp(nums, 0), dp(nums, 1));
        }

        Dictionary<int, int> map = new Dictionary<int, int>();

        public int dp(int[] nums, int i)
        {
            //Console.WriteLine($"{i}");
            // Base case
            if (i == nums.Length - 1)
                return nums[i];
            if (i > nums.Length - 1)
                return 0;

            if (map.ContainsKey(i))
                return map[i];

            int maxProfit = 0;
            // Must skip the adjacent house
            for (int j = i + 2; j < nums.Length; j++)
            {
                int profit = dp(nums, j);
                maxProfit = Math.Max(maxProfit, profit);
            }
            var thisProfit = maxProfit + nums[i];

            map.Add(i, thisProfit);
            //Console.WriteLine($"{i} {thisProfit}");
            return thisProfit;
        }
    }
}