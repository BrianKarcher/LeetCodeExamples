using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
        //There is a one-dimensional garden on the x-axis.The garden starts at the point 0 and ends at the point n. (i.e The length of the garden is n).
        //There are n + 1 taps located at points[0, 1, ..., n] in the garden.
        //Given an integer n and an integer array ranges of length n + 1 where ranges[i] (0-indexed) means the i-th tap can water the area[i - ranges[i], i + ranges[i]] if it was open.
        //Return the minimum number of taps that should be open to water the whole garden, If the garden cannot be watered return -1.
    /// </summary>
    public class _01326_MinNumberOfTapsWaterGarden_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        int gardenSize = 0;
        List<(int l, int r)> lstRanges;

        public int MinTaps(int n, int[] ranges)
        {
            gardenSize = n;

            lstRanges = new List<(int, int)>();
            for (int i = 0; i < ranges.Length; i++)
            {
                // No range? Skip!
                if (ranges[i] == 0)
                    continue;
                lstRanges.Add((i - ranges[i], i + ranges[i]));
            }
            if (lstRanges.Count == 0)
                return -1;
            lstRanges = lstRanges.OrderBy(i => i.l).ToList();

            int res = dp(0, 0);
            if (res == -1)
                return -1;

            // Subtracting 1 for the "root" search
            return res - 1;
        }

        public int dp(int index, int rightMax)
        {
            // Base case
            if (index > lstRanges.Count - 1)
                return -1;
            if (lstRanges[index].r >= gardenSize)
                return 1;

            int maxR = rightMax;
            int nextBestIndex = -1;
            // Find next best range - the one that stretches the furthest out yet covers this index as well
            for (int i = index; i < lstRanges.Count && lstRanges[i].l <= rightMax; i++)
            {
                if (lstRanges[i].r > maxR)
                {
                    maxR = lstRanges[i].r;
                    nextBestIndex = i;
                }
            }
            // Can't find a tap to continue watering the garden...
            if (nextBestIndex == -1)
                return -1;

            int res = dp(nextBestIndex, lstRanges[nextBestIndex].r);
            if (res == -1)
                return -1;

            return res + 1;
        }
    }
}