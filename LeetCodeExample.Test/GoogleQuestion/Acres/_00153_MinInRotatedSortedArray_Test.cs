using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
        //    Suppose an array of length n sorted in ascending order is rotated between 1 and n times.For example, the array nums = [0, 1, 2, 4, 5, 6, 7] might become:

        // [4,5,6,7,0,1,2] if it was rotated 4 times.
        // [0, 1, 2, 4, 5, 6, 7] if it was rotated 7 times.
        // Notice that rotating an array[a[0], a[1], a[2], ..., a[n - 1]] 1 time results in the array[a[n - 1], a[0], a[1], a[2], ..., a[n - 2]].

        // Given the sorted rotated array nums of unique elements, return the minimum element of this array.

        // You must write an algorithm that runs in O(log n) time.
    /// </summary>
    public class _00153_MinInRotatedSortedArray_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = FindMin(new int[] { 3, 4, 5, 1, 2 });
            Assert.AreEqual(1, answer);

            answer = FindMin(new int[] { 4, 5, 6, 7, 0, 1, 2 });
            Assert.AreEqual(0, answer);

            answer = FindMin(new int[] { 11, 13, 15, 17 });
            Assert.AreEqual(11, answer);

            answer = FindMin(new int[] { 11, 13, 15, 8 });
            Assert.AreEqual(8, answer);
        }

        public int FindMin(int[] nums)
        {
            int l = 0;
            int r = nums.Length - 1;
            // 2-space
            while (l < r)
            {
                int m = l + (r - l) / 2;
                // The pivot is always the smallest value
                // The moment we find a value to the right that is smaller than current, that value
                // is the pivot, and thus the smallest.
                if (nums[m] > nums[m + 1])
                    return nums[m + 1];
                else if (nums[m] > nums[nums.Length - 1]) // last value is smaller? Pivot must be to the right
                    l = m + 1;
                else
                    r = m;
            }
            return nums[l];
        }
    }
}