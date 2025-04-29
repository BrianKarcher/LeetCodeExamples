using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given two integer arrays nums1 and nums2.We write the integers of nums1 and nums2(in the order they are given) on two separate horizontal lines.

    //    We may draw connecting lines: a straight line connecting two numbers nums1[i] and nums2[j] such that:

    //nums1[i] == nums2[j], and
    //the line we draw does not intersect any other connecting(non-horizontal) line.
    //Note that a connecting line cannot intersect even at the endpoints(i.e., each number can only belong to one connecting line).

    //Return the maximum number of connecting lines we can draw in this way.
    /// </summary>
    public class _01035_UncrossedLines
    {
        public int MaxUncrossedLines(int[] nums1, int[] nums2)
        {
            int[,] dp = new int[nums1.Length + 1, nums2.Length + 1];
            for (int i = 1; i <= nums1.Length; i++)
            {
                for (int j = 1; j <= nums2.Length; j++)
                {
                    if (nums1[i - 1] == nums2[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[nums1.Length, nums2.Length];
        }
    }
}