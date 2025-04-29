using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the start and the end of the ith interval and intervals is sorted in ascending order by starti.You are also given an interval newInterval = [start, end] that represents the start and end of another interval.

    //    Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have any overlapping intervals (merge overlapping intervals if necessary).

    //  Return intervals after the insertion.
    /// </summary>
    public class _00057_InsertInterval_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            // We will do this in two steps. First insert it, then merge any overlaps

            List<int[]> newIntervals = new List<int[]>();
            bool hasInserted = false;
            // Insert new interval into proper location
            for (int i = 0; i < intervals.Length; i++)
            {
                if (!hasInserted && newInterval[0] <= intervals[i][0])
                {
                    newIntervals.Add(newInterval);
                    hasInserted = true;
                }
                newIntervals.Add(intervals[i]);
            }

            if (!hasInserted)
                newIntervals.Add(newInterval);

            List<int[]> finalIntervals = new List<int[]>();

            int index = 0;
            // Merge overlaps into final List
            while (index < newIntervals.Count)
            {
                var currentInterval = newIntervals[index];
                // Check for merges
                while (index < newIntervals.Count - 1 && HasOverlap(currentInterval[0], currentInterval[1],
                                newIntervals[index + 1][0], newIntervals[index + 1][1]))
                {
                    currentInterval = Merge(currentInterval[0], currentInterval[1],
                                newIntervals[index + 1][0], newIntervals[index + 1][1]);
                    index++;
                }
                finalIntervals.Add(currentInterval);
                index++;
            }

            return finalIntervals.ToArray();
        }

        public bool HasOverlap(int start1, int end1, int start2, int end2)
        {
            if (start1 > end2 || start2 > end1)
                return false;
            return true;
        }

        public int[] Merge(int start1, int end1, int start2, int end2)
        {
            return new int[2] { Math.Min(start1, start2), Math.Max(end1, end2) };
        }
    }
}