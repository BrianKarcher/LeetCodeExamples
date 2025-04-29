using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Suppose an array of length n sorted in ascending order is rotated between 1 and n times.For example, the array nums = [0, 1, 4, 4, 5, 6, 7] might become:

    // [4,5,6,7,0,1,4] if it was rotated 4 times.
    // [0, 1, 4, 4, 5, 6, 7] if it was rotated 7 times.
    // Notice that rotating an array[a[0], a[1], a[2], ..., a[n - 1]] 1 time results in the array[a[n - 1], a[0], a[1], a[2], ..., a[n - 2]].

    // Given the sorted rotated array nums that may contain duplicates, return the minimum element of this array.

    // You must decrease the overall operation steps as much as possible.

    // Example 1:

    // Input: nums = [1, 3, 5]
    // Output: 1
    // Example 2:

    // Input: nums = [2, 2, 2, 0, 1]
    // Output: 0
    /// </summary>
    public class _00154_MinRotatedSortedArrayII_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //var answer = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            //Assert.AreEqual(0, answer[0]);
            //Assert.AreEqual(1, answer[1]);

            //answer = TwoSum(new int[] { 3, 2, 4 }, 6);
            //Assert.AreEqual(1, answer[0]);
            //Assert.AreEqual(2, answer[1]);

            //answer = TwoSum(new int[] { 3, 3 }, 6);
            //Assert.AreEqual(0, answer[0]);
            //Assert.AreEqual(1, answer[1]);
        }

        public int FindMin(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            // If the last item is greater than the first item then there was no rotation,
            // return the first value
            if (nums[nums.Length - 1] > nums[0])
                return nums[0];

            // We have an issue if the array is [4,4,1,4,4,4,4,4,4,4,4,4,4]
            // We have no idea, when we are at mid 4, whether to go left or right since the first, last, and mid
            // values are all 4
            // So we need to check both directions through recursion

            int min = Min(0, nums.Length - 1, nums);

            // If all the nums are the same, Int32.MaxValue gets returned from the function
            // So just return the first value. All same - first value is the lowest value
            return Math.Min(min, nums[0]);
        }

        public int Min(int left, int right, int[] nums)
        {
            if (left > right)
                return Int32.MaxValue;

            int m = left + (right - left) / 2;

            // Found inflection point?
            // Also do a bounds check
            if (m < nums.Length - 1 && nums[m] > nums[m + 1])
            {
                return nums[m + 1];
            }

            // Found a different inflection point?
            // Also do a bounds check
            if (m > 0 && nums[m - 1] > nums[m])
            {
                return nums[m];
            }

            // We don't know which way to go!
            // Try both ways
            if (nums[m] == nums[0])
            {
                return Math.Min(Min(left, m - 1, nums), Min(m + 1, right, nums));
            }

            // If mid is larger than first value in the array, look right
            if (nums[m] > nums[0])
                return Min(m + 1, right, nums);
            else
                // Otherwise look left
                return Min(left, m - 1, nums);
        }
    }
}