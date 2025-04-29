using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //    Given two strings text1 and text2, return the length of their longest common subsequence.If there is no common subsequence, return 0.

    //A subsequence of a string is a new string generated from the original string with some characters(can be none) deleted without changing the relative order of the remaining characters.

    //For example, "ace" is a subsequence of "abcde".
    //A common subsequence of two strings is a subsequence that is common to both strings.
    /// </summary>
    public class _01143_LongestCommonSubsequence
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            memo = new int[text1.Length, text2.Length];
            for (int i = 0; i < text1.Length; i++)
            {
                for (int j = 0; j < text2.Length; j++)
                {
                    memo[i, j] = -1;
                }
            }
            return lcs(text1, text2, text1.Length - 1, text2.Length - 1);
        }

        int[,] memo;

        int lcs(string s1, string s2, int n, int m)
        {
            if (n < 0 || m < 0)
                return 0;

            if (memo[n, m] != -1)
                return memo[n, m];

            int val = 0;
            if (s1[n] == s2[m])
            {
                // Matching, decrease both indexes
                val = 1 + lcs(s1, s2, n - 1, m - 1);
            }
            else
            {
                // No match, try decreasing each n or m and see which is bigger
                var n1 = lcs(s1, s2, n - 1, m);
                var n2 = lcs(s1, s2, n, m - 1);
                val = Math.Max(n1, n2);
            }
            memo[n, m] = val;
            return val;
        }
    }
}