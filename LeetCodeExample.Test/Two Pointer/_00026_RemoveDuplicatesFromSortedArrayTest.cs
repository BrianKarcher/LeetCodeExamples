using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
 //   Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once.The relative order of the elements should be kept the same.
 //  Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums.More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result.It does not matter what you leave beyond the first k elements.
 //Return k after placing the final result in the first k slots of nums.

 //Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.    /// </summary>
    public class _00026_RemoveDuplicatesFromSortedArrayTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int l = 1;
            // r always increments by 1 regardless
            for (int r = 1; r < nums.Length; r++)
            {
                // if nums[r] changes value, place that in the left slot
                if (nums[r] != nums[r - 1])
                {
                    nums[l] = nums[r];
                    // Increment the left slot
                    l++;
                }
            }

            return l;
        }
    }
}