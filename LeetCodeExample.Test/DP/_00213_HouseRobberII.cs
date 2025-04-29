using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You are a professional robber planning to rob houses along a street.Each house has a certain amount of money stashed. All houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. Meanwhile, adjacent houses have a security system connected, and it will automatically contact the police if two adjacent houses were broken into on the same night.
    //Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.    /// </summary>
    public class _00213_HouseRobberII
    {
        public int Rob(int[] nums)
        {
            return Math.Max(Rob(nums, false), Rob(nums, true));
        }

        public int Rob(int[] nums, bool startSecond)
        {
            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            int[] dp = new int[nums.Length + 1];
            dp[0] = 0;
            if (!startSecond)
                dp[1] = nums[0];
            for (int i = 2; i < nums.Length + 1; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i - 1]);
            }
            // The last house is adjacent to the first, so if the last one gets robbed, the first didn't
            // so remove the first houses earnings from the last house
            if (!startSecond)
                dp[nums.Length] -= nums[0];

            // The max earnings thus are either as the robber passed the last house or the next to last house
            return Math.Max(dp[nums.Length - 1], dp[nums.Length]);
        }

        /*Dictionary<int, int> map = new Dictionary<int, int>();

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
        }*/
    }
}