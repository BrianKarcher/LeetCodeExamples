using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an array nums which consists of non-negative integers and an integer m, you can split the array into m non-empty continuous subarrays.
    // Write an algorithm to minimize the largest sum among these m subarrays.
    /// </summary>
    public class _00410_SplitArrayLargestSum2_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = SplitArray(new int[] { 7, 2, 5, 10, 8 }, 2);
            Assert.AreEqual(18, answer);

            answer = SplitArray(new int[] { 1, 2, 3, 4, 5 }, 2);
            Assert.AreEqual(9, answer);

            answer = SplitArray(new int[] { 1, 4, 4 }, 3);
            Assert.AreEqual(4, answer);

            answer = SplitArray(new int[] { 7, 2, 5, 10, 8 }, 4);
            Assert.AreEqual(10, answer);
        }

        // This solution checks every permutation possibility. Find a way to improve performance
        // Oh, continuous subarrays. This does not work.
        //int Recurse(int[] nums, int m, int index, string buckets)
        //{
        //    // base case (reached end of the array)
        //    if (index == nums.Length)
        //    {
        //        int[] arr = new int[m];
        //        string[] splitBuckets = buckets.Split(',');
        //        for (int i = 0; i < nums.Length; i++)
        //        {
        //            // Get the bucket to put the value in
        //            int bucket = Int32.Parse(splitBuckets[i]);
        //            arr[bucket] += nums[i];
        //        }
        //        int biggestBucket = arr.Max();
        //        if (biggestBucket == 17)
        //        {
        //            int p = 1;
        //        }
        //        return biggestBucket;
        //    }

        //    int min = Int32.MaxValue;
        //    for (int i = 0; i < m; i++)
        //    {
        //        min = Math.Min(min, Recurse(nums, m, index + 1, buckets + i + ","));
        //    }
        //    return min;
        //}

        // Time: O(n log(sumofarray)
        // Space: O(1)
        public int SplitArray(int[] nums, int m)
        {
            long l = 0;
            long r = 0;

            // We are going the opposite direction on this problem. l and r represent the largest container sum,
            // not indexes. We are guessing (through BS) what
            // the largest sum would be, based on container count, then moving l and r accordingly
            // Until we find the appropriate largest container sum.

            // Start with the maximum possible range for l and r. r = sum of nums. l = max num.

            for (int i = 0; i < nums.Length; i++)
            {
                r += nums[i];
                if (l < nums[i])
                    l = nums[i];
            }

            long ans = r;
            while (l <= r)
            {
                long mn = l + (r - l) / 2;

                int cnt = 1;
                int sum = 0;
                // See how many containers this largest sum creates
                for (int i = 0; i < nums.Length; i++)
                {
                    if (sum + nums[i] > mn)
                    {
                        cnt++;
                        sum = nums[i];
                    }
                    else
                        sum += nums[i];
                }

                if (cnt <= m)
                {
                    ans = Math.Min(ans, mn);
                    r = mn - 1;
                }
                else
                {
                    l = mn + 1;
                }
            }
            return (int)ans;
        }

    }
}