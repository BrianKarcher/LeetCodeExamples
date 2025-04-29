using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an array colors, in which there are three colors: 1, 2 and 3.
    //You are also given some queries.Each query consists of two integers i and c, return the shortest distance between the given index i and the target color c.If there is no solution return -1.
    /// </summary>
    public class _01182_ShortestDistanceToTargetColor
    {
        public IList<int> ShortestDistanceColor(int[] colors, int[][] queries)
        {
            int m = colors.Length;
            int[,] dp = new int[m, 3];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dp[i, j] = m + 1;
                }
            }

            dp[0, colors[0] - 1] = 0;
            for (int i = 1; i < m; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // If we land on the color the distance is 0. Otherwise it is
                    // the previous location + 1.
                    int newColor = j == colors[i] - 1 ? 0 : dp[i - 1, j] + 1;
                    dp[i, j] = Math.Min(dp[i, j], newColor);
                    //Console.WriteLine($"{i},{j}, {dp[i, j]}");
                }
            }

            dp[m - 1, colors[m - 1] - 1] = 0;
            for (int i = m - 2; i >= 0; i--)
            {
                for (int j = 0; j < 3; j++)
                {
                    // If we land on the color the distance is 0. Otherwise it is
                    // the previous location + 1.
                    dp[i, j] = Math.Min(dp[i, j], dp[i + 1, j] + 1);
                }
            }

            List<int> ans = new List<int>(queries.Length);
            for (int i = 0; i < queries.Length; i++)
            {
                int color = dp[queries[i][0], queries[i][1] - 1];
                ans.Add(color == m + 1 ? -1 : color);
            }
            return ans;
        }
    }
}