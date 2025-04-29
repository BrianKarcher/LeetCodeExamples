using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    /// Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.
    /// </summary>
    public class MergeIntervals_56_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            int[][] answer;
            answer = Merge(new int[][] { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } });
            Assert.AreEqual(new int[][] { new int[] { 1, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } }, answer);

            answer = Merge(new int[][] { new int[] { 1, 4 }, new int[] { 4, 5 } });
            Assert.AreEqual(new int[][] { new int[] { 1, 5 } }, answer);
        }

        private Dictionary<int, int> map;

        public int[][] Merge(int[][] intervals)
        {
            // Sort by first column
            var sortedIntervals = intervals.OrderBy(i => i[0]);

            // The ending value will get expanded as we add more intervals that fall within the range
            int currentMergeBlockStartingValue = sortedIntervals.First()[0];
            int currentMergeBlockEndingValue = sortedIntervals.First()[1];

            List<int[]> mergedIntervals = new List<int[]>();

            foreach (var interval in sortedIntervals)
            {
                if (interval[0] <= currentMergeBlockEndingValue)
                {
                    // Ranges overlap, add the interval to the merge
                    currentMergeBlockEndingValue = currentMergeBlockEndingValue < interval[1] ? interval[1] : currentMergeBlockEndingValue;
                }
                else
                {
                    // Gap found, add previous merged interval to the list
                    mergedIntervals.Add(new int[] { currentMergeBlockStartingValue, currentMergeBlockEndingValue });
                    // start a new merged interval with the current interval's range
                    currentMergeBlockStartingValue = interval[0];
                    currentMergeBlockEndingValue = interval[1];
                }
            }

            // Add the last merged interval to the list (many people might miss this)
            mergedIntervals.Add(new int[] { currentMergeBlockStartingValue, currentMergeBlockEndingValue });

            return mergedIntervals.ToArray();
        }

        public int[][] Merge2(int[][] intervals)
        {
            // Sort by first column
            var sortedIntervals = intervals.OrderBy(i => i[0]).ToArray();
            List<int[]> mergedIntervals = new List<int[]>();
            for (int i = 0; i < sortedIntervals.Length; i++)
            {
                /// If first merge, or the last "end" is less than the current "start", begin a new merge interval
                if (!mergedIntervals.Any() || mergedIntervals.Last()[1] < sortedIntervals[i][0])
                {
                    mergedIntervals.Add(new int[] { sortedIntervals[i][0], sortedIntervals[i][1] });
                }
                else
                {
                    // Merge the interval into the last
                    mergedIntervals.Last()[1] = Math.Max(mergedIntervals.Last()[1], sortedIntervals[i][1]);
                }
            }
            return mergedIntervals.ToArray();
        }
    }
}