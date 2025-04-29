using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
   // Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum.
   //A subarray is a contiguous part of an array.
    /// </summary>
    public class _00053_MaximumSubarray_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            Assert.AreEqual(6, answer);

            answer = MaxSubArray(new int[] { 1 });
            Assert.AreEqual(1, answer);

            answer = MaxSubArray(new int[] { 5, 4, -1, 7, 8 });
            Assert.AreEqual(23, answer);

            answer = MaxSubArray(new int[] { 1, 2 });
            Assert.AreEqual(3, answer);
        }

        public int MaxSubArray(int[] nums)
        {
            int currentSub = Int32.MinValue;
            int runningMax = 0;
            foreach (var num in nums)
            {
                runningMax += num;
                currentSub = Math.Max(currentSub, runningMax);
                // If it's less than zero then start the counting again
                if (runningMax < 0)
                    runningMax = 0;
            }
            return currentSub;
        }

        // O(n) approach
        public int MaxSubArray2(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            int max = Int32.MinValue;

            int currentSum = Int32.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                // Restart currentSum < 0
                if (currentSum < 0)
                    currentSum = nums[i];
                else
                {
                    currentSum += nums[i];
                }
                max = Math.Max(max, currentSum);
            }
            return max;
        }



        // Searching for a Divide and Conquer approach
        // Interesting solution, D&C, but it's O(n * logn)
        //public int maxSubArray(int[] nums)
        //{
        //    numsArray = nums;

        //    // Our helper function is designed to solve this problem for
        //    // any array - so just call it using the entire input!
        //    return findBestSubarray(0, numsArray.length - 1);
        //}

        //private int findBestSubarray(int left, int right)
        //{
        //    // Base case - empty array.
        //    if (left > right)
        //    {
        //        return Integer.MIN_VALUE;
        //    }

        //    int mid = Math.floorDiv(left + right, 2);
        //    int curr = 0;
        //    int bestLeftSum = 0;
        //    int bestRightSum = 0;

        //    // Iterate from the middle to the beginning.
        //    for (int i = mid - 1; i >= left; i--)
        //    {
        //        curr += numsArray[i];
        //        bestLeftSum = Math.max(bestLeftSum, curr);
        //    }

        //    // Reset curr and iterate from the middle to the end.
        //    curr = 0;
        //    for (int i = mid + 1; i <= right; i++)
        //    {
        //        curr += numsArray[i];
        //        bestRightSum = Math.max(bestRightSum, curr);
        //    }

        //    // The bestCombinedSum uses the middle element and the best
        //    // possible sum from each half.
        //    int bestCombinedSum = numsArray[mid] + bestLeftSum + bestRightSum;

        //    // Find the best subarray possible from both halves.
        //    int leftHalf = findBestSubarray(left, mid - 1);
        //    int rightHalf = findBestSubarray(mid + 1, right);

        //    // The largest of the 3 is the answer for any given input array.
        //    return Math.max(bestCombinedSum, Math.max(leftHalf, rightHalf));
        //}
    }
}