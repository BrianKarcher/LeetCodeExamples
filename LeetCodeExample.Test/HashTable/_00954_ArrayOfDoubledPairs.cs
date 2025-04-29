using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an integer array of even length arr, return true if it is possible to reorder arr such that arr[2 * i + 1] = 2 * arr[2 * i] for every 0 <= i<len(arr) / 2, or false otherwise.
    /// </summary>
    public class _00954_ArrayOfDoubledPairs
    {
        public bool CanReorderDoubled(int[] arr)
        {
            var sortedArray = arr.OrderBy(i => Math.Abs(i));
            Dictionary<int, int> count = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (!count.ContainsKey(num))
                    count.Add(num, 1);
                else
                    count[num]++;
            }

            foreach (var num in sortedArray)
            {
                // If this can't be consumed, skip
                if (count[num] == 0)
                    continue;

                int otherNum = num * 2;
                // If this doesn't have a doubled partner, the answer is false
                if (!count.ContainsKey(otherNum) || count[otherNum] <= 0)
                    return false;
                // Write x, 2x
                count[num]--;
                count[otherNum]--;
            }

            // If we have written everything, the answer is true
            return true;
        }
    }
}