using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given a string s, return the longest palindromic substring in s.
    /// </summary>
    public class _00005_LongestPalindromicSubstringTest
    {
        public string LongestPalindrome(string s)
        {
            int start = 0;
            int end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = Expand(s, i, i);
                // Palindromes can start in between letters
                // example: abba
                int len2 = Expand(s, i, i + 1);
                int max = Math.Max(len1, len2);
                if (max > end - start)
                {
                    start = i - (max - 1) / 2;
                    end = i + max / 2;
                }
            }
            return s.Substring(start, end - start + 1);
        }

        public int Expand(string s, int l, int r)
        {
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
            }
            return r - l - 1;
        }
    }
}