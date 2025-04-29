using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00300_LongestIncreasingSubsequence
    {
        public int LengthOfLIS(int[] nums)
        {
            // arr contains the max subsequence count at the ith index
            int[] arr = new int[nums.Length];
            Array.Fill(arr, 1);
            int finalMax = 1;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int max = Int32.MinValue;
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (nums[j] > nums[i] && arr[j] > max)
                    {
                        max = arr[j];
                    }
                }
                arr[i] = Math.Max(1, max + 1);
                finalMax = Math.Max(finalMax, arr[i]);
            }

            return finalMax;
        }
    }
}