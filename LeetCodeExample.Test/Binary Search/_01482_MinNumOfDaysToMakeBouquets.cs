using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You are given an integer array bloomDay, an integer m and an integer k.
    //You want to make m bouquets.To make a bouquet, you need to use k adjacent flowers from the garden.

    //The garden consists of n flowers, the ith flower will bloom in the bloomDay[i] and then can be used in exactly one bouquet.
    //Return the minimum number of days you need to wait to be able to make m bouquets from the garden. If it is impossible to make m bouquets return -1.
    /// </summary>
    public class _01482_MinNumOfDaysToMakeBouquets
    {
        public int MinDays(int[] bloomDay, int m, int k)
        {
            if (m * k > bloomDay.Length)
                return -1;

            // Do a binary search to find the minimum number of days
            int l = Int32.MaxValue;
            int r = Int32.MinValue;
            for (int i = 0; i < bloomDay.Length; i++)
            {
                if (bloomDay[i] < l)
                    l = bloomDay[i];
                if (bloomDay[i] > r)
                    r = bloomDay[i];
            }

            // This is a one-space Binary Search, it keeps refining until it finds the best value
            while (l < r)
            {
                int day = (l + r) / 2;
                int c = count(bloomDay, day, k);
                if (m > c)
                    l = day + 1;
                else
                    r = day;
            }
            return l;
        }

        // Count of number of bouquets possible on any given day
        public int count(int[] bloomDay, int day, int k)
        {
            int runningCount = 0;
            int c = 0;
            for (int i = 0; i < bloomDay.Length; i++)
            {
                if (bloomDay[i] > day)
                {
                    runningCount = 0;
                }
                else
                {
                    runningCount++;
                    if (runningCount >= k)
                    {
                        c++;
                        runningCount = 0;
                    }
                }
            }
            return c;
        }

        //public int MinDays(int[] bloomDay, int m, int k)
        //{
        //    if (m * k > bloomDay.Length)
        //        return -1;

        //    HashSet<int> days = new HashSet<int>();
        //    List<(int day, int count)> grp = new List<(int day, int count)>();
        //    //grp.Add(new(int day, int count));
        //    int iday = 0;
        //    int icount = 0;
        //    for (int i = 0; i < bloomDay.Length; i++)
        //    {
        //        days.Add(bloomDay[i]);
        //        if (bloomDay[i] != iday)
        //        {
        //            if (icount != 0)
        //            {
        //                grp.Add((iday, icount));
        //            }
        //            iday = bloomDay[i];
        //            icount = 0;
        //        }
        //        icount++;
        //    }
        //    if (icount != 0)
        //    {
        //        grp.Add((iday, icount));
        //    }

        //    var orderedDays = days.OrderBy(i => i).ToList();

        //    // Do a binary search to find the minimum number of days
        //    int l = 0;
        //    int r = orderedDays.Count - 1;
        //    // This is a one-space Binary Search, it keeps refining until it finds the best value
        //    while (l < r)
        //    {
        //        int mid = (l + r) / 2;
        //        int day = orderedDays[mid];
        //        int c = count(grp, day, k);
        //        if (m > c)
        //            l = mid + 1;
        //        else
        //            r = mid;
        //    }
        //    return orderedDays[l];
        //}

        //// Count of number of bouquets possible on any given day
        //public int count(List<(int day, int count)> grp, int day, int k)
        //{
        //    int runningCount = 0;
        //    int c = 0;
        //    for (int i = 0; i < grp.Count; i++)
        //    {
        //        if (grp[i].day > day)
        //        {
        //            runningCount = 0;
        //        }
        //        else
        //        {
        //            runningCount += grp[i].count;
        //            while (runningCount >= k)
        //            {
        //                c++;
        //                runningCount -= k;
        //            }
        //        }
        //    }
        //    return c;
        //}
    }
}