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
            int[,] sums = new int[rows + 1, cols + 1];
            for (int r = 1; r <= rows; r++)
            {
                for (int c = 1; c <= cols; c++)
                {
                    sums[r, c] = sums[r - 1, c] + sums[r, c - 1] + mat[r - 1][c - 1] - sums[r - 1, c - 1];
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
                    int c1 = Math.Max(0, c - k);
                    int r1 = Math.Max(0, r - k);
                    int c2 = Math.Min(cols - 1, c + k);
                    int r2 = Math.Min(rows - 1, r + k);
                    r1++; r2++; c1++; c2++; // Since `sum` start with 1 so we need to increase r1, c1, r2, c2 by 1
                    // Need to subtract the left and up side areas
                    // Add in one top-left box since it got subtracted twice
                    ans[r][c] = sums[r2, c2] - sums[r2, c1 - 1] - sums[r1 - 1, c2] + sums[r1 - 1, c1 - 1];
                }
            }
            return ans;
        }
    }
}