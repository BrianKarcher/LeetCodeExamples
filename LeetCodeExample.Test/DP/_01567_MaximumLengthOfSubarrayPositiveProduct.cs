using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an array of integers nums, find the maximum length of a subarray where the product of all its elements is positive.
    // A subarray of an array is a consecutive sequence of zero or more values taken out of that array.
    // Return the maximum length of a subarray with positive product.
    /// </summary>
    public class _01567_MaximumLengthOfSubarrayPositiveProduct
    {
        public int GetMaxLen(int[] nums)
        {
            int[] left = new int[nums.Length + 1];
            int[] right = new int[nums.Length + 1];

            int negCount = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    left[i + 1] = 0;
                    negCount = 0;
                }
                else if (nums[i] < 0)
                {
                    // two negatives multiplied = a positive
                    if (negCount > 0)
                    {
                        left[i + 1] = left[i] + negCount + 1;
                        negCount = 0;
                    }
                    else
                    {
                        negCount++;
                        left[i + 1] = left[i];
                    }
                }
                else
                {
                    if (negCount > 0)
                    {
                        negCount++;
                        left[i + 1] = left[i];
                    }
                    else
                        left[i + 1] = left[i] + 1;
                }
                //Console.WriteLine($"i {i + 1}, val {left[i + 1]}, negCount: {negCount}");
            }

            negCount = 0;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] == 0)
                {
                    right[i] = 0;
                    negCount = 0;
                }
                else if (nums[i] < 0)
                {
                    // two negatives multiplied = a positive
                    if (negCount > 0)
                    {
                        right[i] = right[i + 1] + negCount + 1;
                        negCount = 0;
                    }
                    else
                    {
                        negCount++;
                        right[i] = right[i + 1];
                    }
                }
                else
                {
                    if (negCount > 0)
                    {
                        negCount++;
                        right[i] = right[i + 1];
                    }
                    else
                        right[i] = right[i + 1] + 1;
                }
                //Console.WriteLine($"i {i}, val {right[i]}, negCount: {negCount}");
            }

            int max = Int32.MinValue;
            for (int i = 0; i < nums.Length + 1; i++)
            {
                max = Math.Max(max, Math.Max(left[i], right[i]));
            }

            return max;
        }
    }
}