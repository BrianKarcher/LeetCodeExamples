using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExample.Test.Common
{
    /// <summary>
    /// Template #2 is an advanced form of Binary Search. It is used to search for an element or 
    /// condition which requires accessing the current index and its immediate right neighbor's index in the array.
    /// 
    /// Key Attributes:

        //    An advanced way to implement Binary Search.
        //    Search Condition needs to access element's immediate right neighbor
        //    Use element's right neighbor to determine if condition is met and decide whether to go left or right
        //    Gurantees Search Space is at least 2 in size at each step
        //    Post-processing required.Loop/Recursion ends when you have 1 element left. Need to assess if the remaining element meets the condition.
    /// </summary>
    class BinarySearch2
    {
        int binarySearch(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int left = 0, right = nums.Length;
            while (left < right)
            {
                // Prevent (left + right) overflow
                int mid = left + (right - left) / 2;
                if (nums[mid] == target) { return mid; }
                else if (nums[mid] < target) { left = mid + 1; }
                else { right = mid; }
            }

            // Post-processing:
            // End Condition: left == right
            if (left != nums.Length && nums[left] == target) return left;
            return -1;
        }

        // Corrected version? (user comment)
        // will if you think about it every element you git with(nums[mid]) have right element
        // and you can access it execpt for the last one and to avoid touching the last element
        // we wrote(left<right) this conidtion won't let left to equal right so mid will never be the last index,
        // now we have 2 search space but if you will use this template for accessing single element you
        // have to write the post-processing condtion to check the only element you have never checked in the
        // while loop and this element sitts at index (x) where x = left and x = right because when left get
        // equals right the loop will breaks
        int search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (target < nums[mid] + nums[mid + 1])
                {
                    right = mid - 1;
                }
                else if (target > nums[mid] + nums[mid + 1])
                {
                    left = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            if (left < nums.Length - 1 && nums[left] + nums[left + 1] == target)
            {
                return left;
            }

            return -1;
        }
    }
}
