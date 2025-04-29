using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given a binary array nums, return the maximum number of consecutive 1's in the array if you can flip at most one 0.
    /// </summary>
    public class _00487_MaxConsecutiveOnesII
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int flipCount = 0;
            int l = 0;
            int max = Int32.MinValue;
            // Sliding window
            for (int r = 0; r < nums.Length; r++)
            {
                if (nums[r] == 0)
                {
                    flipCount++;
                }
                if (flipCount < 2)
                {
                    max = Math.Max(max, r - l + 1);
                }
                else
                {
                    // Too many k's have been flipped, bring up the left
                    while (flipCount >= 2)
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