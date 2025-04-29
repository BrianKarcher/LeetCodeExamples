using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    A subsequence of a string is a new string that is formed from the original string by deleting some(can be none) of the characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).
    // Given two strings source and target, return the minimum number of subsequences of source such that their concatenation equals target.If the task is impossible, return -1.
    /// </summary>
    public class _01055_ShortestWayToFormString
    {
        /// <summary>
        /// Greedy algorithm. Checks how many loops it takes source to fill out the target. Time is O(M*N).
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ShortestWay(string source, string target)
        {
            char[] map = new char[256];
            foreach (char c in source) map[c] = '1';
            foreach (char c in target) if (map[c] != '1') return -1;
            int i = 0, j = 0;
            int res = 0;
            while (j < target.Length)
            {
                while (i < source.Length && j < target.Length)
                {
                    if (source[i] == target[j]) j++;
                    i++;
                }
                res++;
                i = 0;
            }
            return res;
        }

        /// <summary>
        /// ////////
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>

        public int ShortestWay3(string source, string target)
        {
            int[] dp = new int[target.Length];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = Int32.MaxValue;
            }
            for (int i = 0; i < target.Length; i++)
            {
                if (IsSubsequence(source, target, 0, i))
                {
                    dp[i] = 1;
                }
                else
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (IsSubsequence(source, target, j + 1, i))
                        {
                            dp[i] = Math.Min(dp[i], dp[j] + 1);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (dp[i] == Int32.MaxValue)
                {
                    return -1;
                }
            }
            return dp[target.Length - 1] == Int32.MaxValue ? -1 : dp[target.Length - 1];
        }

        bool IsSubsequence(string source, string sub, int l, int r)
        {
            /*if (subsequences.ContainsKey(sub)) {
                return subsequences[sub];
            }*/
            int count = 0;
            //Console.WriteLine($"Checking if {sub.Substring(l, r - l + 1)} is a subsequence of {source}");
            for (int i = 0; i < source.Length && l + count <= r; i++)
            {
                if (source[i] == sub[l + count])
                {
                    //Console.WriteLine($"{source[i]} matches {sub[subI]}");
                    count++;
                }
                else
                {
                    //Console.WriteLine($"{source[i]} does not match {sub[subI]}");
                }
            }
            bool ans = count == r - l + 1;
            //Console.WriteLine($"{l},{r},{sub.Substring(l, r - l + 1)} is a subsequence of {source} = {ans}, {count}");
            // Don't recalculate a subsequence check.
            //subsequences.Add(sub, ans);
            return ans;
        }


        /// <summary>
        /// /////////////////////////////
        /// </summary>
        /// 
        private Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();

        public int ShortestWay2(string source, string target)
        {
            int min = dp(source, target, 0, target.Length - 1);
            return min == Int32.MaxValue ? -1 : min;
        }

        public int dp(string source, string target, int l, int r)
        {
            //Console.WriteLine($"Checking {l},{r}");
            //Console.WriteLine($"Checking target {target.Substring(l, r - l + 1)}");
            if (l > r || l < 0 || r > target.Length - 1)
            {
                return Int32.MaxValue;
            }

            if (memo.ContainsKey((l, r)))
            {
                return memo[(l, r)];
            }

            if (IsSubsequence(source, target, l, r))
            {
                memo.Add((l, r), 1);
                return 1;
            }

            if (r - l < 2)
            {
                return Int32.MaxValue;
            }

            int min = Int32.MaxValue;
            // Find the place where the cut string is minimum.
            for (int i = l; i < r; i++)
            {
                // Left side of cut
                int a1 = Int32.MaxValue;
                int a2 = Int32.MaxValue;
                a1 = dp(source, target, 0, i);
                a2 = dp(source, target, i + 1, r);
                if (a1 == Int32.MaxValue || a2 == Int32.MaxValue)
                {
                    continue;
                }
                min = Math.Min(min, a1 + a2);
            }
            memo.Add((l, r), min);
            //Console.WriteLine($"Checking target {target.Substring(l, r - l + 1)}, = {min}");
            return min;
        }

        bool IsSubsequence2(string source, string sub, int l, int r)
        {
            int count = 0;
            for (int i = 0; i < source.Length && l + count <= r; i++)
            {
                if (source[i] == sub[l + count])
                {
                    count++;
                }
                else
                {
                }
            }
            bool ans = count == r - l + 1;
            //Console.WriteLine($"{l},{r},{sub.Substring(l, r - l + 1)} is a subsequence of {source} = {ans}, {count}");
            return ans;
        }
    }
}