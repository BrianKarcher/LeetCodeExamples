using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an m x n integer matrix points(0-indexed). Starting with 0 points, you want to maximize the number of points you can get from the matrix.

    //   To gain points, you must pick one cell in each row. Picking the cell at coordinates (r, c) will add points[r][c] to your score.

    //   However, you will lose points if you pick a cell too far from the cell that you picked in the previous row.For every two adjacent rows r and r + 1 (where 0 <= r<m - 1), picking cells at coordinates(r, c1) and(r + 1, c2) will subtract abs(c1 - c2) from your score.

    //Return the maximum number of points you can achieve.
    /// </summary>
    public class _01937_MaxNumberOfPointsWithCost_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public long MaxPoints(int[][] points)
        {
            int rows = points.Length;
            int cols = points[0].Length;

            long[] dp = new long[cols];

            // For each cell, look at the row above it and find the max possible value for that cell.
            // Start at the second row
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    dp[j] += points[i][j];
                }

                //left to right pass
                for (int j = 1; j < cols; j++)
                {
                    dp[j] = Math.Max(dp[j], dp[j - 1] - 1);
                }

                //right to left pass
                for (int j = cols - 2; j >= 0; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j + 1] - 1);
                }
            }

            // When we reach the last row, find the one with the max value and return it.
            long maxPoints = 0;
            for (int j = 0; j < cols; j++)
            {
                maxPoints = Math.Max(maxPoints, dp[j]);
            }
            return maxPoints;
        }
    }
}