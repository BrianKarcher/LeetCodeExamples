using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given a set of distinct positive integers nums, return the largest subset answer such that every pair(answer[i], answer[j]) of elements in this subset satisfies:

    //    answer[i] % answer[j] == 0, or
    //    answer[j] % answer[i] == 0
    //If there are multiple solutions, return any of them.
    /// </summary>
    public class _00368_LargestDivisibleSubset
    {
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            Array.Sort(nums);
            // Store the count to this point, and index to the next item in the chain
            int[,] dp = new int[nums.Length, 2];
            dp[nums.Length - 1, 0] = 0;
            dp[nums.Length - 1, 1] = -1;
            int startingIndex = nums.Length - 1;
            int maxCount = Int32.MinValue;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                dp[i, 0] = 0;
                dp[i, 1] = -1;
                if (nums[i] == 0)
                {
                    continue;
                }
                for (int j = i + 1; j < nums.Length; j++)
                {
                    //Console.WriteLine($"Comparing {nums[i]} with {nums[j]}");
                    if (nums[j] % nums[i] == 0)
                    {
                        //Console.WriteLine($"{nums[j]} and {nums[i]} Divided!");
                        if (dp[j, 0] + 1 > dp[i, 0])
                        {
                            //Console.WriteLine("Huh");
                            dp[i, 0] = dp[j, 0] + 1;
                            dp[i, 1] = j;
                            //Console.WriteLine($"{i}, count = {dp[i, 0]}");
                            if (dp[i, 0] > maxCount)
                            {
                                maxCount = dp[i, 0];
                                //Console.WriteLine($"Setting starting index to {i}, maxCount = {maxCount}");
                                startingIndex = i;
                            }
                        }
                    }
                }
            }

            // Build the list.
            List<int> lst = new List<int>();
            int index = startingIndex;
            while (index != -1)
            {
                lst.Add(nums[index]);
                index = dp[index, 1];
            }
            return lst;
        }
    }
}