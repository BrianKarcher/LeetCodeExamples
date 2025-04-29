using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //There is a row of n houses, where each house can be painted one of three colors: red, blue, or green.The cost of painting each house with a certain color is different.You have to paint all the houses such that no two adjacent houses have the same color.

    //The cost of painting each house with a certain color is represented by an n x 3 cost matrix costs.

    //For example, costs[0][0] is the cost of painting house 0 with the color red; costs[1][2] is the cost of painting house 1 with color green, and so on...
    //Return the minimum cost to paint all houses.
    /// </summary>
    public class _00256_PaintHouse
    {
        public int MinCost(int[][] costs)
        {
            int n = costs.Length;
            int[,] dp = new int[n + 1, 3];
            for (int i = 1; i <= n; i++)
            {
                // red
                dp[i, 0] = Math.Min(dp[i - 1, 1], dp[i - 1, 2]) + costs[i - 1][0];
                // blue
                dp[i, 1] = Math.Min(dp[i - 1, 0], dp[i - 1, 2]) + costs[i - 1][1];
                // green
                dp[i, 2] = Math.Min(dp[i - 1, 0], dp[i - 1, 1]) + costs[i - 1][2];
            }
            return Math.Min(dp[n, 0], Math.Min(dp[n, 1], dp[n, 2]));
        }
    }
}