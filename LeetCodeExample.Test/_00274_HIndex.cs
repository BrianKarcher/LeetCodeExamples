using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given an array of integers citations where citations[i] is the number of citations a researcher received for their ith paper, return compute the researcher's h-index.
    //According to the definition of h-index on Wikipedia: A scientist has an index h if h of their n papers have at least h citations each, and the other n − h papers have no more than h citations each.
    //If there are several possible values for h, the maximum one is taken as the h-index.
    /// </summary>
    public class _00274_HIndex
    {
        public int HIndex(int[] citations)
        {
            var orderedCits = citations.OrderByDescending(i => i).ToList();
            int hIndex = 0;
            for (int i = 0; i < orderedCits.Count; i++)
            {
                if (orderedCits[i] > i)
                    hIndex = i + 1;
                else
                    break;
            }
            return hIndex;
        }
    }
}