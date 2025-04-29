using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given two strings s1 and s2, return the lowest ASCII sum of deleted characters to make two strings equal.
    /// </summary>
    public class _00712_MinimumASCIIDeleteSumForTwoStrings
    {
        public int?[,] memo;

        public int MinimumDeleteSum(string s1, string s2)
        {
            memo = new int?[s1.Length, s2.Length];
            return dp(s1, s2, s1.Length - 1, s2.Length - 1);
        }

        public int dp(string s1, string s2, int i1, int i2)
        {
            // If either reaches the end, count up the remaining characters in the other.
            if (i1 < 0)
            {
                int count = 0;
                for (int i = i2; i >= 0; i--)
                {
                    count += s2[i];
                }
                return count;
            }
            if (i2 < 0)
            {
                int count = 0;
                for (int i = i1; i >= 0; i--)
                {
                    count += s1[i];
                }
                return count;
            }

            if (memo[i1, i2] != null)
            {
                return memo[i1, i2].Value;
            }
            int ans = Int32.MaxValue;
            // If letters match, don't need to delete.
            if (s1[i1] == s2[i2])
            {
                ans = dp(s1, s2, i1 - 1, i2 - 1);
            }
            else
            {
                // Check deleting either one
                // delete i1
                int a1 = (int)s1[i1] + dp(s1, s2, i1 - 1, i2);
                int a2 = (int)s2[i2] + dp(s1, s2, i1, i2 - 1);
                ans = Math.Min(a1, a2);
            }
            memo[i1, i2] = ans;
            return ans;
        }
    }
}