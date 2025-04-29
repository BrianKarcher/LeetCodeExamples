using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given a m x n matrix mat and an integer k, return a matrix answer where each answer[i][j] is the sum of all elements mat[r][c] for:

    //i - k <= r <= i + k,
    //j - k <= c <= j + k, and
    //(r, c) is a valid position in the matrix.
    /// </summary>
    public class _01314_MatrixBlockSum
    {
        // 1    2   3
        // 4    5   6
        // 7    8   9

        //  1   3   6
        //  5   12  21
        //  12  27  45
        // dp[r, c] = dp[r - 1, c] + dp[r, c - 1] + mat[r, c] - dp[r - 1, c - 1]

        public int[][] MatrixBlockSum(int[][] mat, int k)
        {
            int rows = mat.Length;
            int cols = mat[0].Length;
            int[,] sums = new int[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    int sumu = r == 0 ? 0 : sums[r - 1, c];
                    int suml = c == 0 ? 0 : sums[r, c - 1];
                    int sumul = r == 0 || c == 0 ? 0 : sums[r - 1, c - 1];
                    sums[r, c] = sumu + suml + mat[r][c] - sumul;
                }
            }
            int[][] ans = new int[rows][];
            // We find the sum of the box from (0,0) to the bottom-right of the block.
            for (int r = 0; r < rows; r++)
            {
                ans[r] = new int[cols];
                for (int c = 0; c < cols; c++)
                {
                    // Box boundaries
                    int right = Math.Min(cols - 1, c + k);
                    int down = Math.Min(rows - 1, r + k);
                    int leftMinusOne = c - k - 1;
                    int upMinusOne = r - k - 1;
                    int sum = sums[down, right];
                    // Need to subtract the left and up side areas
                    if (leftMinusOne >= 0)
                    {
                        sum -= sums[down, leftMinusOne];
                    }
                    if (upMinusOne >= 0)
                    {
                        sum -= sums[upMinusOne, right];
                    }
                    // Add in one top-left box since it got subtracted twice
                    if (leftMinusOne >= 0 && upMinusOne >= 0)
                    {
                        sum += sums[upMinusOne, leftMinusOne];
                    }
                    ans[r][c] = sum;
                }
            }
            return ans;
        }
    }
}