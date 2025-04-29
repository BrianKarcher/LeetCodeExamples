using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
   // You are given a 2D integer array ranges and two integers left and right.Each ranges[i] = [starti, endi] represents an inclusive interval between starti and endi.

   //Return true if each integer in the inclusive range[left, right] is covered by at least one interval in ranges.Return false otherwise.

   //An integer x is covered by an interval ranges[i] = [starti, endi] if starti <= x <= endi.
    /// </summary>
    public class _01893_IntegersInRangeAreCovered
    {
        public bool IsCovered(int[][] ranges, int left, int right)
        {
            // Sort by start of range
            var sortedRanges = ranges.OrderBy(i => i[0]);
            foreach (var range in sortedRanges)
            {
                // Check Start with Left, and keep pushing Left to the right as necessary to cover the range
                int l = range[0];
                int r = range[1];
                // Check if the range covers the left portion of our check
                if (l <= left && r >= left)
                {
                    // Push left to the right
                    left = r + 1;
                }
            }
            return left > right;
        }
    }
}