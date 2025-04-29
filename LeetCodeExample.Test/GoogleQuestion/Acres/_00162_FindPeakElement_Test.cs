using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //A peak element is an element that is strictly greater than its neighbors.
    //Given an integer array nums, find a peak element, and return its index.If the array contains multiple peaks, return the index to any of the peaks.
    //You may imagine that nums[-1] = nums[n] = -∞.
    //You must write an algorithm that runs in O(log n) time.
    /// </summary>
    public class _00162_FindPeakElement_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = FindPeakElement(new int[] { 1, 2, 3, 1 });
            Assert.AreEqual(2, answer);

            answer = FindPeakElement(new int[] { 1, 2, 1, 3, 5, 6, 4 });
            Assert.AreEqual(5, answer);

            answer = FindPeakElement(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Assert.AreEqual(8, answer);

            answer = FindPeakElement(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            Assert.AreEqual(0, answer);

        }

        public int FindPeakElement2(int[] nums)
        {
            if (nums.Length == 1)
                return 0;

            int l = 0;
            int r = nums.Length - 1;
            // Use a Binary Search to always trend towards a larger number, eventually we'll find one that is
            // larger than its neighbors
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                int mv = nums[m];
                int lv = m < 1 ? Int32.MinValue : nums[m - 1];
                int rv = m >= nums.Length - 1 ? Int32.MinValue : nums[m + 1];
                // Found a peak!
                if (mv > lv && mv > rv)
                    return m;
                else if (lv > rv)
                {
                    r = m - 1;
                }
                else
                    l = m + 1;
            }
            return -1;
        }

        public int FindPeakElement(int[] nums)
        {
            int l = 0;
            int r = nums.Length - 1;
            // This will bail when there is 1 element remaining
            // Since it keeps an extra element in, there will always be 2 space to check for mid + 1
            while (l < r)
            {
                //if (l == r)
                //    return l;
                int mid = l + (r - l) / 2;
                if (nums[mid] > nums[mid + 1])
                    r = mid; // unsure why it is not mid - 1
                else
                    l = mid + 1;
            }
            return l;
        }
    }
}