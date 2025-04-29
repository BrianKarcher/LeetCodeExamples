using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // You are given a 0-indexed integer array nums representing the contents of a pile, where nums[0] is the topmost element of the pile.
    // In one move, you can perform either of the following:

    // If the pile is not empty, remove the topmost element of the pile.
    // If there are one or more removed elements, add any one of them back onto the pile.This element becomes the new topmost element.
    // You are also given an integer k, which denotes the total number of moves to be made.

    // Return the maximum value of the topmost element of the pile possible after exactly k moves. In case it is not possible to obtain a non-empty pile after k moves, return -1.
    /// </summary>
    public class _02202_MaximizeTheTopmostElementAfterKMoves
    {
        public int MaximumTop(int[] nums, int k)
        {
            if (nums.Length == 1 && k % 2 == 1)
                return -1;
            int max = -1;
            for (int i = 0; i < nums.Length && i < k - 1; i++)
            {
                max = Math.Max(max, nums[i]);
            }
            // The last 'k' is special. We can either push the max in 'max', or pop k
            // revealing just the last item since no other actions can be done.

            // edge cases
            // Iterated through the whole array with one move left. The last move
            // is to push the maximum value to the front of the array
            if (nums.Length < k)
            {
                return max;
            }
            // We hit k - 1
            // We can either add the max value we have reached to this point
            // Or pop one more value (meaning, just return the next item in nums
            else if (k < nums.Length)
            {
                return Math.Max(max, nums[k]);
            }
            return max;
        }
    }
}