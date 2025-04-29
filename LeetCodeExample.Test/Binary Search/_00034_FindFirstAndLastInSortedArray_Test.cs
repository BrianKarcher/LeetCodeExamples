using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an array of integers nums sorted in ascending order, find the starting and ending position of a given target value.
    // If target is not found in the array, return [-1, -1].
    // You must write an algorithm with O(log n) runtime complexity.
    /// </summary>
    public class _00034_FindFirstAndLastInSortedArray_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
            Assert.AreEqual(new int[] { 3, 4 }, answer);

            answer = SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6);
            Assert.AreEqual(new int[] { -1, -1 }, answer);

            answer = SearchRange(new int[] { }, 0);
            Assert.AreEqual(new int[] { -1, -1 }, answer);

            answer = SearchRange(new int[] { 1, 3 }, 1);
            Assert.AreEqual(new int[] { 0, 0 }, answer);

            answer = SearchRange(new int[] { 3, 3, 3 }, 3);
            Assert.AreEqual(new int[] { 0, 2 }, answer);

            answer = SearchRange(new int[] { 1 }, 0);
            Assert.AreEqual(new int[] { -1, -1 }, answer);
        }

        //public int[] SearchRange(int[] nums, int target)
        //{
        //    if (nums == null || nums.Length == 0)
        //        return new int[] { -1, -1 };
        //    int l = 0;
        //    int r = nums.Length - 1;
        //    // 3-space, while ends with two elements remaining
        //    while (l + 1 < r)
        //    {
        //        int m = l + (r - l) / 2;
        //        if (nums[m] == target && nums[m + 1] == target)
        //            return new int[] { m, m + 1 };
        //        else if (nums[m - 1] < target)
        //            l = m;
        //        else if (nums[m + 1] > target)
        //            r = m;
        //    }

        //    if (nums[l] == target && nums[r] == target)
        //        return new int[] { l, r };
        //    if (nums[l] == target)
        //        return new int[] { l, l };
        //    if (nums[r] == target)
        //        return new int[] { r, r };
        //    return new int[] { -1, -1 };
        //}

        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return new int[] { -1, -1 };
            if (nums.Length == 1)
            {
                if (nums[0] == target)
                    return new int[] { 0, 0 };
                else
                    return new int[] { -1, -1 };
            }

            int l = FindLeft(nums, target);
            int r = FindRight(nums, target);

            return new int[] { l, r };
        }

        int FindLeft(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;
            int leftMostIndex = -1;

            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (nums[m] == target)
                {
                    leftMostIndex = m;
                    r = m - 1;
                }
                else if (target < nums[m])
                    r = m - 1;
                else
                    l = m + 1;
            }

            return leftMostIndex;
        }

        int FindRight(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;
            int rightMostIndex = -1;

            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (nums[m] == target)
                {
                    rightMostIndex = m;
                    l = m + 1;
                }
                else if (target > nums[m])
                    l = m + 1;
                else
                    r = m - 1;
            }

            return rightMostIndex;
        }
    }
}