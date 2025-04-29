using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
   // Given an array of integers nums containing n + 1 integers where each integer is in the range[1, n] inclusive.
   // There is only one repeated number in nums, return this repeated number.
   // You must solve the problem without modifying the array nums and uses only constant extra space.
    /// </summary>
    public class _00287_FindDuplicateNumber_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public int FindDuplicate(int[] nums)
        {
            bool[] found = new bool[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (found[nums[i]] == true)
                    return nums[i];
                found[nums[i]] = true;
            }
            return -1;
        }

        // Needs to be constant space, Binary Search
        public int FindDuplicate2(int[] nums)
        {
            int l = 1;
            int r = nums.Length - 1;
            int duplicate = -1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                // count all numbers less than m. 
                // If the count exceeds m, then the duplicate is to the left (or m itself).
                int count = 0;
                foreach (var num in nums)
                {
                    if (num <= m)
                        count++;
                }
                if (count > m)
                {
                    duplicate = m;
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }
            return duplicate;
        }
    }
}