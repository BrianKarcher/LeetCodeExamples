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
        public int lengthOfLIS(int[] nums)
        {
            List<int> sub = new();
            sub.Add(nums[0]);

            for (int i = 1; i < nums.Length; i++)
            {
                int num = nums[i];
                if (num > sub[sub.Count - 1])
                {
                    sub.Add(num);
                }
                else
                {
                    int j = binarySearch(sub, num);
                    sub[j] = num;
                }
            }

            return sub.Count;
        }

        private int binarySearch(List<int> sub, int num)
        {
            int left = 0;
            int right = sub.Count - 1;
            int mid = (left + right) / 2;

            while (left < right)
            {
                mid = (left + right) / 2;
                if (sub.[mid] == num)
                {
                    return mid;
                }

                if (sub.[mid] < num)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        public int LengthOfLIS(int[] nums)
        {
            int[] dp = new int[nums.Length];
            Array.Fill(dp, 1);
            int max = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    //Console.WriteLine($"i {nums[i]} j {nums[j]} dp[j] {dp[j]} currentMax {currentMax}");
                    if (nums[j] < nums[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                        max = Math.Max(max, dp[i]);
                        //Console.WriteLine($"Setting currrent max to {currentMax}");
                    }
                }
            }
            return max;
        }

        //public int LengthOfLIS(int[] nums)
        //{
        //    // arr contains the max subsequence count at the ith index
        //    int[] arr = new int[nums.Length];
        //    Array.Fill(arr, 1);
        //    int finalMax = 1;
        //    for (int i = arr.Length - 1; i >= 0; i--)
        //    {
        //        int max = Int32.MinValue;
        //        for (int j = arr.Length - 1; j > i; j--)
        //        {
        //            if (nums[j] > nums[i] && arr[j] > max)
        //            {
        //                max = arr[j];
        //            }
        //        }
        //        arr[i] = Math.Max(1, max + 1);
        //        finalMax = Math.Max(finalMax, arr[i]);
        //    }

        //    return finalMax;
        //}
    }
}