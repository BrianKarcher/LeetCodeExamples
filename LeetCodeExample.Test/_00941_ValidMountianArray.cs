using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an array of integers arr, return true if and only if it is a valid mountain array.
    /// </summary>
    public class _00941_ValidMountianArray
    {
        public bool ValidMountainArray(int[] arr)
        {
            if (arr.Length < 3)
                return false;
            bool isIncreasing = true;
            int prev = arr[0];
            bool hasAnIncreasingValue = false;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == prev)
                    return false;
                if (isIncreasing && arr[i] > prev)
                {
                    hasAnIncreasingValue = true;
                }
                else if (isIncreasing && arr[i] < prev)
                {
                    isIncreasing = false;
                }
                else if (!isIncreasing && arr[i] > prev)
                {
                    return false;
                }
                prev = arr[i];
            }
            if (!hasAnIncreasingValue)
                return false;
            if (isIncreasing)
                return false;
            return true;
        }
    }
}