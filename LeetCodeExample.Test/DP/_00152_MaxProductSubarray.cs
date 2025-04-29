using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an integer array nums, find a contiguous non-empty subarray within the array that has the largest product, and return the product.

    //The test cases are generated so that the answer will fit in a 32-bit integer.

    //A subarray is a contiguous subsequence of the array.
    /// </summary>
    public class _00152_MaxProductSubarray
    {
        public int MaxProduct(int[] nums)
        {
            int[] left = new int[nums.Length];
            int[] right = new int[nums.Length];

            // Go from left to right
            left[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                int prev = left[i - 1];
                // 0 is an obvious aborter, skip those
                if (prev == 0)
                    left[i] = nums[i];
                else
                    left[i] = prev * nums[i];
                //Console.WriteLine($"Left({i}): {left[i]}");
            }

            // Go from right to left
            right[nums.Length - 1] = nums[nums.Length - 1];
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                int prev = right[i + 1];
                // 0 is an obvious aborter, skip those
                if (prev == 0)
                    right[i] = nums[i];
                else
                    right[i] = prev * nums[i];
            }

            // Find the max
            int max = Int32.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(max, Math.Max(left[i], Math.Max(right[i], nums[i])));
            }
            return max;
        }
    }
}