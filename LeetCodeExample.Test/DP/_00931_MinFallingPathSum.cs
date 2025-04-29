using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an n x n array of integers matrix, return the minimum sum of any falling path through matrix.

    // A falling path starts at any element in the first row and chooses the element in the next row that is either
    // directly below or diagonally left/right.Specifically, the next element from
    // position(row, col) will be(row + 1, col - 1), (row + 1, col), or(row + 1, col + 1).
    /// </summary>
    public class _00931_MinFallingPathSum
    {
        public int MinFallingPathSum(int[][] matrix)
        {
            int[,] dp = new int[matrix.Length, matrix.Length];
            // Base case (bottom row)
            for (int i = 0; i < matrix.Length; i++)
            {
                dp[matrix.Length - 1, i] = matrix[matrix.Length - 1][i];
            }
            // Iterate each row going up, choosing the minimum sum along the way
            for (int r = matrix.Length - 2; r >= 0; r--)
            {
                for (int c = 0; c < matrix.Length; c++)
                {
                    int dl = c == 0 ? Int32.MaxValue : dp[r + 1, c - 1];
                    int dm = dp[r + 1, c];
                    int dr = c == matrix.Length - 1 ? Int32.MaxValue : dp[r + 1, c + 1];
                    dp[r, c] = Math.Min(dl, Math.Min(dm, dr)) + matrix[r][c];
                }
            }
            // Find min in the top row
            int min = Int32.MaxValue;
            for (int i = 0; i < matrix.Length; i++)
            {
                min = Math.Min(min, dp[0, i]);
            }
            return min;
        }
    }
}