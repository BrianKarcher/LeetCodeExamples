using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
        // There is an integer array nums sorted in ascending order(with distinct values).
        // Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k(1 <= k<nums.length) such that the resulting array is [nums[k], nums[k + 1], ..., nums[n - 1], nums[0], nums[1], ..., nums[k - 1]] (0-indexed). For example, [0, 1, 2, 4, 5, 6, 7] might be rotated at pivot index 3 and become[4, 5, 6, 7, 0, 1, 2].
        // Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.
        // You must write an algorithm with O(log n) runtime complexity.
    /// </summary>
    public class _00033_SearchRotatedSortedArray_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
            Assert.AreEqual(4, answer);

            answer = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 7);
            Assert.AreEqual(3, answer);

            answer = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 1);
            Assert.AreEqual(5, answer);

            answer = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3);
            Assert.AreEqual(-1, answer);

            answer = Search(new int[] { 1 }, 0);
            Assert.AreEqual(-1, answer);

            answer = Search(new int[] { 1 }, 1);
            Assert.AreEqual(0, answer);
        }

        public int Search(int[] nums, int target)
        {
            int p = nums.Length;

            int l = 0;
            int r = nums.Length - 1;
            // Find the pivot point
            // The pivot point is the one and only index where the item to the right smaller
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                int midplusone = mid + 1;
                
                if (nums[mid] == target)
                {
                    // Found it on accident while trying to locate the pivot.
                    return mid;
                }
                else if (midplusone == nums.Length)
                    // No midpoint found
                    break;
                else if (nums[mid] > nums[midplusone])
                {
                    p = mid;
                    break;
                }
                else if (nums[mid] > nums[nums.Length - 1])
                {
                    // Pivot point is to the right
                    l = mid + 1;
                }
                else
                    r = mid - 1;
            }

            // There are two windows to search for the target, one before the pivot, one after the pivot.
            // Both windows are in ascending order.

            // Before the pivot
            l = 0;
            r = p - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;

                if (nums[mid] == target)
                    return mid;
                else if (target < nums[mid])
                {
                    // Pivot point is to the left
                    r = mid - 1;
                }
                else
                    l = mid + 1;
            }

            // Not found? Search the other window
            l = p + 1;
            r = nums.Length - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;

                if (nums[mid] == target)
                    return mid;
                else if (target < nums[mid])
                {
                    // Pivot point is to the left
                    r = mid - 1;
                }
                else
                    l = mid + 1;
            }

            return -1;
        }
    }
}