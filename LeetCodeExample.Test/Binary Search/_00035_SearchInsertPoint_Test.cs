using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
   // Given a sorted array of distinct integers and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.

   //You must write an algorithm with O(log n) runtime complexity.
    /// </summary>
    public class _00035_SearchInsertPoint_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public int SearchInsert(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;

            // one-space - while 
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (target > nums[mid])
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            return l;
        }
    }
}