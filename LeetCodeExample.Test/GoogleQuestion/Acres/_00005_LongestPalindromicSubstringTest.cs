using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
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

        // Use LCS approach (S and reverse S, then find longest common substring)
        public string LongestPalindrome2(string s)
        {
            int[,] dp = new int[s.Length, s.Length];
            int size = 0;
            string rtn = string.Empty;
            /*char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            string rs = new string(arr);*/
            string rs = string.Empty;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                rs += s[i];
            }
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < rs.Length; j++)
                {
                    if (s[i] == rs[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            dp[i, j] = 1;
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j - 1] + 1;
                        }
                        if (dp[i, j] > size)
                        {
                            size = dp[i, j];
                            rtn = s.Substring(i - size + 1, size);
                        }
                    }
                }
            }
            return rtn;
        }
    }
}