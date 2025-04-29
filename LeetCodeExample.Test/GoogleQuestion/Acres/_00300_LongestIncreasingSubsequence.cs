using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00300_LongestIncreasingSubsequence
    {
        // https://www.youtube.com/watch?v=cjWnW0hdF1Y
        // Says if the interviewer wants nlogn without a hint, walk out of the room

        public int LengthOfLIS(int[] nums)
        {
            List<int> arr = new();
            arr.Add(nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                // arr is always kept sequential so we can perform a binary search later
                // If the new num is higher than the last item in the array, add it since it
                // keeps the sequential nature. This increases the count of the increasing subsequence
                if (nums[i] > arr[arr.Count - 1])
                {
                    arr.Add(nums[i]);
                }
                else
                {
                    // There is an item in the array larger than this.
                    // Find the item next higher than this item and replace it with this number.
                    // This "brings down" the items in the list.
                    int index = BinarySearch(arr, nums[i]);
                    arr[index] = nums[i];
                }
            }
            return arr.Count;
        }

        public int BinarySearch(List<int> nums, int target)
        {
            // Return the target's index or the next higher.
            int l = 0;
            int r = nums.Count - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (target > nums[mid])
                {
                    // Move right
                    l = mid + 1;
                }
                else
                {
                    // Move left.
                    r = mid - 1;
                }
            }
            return l;
        }

        public int LengthOfLIS2(int[] nums)
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