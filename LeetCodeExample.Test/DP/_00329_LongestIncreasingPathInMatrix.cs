using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an m x n integers matrix, return the length of the longest increasing path in matrix.
    // From each cell, you can either move in four directions: left, right, up, or down.You may not move diagonally or move outside the boundary (i.e., wrap-around is not allowed).
    /// </summary>
    public class _00329_LongestIncreasingPathInMatrix
    {
        public int LongestIncreasingPath(int[][] matrix)
        {
            memo = new int[matrix.Length, matrix[0].Length];
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    dp(matrix, r, c);
                }
            }
            return finalMax;
        }

        int[,] memo;
        int finalMax = 1;
        List<(int r, int c)> dir = new List<(int, int)>() { (-1, 0), (1, 0), (0, 1), (0, -1) };
        int dp(int[][] matrix, int r, int c)
        {
            if (memo[r, c] != 0)
                return memo[r, c];

            int max = 0;
            for (int i = 0; i < dir.Count; i++)
            {
                // bounds check
                int nc = c + dir[i].c;
                int nr = r + dir[i].r;
                if (nc < 0 || nr < 0 || nr > matrix.Length - 1 || nc > matrix[0].Length - 1)
                    continue;
                // New cell must be getting larger
                if (matrix[nr][nc] <= matrix[r][c])
                    continue;
                int otherCount = dp(matrix, nr, nc);
                max = Math.Max(max, otherCount);
            }
            memo[r, c] = max + 1;
            finalMax = Math.Max(finalMax, max + 1);
            return max + 1;
        }
    }
}