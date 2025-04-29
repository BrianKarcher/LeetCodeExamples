using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.
    /// </summary>
    public class _01004_MaxConsecutiveOnesIII
    {
        public int LongestOnes(int[] nums, int k)
        {
            int flipCount = 0;
            int l = 0;
            int max = 0;
            // Sliding window
            for (int r = 0; r < nums.Length; r++)
            {
                if (nums[r] == 0)
                {
                    flipCount++;
                }
                if (flipCount <= k)
                {
                    max = Math.Max(max, r - l + 1);
                }
                else
                {
                    // Too many k's have been flipped, bring up the left
                    while (flipCount > k)
                    {
                        if (nums[l] == 0)
                        {
                            flipCount--;
                        }
                        l++;
                    }
                }
            }
            return max;
        }
    }
}