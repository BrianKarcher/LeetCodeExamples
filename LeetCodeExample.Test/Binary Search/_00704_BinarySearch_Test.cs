using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
       // Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums.If target exists, then return its index.Otherwise, return -1.
       //You must write an algorithm with O(log n) runtime complexity.
    /// </summary>
    public class _00704_BinarySearch_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = Search(new int[] { -1, 0, 3, 5, 9, 12 }, 9);
            Assert.AreEqual(4, answer);


        }

        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int midIdx = (left + right) / 2;
                if (nums[midIdx] == target)
                {
                    return midIdx;
                }
                else if (target < nums[midIdx])
                    right = midIdx - 1;
                else
                    left = midIdx + 1;
            }
            return -1;
        }
    }
}