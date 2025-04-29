using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an integer array nums and an integer target.

    //    You want to build an expression out of nums by adding one of the symbols '+' and '-' before each integer in nums and then concatenate all the integers.

    //    For example, if nums = [2, 1], you can add a '+' before 2 and a '-' before 1 and concatenate them to build the expression "+2-1".
    //    Return the number of different expressions that you can build, which evaluates to target.
    /// </summary>
    public class _00494_TargetSum_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = FindTargetSumWays(new int[] { 1, 1, 1, 1, 1 }, 3);
            Assert.AreEqual(5, answer);
            answer = FindTargetSumWays(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 3);
            Assert.AreEqual(5, answer);
        }

        int?[,] memo;
        int totalSum;

        public int FindTargetSumWays(int[] nums, int target)
        {
            totalSum = nums.Sum(i => i);
            // nums can become all negative or all positive, so the range is
            // totalSum * 2, with totalSum lying in the middle of said range when indexing.
            memo = new int?[nums.Length, totalSum * 2 + 1];
            return dp(nums, nums.Length - 1, 0, target);
        }

        int dp(int[] nums, int index, int sum, int target)
        {
            // base case
            if (index < 0)
            {
                return sum == target ? 1 : 0;
            }

            if (memo[index, totalSum + sum] != null)
            {
                return memo[index, totalSum + sum].Value;
            }

            int ans = dp(nums, index - 1, sum + nums[index], target)
                + dp(nums, index - 1, sum - nums[index], target);
            memo[index, totalSum + sum] = ans;
            return ans;
        }

        //public int FindTargetSumWays(int[] nums, int target)
        //{
        //    visited = new HashSet<string>();
        //    found = new HashSet<string>();
        //    string sw = string.Empty;
        //    sw = sw.PadLeft(nums.Length, '-');
        //    Recurse(nums, 0, sw, target);
        //    return found.Count;
        //}

        //HashSet<string> visited = new HashSet<string>();
        //HashSet<string> found = new HashSet<string>();
        //Dictionary<string, >

        //public int Recurse(int[] nums, int index, string sw, int target)
        //{
        //    // Base case
        //    int sum = 0;
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        sum += nums[i] * (sw[i] == '-' ? -1 : 1);
        //    }
        //    if (sum == target)
        //    {
        //        found.Add(sw);
        //        return 1;
        //    }
        //    //return 1;

        //    if (visited.Contains(sw))
        //        return 0;
        //    visited.Add(sw);

        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        //if (i == index)
        //        //    continue;
        //        for (int j = -1; j <= 1; j += 2)
        //        {
        //            string newsw = sw.Substring(0, i) + (j == -1 ? "-" : "+") + sw.Substring(i + 1);
        //            if (visited.Contains(newsw))
        //                continue;
        //            Recurse(nums, i, newsw, target);
        //        }
        //    }

        //    return -1;
        //}

        public int FindTargetSumWays2(int[] nums, int target)
        {
            Recurse(nums, 0, 0, target);
            return count;
        }

        int count = 0;

        public void Recurse(int[] nums, int i, int sum, int s)
        {
            if (i == nums.Length)
            {
                if (sum == s)
                {
                    count++;
                }
            }
            else
            {
                Recurse(nums, i + 1, sum + nums[i], s);
                Recurse(nums, i + 1, sum - nums[i], s);
            }
        }
    }
}