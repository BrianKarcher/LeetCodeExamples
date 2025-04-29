using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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

        //////////////////////////////////////
        ///

        public int[][] Insert2(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0)
            {
                return new int[][] { newInterval };
            }
            List<int[]> rtn = new();
            bool hasPlaced = false;
            for (int i = 0; i < intervals.Length; i++)
            {
                if (!hasPlaced && newInterval[1] < intervals[i][0])
                {
                    rtn.Add(newInterval);
                    rtn.Add(intervals[i]);
                    hasPlaced = true;
                }
                else if (!hasPlaced && IsIntersecting(intervals[i][0], intervals[i][1], newInterval[0], newInterval[1]))
                {
                    rtn.Add(Combine(intervals[i][0], intervals[i][1], newInterval[0], newInterval[1]));
                    hasPlaced = true;
                }
                else if (rtn.Count > 0 && IsIntersecting(rtn.Last()[0], rtn.Last()[1], intervals[i][0], intervals[i][1]))
                {
                    rtn[rtn.Count - 1] = Combine(rtn.Last()[0], rtn.Last()[1], intervals[i][0], intervals[i][1]);
                }
                else
                {
                    rtn.Add(intervals[i]);
                }
            }
            if (!hasPlaced)
            {
                rtn.Add(newInterval);
            }
            return rtn.ToArray();
        }

        public bool IsIntersecting(int s1, int e1, int s2, int e2)
        {
            return s2 <= e1 && e2 >= s1;
        }

        int[] Combine(int s1, int e1, int s2, int e2)
        {
            return new int[] { Math.Min(s1, s2), Math.Max(e1, e2) };
        }
    }
}