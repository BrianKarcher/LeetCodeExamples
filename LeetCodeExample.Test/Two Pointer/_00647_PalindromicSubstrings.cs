using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given a string s, return the number of palindromic substrings in it.
    //A string is a palindrome when it reads the same backward as forward.
    //A substring is a contiguous sequence of characters within the string.
    /// </summary>
    public class _00647_PalindromicSubstrings
    {
        public int CountSubstrings(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                count += Expand(s, i, i);
                count += Expand(s, i, i + 1);
            }
            return count;
        }

        public int Expand(string s, int l, int r)
        {
            int count = 0;
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                count++;
                l--;
                r++;
            }
            return count;
        }
    }
}