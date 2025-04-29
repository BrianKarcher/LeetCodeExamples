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
    public class _00410_SplitArrayLargestSum_Test
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

        public int SplitArray(int[] nums, int m)
        {
            if (m == 1)
                return nums.Sum();
            return Recurse(nums, m, 0, 0, string.Empty);
        }

        int Recurse(int[] nums, int m, int splitCount, int index, string splits)
        {
            // Base case
            if (index >= nums.Length)
                return Int32.MaxValue;

            if (splitCount + 1 == m)
            {
                int maxBucketSize = Int32.MinValue;
                string[] splitIndexes = splits.Split(',');
                int currentSplitIndex = 0;
                int currentSplit = Int32.Parse(splitIndexes[currentSplitIndex]);

                int currentBucket = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    currentBucket += nums[i];
                    if (i == currentSplit - 1 || i == nums.Length - 1)
                    {
                        maxBucketSize = Math.Max(maxBucketSize, currentBucket);
                        currentBucket = 0;
                        currentSplitIndex++;
                        if (currentSplitIndex < splitIndexes.Length - 1)
                            currentSplit = Int32.Parse(splitIndexes[currentSplitIndex]);
                    }
                }
                return maxBucketSize;
                //return Math.Max(currentBucket, maxBucketSize);
            }

            int min = Int32.MaxValue;
            for (int i = index + 1; i < nums.Length; i++)
            {
                min = Math.Min(min, Recurse(nums, m, splitCount + 1, i, splits + (i) + ","));
            }
            return min;
        }
    }
}