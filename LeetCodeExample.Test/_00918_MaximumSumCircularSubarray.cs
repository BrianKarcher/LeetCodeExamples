using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given a circular integer array nums of length n, return the maximum possible sum of a non-empty subarray of nums.
    //A circular array means the end of the array connects to the beginning of the array.Formally, the next element of nums[i] is nums[(i + 1) % n] and the previous element of nums[i] is nums[(i - 1 + n) % n].

    //A subarray may only include each element of the fixed buffer nums at most once.Formally, for a subarray nums[i], nums[i + 1], ..., nums[j], there does not exist i <= k1, k2 <= j with k1 % n == k2 % n.
    /// </summary>
    public class _00918_MaximumSumCircularSubarray
    {
        public int MaxSubarraySumCircular(int[] nums)
        {
            // There are two options here. One-interval, or two-interval.
            // Let's do one-interval first - Kadane's Algorithm

            int globalMax = Int32.MinValue;
            int max = Int32.MinValue;
            int current = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                current = nums[i] + Math.Max(current, 0);
                max = Math.Max(max, current);
            }

            // For the two-interval, let's invert nums (multiply by -1), then use Kadane to 
            // find the minimum subarray, then subtract that from the array sum
            bool allNegative = true;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    allNegative = false;
                nums[i] = -nums[i];
            }
            if (allNegative)
                return max;

            int minMax = Int32.MinValue;
            current = 0;
            int arraySum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                current = nums[i] + Math.Max(current, 0);
                minMax = Math.Max(minMax, current);
                arraySum += nums[i];
            }

            int minSum = -(arraySum - minMax);
            globalMax = Math.Max(max, minSum);
            return globalMax;
        }
    }
}