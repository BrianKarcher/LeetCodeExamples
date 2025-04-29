using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
        //Given an integer array nums, return the length of the longest strictly increasing subsequence.
        //A subsequence is a sequence that can be derived from an array by deleting some or no elements without changing the order of the remaining elements.For example, [3,6,2,7] is a subsequence of the array[0, 3, 1, 6, 2, 2, 7].
    /// </summary>
    public class _00300_LongestIncreasingSubsequence_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var ans = lengthOfLIS2(new int[] { 5, 7, -24, 12, 10, 2, 3, 12, 5, 6, 35 });
        }

        // Big O (worst case): O(n^2)
        // Space: O(n)
        // Big Omega (best possible time): O(n^2)
        // Big Theta (average time): O(n^2)
        // We CANNOT use Binary Search since Binary Search can return an invalid subsequence.
        public int lengthOfLIS(int[] nums)
        {
            int[] dp = new int[nums.Length];
            Array.Fill(dp, 1);

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            int longest = 0;
            foreach (int c in dp)
            {
                longest = Math.Max(longest, c);
            }

            return longest;
        }

        public int[] lengthOfLIS2(int[] nums)
        {
            int[] dp = new int[nums.Length];
            Array.Fill(dp, 1);

            int[] refer = new int[nums.Length];
            Array.Fill(refer, -1);

            //(int a, int b) c;
            //c.a = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (dp[j] + 1 > dp[i])
                        {
                            dp[i] = dp[j] + 1;
                            refer[i] = j;
                        }
                    }
                }
            }

            int longest = 0;
            int longestIndex = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (dp[i] > longest)
                {
                    longest = dp[i];
                    longestIndex = i;
                }
            }

            // We found the end of the longest sequence, loop back through it to build it
            int current = longestIndex;
            List<int> seq = new List<int>();
            while (current != -1)
            {
                seq.Add(nums[current]);
                current = refer[current];
            }

            seq.Reverse();
            return seq.ToArray();
        }
    }
}