using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an m x n binary matrix mat, return the length of the longest line of consecutive one in the matrix.

    //The line could be horizontal, vertical, diagonal, or anti-diagonal.
    /// </summary>
    public class _00562_LongestLineOfConsecutiveOneInMatrix
    {
        public int LongestLine(int[][] mat)
        {
            int m = mat.Length;
            int n = mat[0].Length;
            int[,] vert = new int[m + 2, n + 2];
            int[,] horz = new int[m + 2, n + 2];
            int[,] diag = new int[m + 2, n + 2];

            int max = 0;
            for (int r = 1; r <= m; r++)
            {
                for (int c = 1; c <= n; c++)
                {
                    if (mat[r - 1][c - 1] == 1)
                    {
                        vert[r, c] = vert[r - 1, c] + 1;
                        max = Math.Max(max, vert[r, c]);
                        horz[r, c] = horz[r, c - 1] + 1;
                        max = Math.Max(max, horz[r, c]);
                        diag[r, c] = diag[r - 1, c - 1] + 1;
                        max = Math.Max(max, diag[r, c]);
                    }
                }
            }

            int[,] antidiag = new int[m + 2, n + 2];
            for (int r = m; r > 0; r--)
            {
                for (int c = 1; c <= n; c++)
                {
                    if (mat[r - 1][c - 1] == 1)
                    {
                        antidiag[r, c] = antidiag[r + 1, c - 1] + 1;
                        max = Math.Max(max, antidiag[r, c]);
                    }
                }
            }
            return max;
        }
    }
}