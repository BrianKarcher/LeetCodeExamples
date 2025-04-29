using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //There are a row of n houses, each house can be painted with one of the k colors.The cost of painting each house with a certain color is different.You have to paint all the houses such that no two adjacent houses have the same color.

    //The cost of painting each house with a certain color is represented by an n x k cost matrix costs.

    //For example, costs[0][0] is the cost of painting house 0 with color 0; costs[1][2] is the cost of painting house 1 with color 2, and so on...
    //Return the minimum cost to paint all houses.
    /// </summary>
    public class _00265_PaintHouseII
    {
        public int MinCostII(int[][] costs)
        {
            int n = costs.Length;
            int colorCount = costs[0].Length;
            int[,] dp = new int[n + 1, costs[0].Length];
            for (int i = 1; i <= n; i++)
            {
                for (int newC = 0; newC < colorCount; newC++)
                {
                    int min = Int32.MaxValue;
                    // Find the cheapest color among the previous set of houses
                    // where the color is not the same
                    for (int oldC = 0; oldC < colorCount; oldC++)
                    {
                        if (oldC == newC)
                        {
                            continue;
                        }
                        min = Math.Min(min, dp[i - 1, oldC]);
                    }
                    dp[i, newC] = min + costs[i - 1][newC];
                }
            }
            int ans = Int32.MaxValue;
            for (int c = 0; c < colorCount; c++)
            {
                ans = Math.Min(ans, dp[n, c]);
            }
            return ans;
        }
    }
}