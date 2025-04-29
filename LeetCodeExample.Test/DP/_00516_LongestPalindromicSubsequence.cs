using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given a string s, find the longest palindromic subsequence's length in s.
    // A subsequence is a sequence that can be derived from another sequence by deleting some or no elements without changing the order of the remaining elements.
    /// </summary>
    public class _00516_LongestPalindromicSubsequence
    {
        public int LongestPalindromeSubseq(string s)
        {
            int max = 1;
            for (int i = 0; i < s.Length; i++)
            {
                int check1 = dp(s, i, i);
                // Check between letters
                int check2 = dp(s, i, i + 1);
                int checkMax = Math.Max(check1, check2);
                max = Math.Max(max, checkMax);
            }
            return max;
        }

        Dictionary<(int l, int r), int> map = new Dictionary<(int l, int r), int>();

        public int dp(string s, int l, int r)
        {
            if (l < 0 || r >= s.Length)
            {
                return 0;
            }
            int rtn = 0;
            if (map.ContainsKey((l, r)))
            {
                return map[(l, r)];
            }
            // Found a pair, expand both left and right
            if (s[l] == s[r])
            {
                rtn = dp(s, l - 1, r + 1) + (l == r ? 1 : 2);
            }
            // Didn't find a pair, try both left and right and return the greater of the two
            else
            {
                int lCount = dp(s, l - 1, r);
                int rCount = dp(s, l, r + 1);
                rtn = Math.Max(lCount, rCount);
            }
            map.Add((l, r), rtn);
            return rtn;
        }
    }
}