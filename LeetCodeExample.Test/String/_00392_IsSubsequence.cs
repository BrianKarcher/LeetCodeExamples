using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given two strings s and t, return true if s is a subsequence of t, or false otherwise.

    //A subsequence of a string is a new string that is formed from the original string by deleting some(can be none)
    //of the characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde"
    //while "aec" is not).
    /// </summary>
    public class _00392_IsSubsequence
    {
        public bool IsSubsequence(string s, string t)
        {
            if (s.Length == 0)
            {
                return true;
            }
            int si = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (s[si] == t[i])
                {
                    si++;
                    if (si == s.Length)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}