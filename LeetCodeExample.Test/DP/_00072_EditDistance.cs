using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

    //    You have the following three operations permitted on a word:

    //Insert a character
    //Delete a character
    //Replace a character
    /// </summary>
    public class _00072_EditDistance
    {
        public int minDistance(String word1, String word2)
        {
            int n = word1.Length;
            int m = word2.Length;

            // if one of the strings is empty
            if (n * m == 0)
                return n + m;

            // array to store the convertion history
            int[,] d = new int[n + 1, m + 1];

            // init boundaries
            for (int i = 0; i < n + 1; i++)
            {
                d[i,0] = i;
            }
            for (int j = 0; j < m + 1; j++)
            {
                d[0,j] = j;
            }

            // DP compute 
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < m + 1; j++)
                {
                    int left = d[i - 1,j] + 1;
                    int down = d[i,j - 1] + 1;
                    int left_down = d[i - 1,j - 1];
                    if (word1[i - 1] != word2[j - 1])
                        left_down += 1;
                    d[i,j] = Math.Min(left, Math.Min(down, left_down));

                }
            }
            return d[n,m];
        }


        public int MinDistance(string word1, string word2)
        {
            dp = new int[word1.Length + 1, word2.Length + 1];
            for (int i = 0; i <= word1.Length; i++)
            {
                for (int j = 0; j <= word2.Length; j++)
                {
                    dp[i, j] = -1;
                }
            }
            return solve(word1, word2, word1.Length, word2.Length);
        }

        int[,] dp;

        int solve(string s1, string s2, int m, int n)
        {
            if (dp[m, n] != -1)
                return dp[m, n]; // if any string become zero then minimum insertion required is  second string length
            if (m == 0)
                return dp[m, n] = n;
            if (n == 0)
                return dp[m, n] = m;
            if (s1[m - 1] == s2[n - 1])
            {
                return dp[m, n] = solve(s1, s2, m - 1, n - 1); // both  last character match then call by removing last character from both string. This is not an operation so no count is added
            }
            else
            {
                // we are doing 1 operation so adding 1 to result and taking minimum of insert,delete and replace.
                return dp[m, n] = 1 + Math.Min(solve(s1, s2, m, n - 1), Math.Min(solve(s1, s2, m - 1, n), solve(s1, s2, m - 1, n - 1)));
                //insert the charcter in string one so 1st string remain same  and string 2 reduces by 1 (after inserting both matches);
                //delete the last character in string 1 and  second string remain same (after deleting both matches)
                //replace the  last character in string 1 so both both character match so both string reduces by 1 (after replacing both matches)
            }
        }
    }
}