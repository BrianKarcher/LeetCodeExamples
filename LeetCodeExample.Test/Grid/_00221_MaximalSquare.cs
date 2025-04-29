using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an m x n binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.
    /// </summary>
    public class _00221_MaximalSquare
    {
        public int MaximalSquare(char[][] matrix)
        {
            int[,] dp = new int[matrix.Length, matrix[0].Length];

            int maxArea = 0;
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    if (matrix[r][c] == '1')
                    {
                        int size = 0;
                        if (r == 0 || c == 0)
                            size = 1;
                        else
                        {
                            int u = dp[r - 1, c];
                            int l = dp[r, c - 1];
                            int ul = dp[r - 1, c - 1];
                            int min = Math.Min(u, l);
                            min = Math.Min(min, ul);
                            size = min + 1;
                        }
                        dp[r, c] = size;
                        maxArea = Math.Max(maxArea, size * size);
                    }
                }
            }
            return maxArea;
        }

        //public int MaximalSquare(char[][] matrix)
        //{
        //    int maxArea = 0;
        //    int rowCount = matrix.Length;
        //    int colCount = matrix[0].Length;
        //    for (int r = 0; r < rowCount; r++)
        //    {
        //        for (int c = 0; c < colCount; c++)
        //        {
        //            // If we find a 1, then see how far the square expands
        //            if (matrix[r][c] == '1')
        //            {
        //                int max = GetSquareSize(matrix, r, c);
        //                maxArea = Math.Max(maxArea, max);
        //            }
        //        }
        //    }
        //    return maxArea;
        //}

        //public int GetSquareSize(char[][] matrix, int r, int c)
        //{
        //    int size = 1;
        //    while (r + size < matrix.Length && c + size < matrix[0].Length)
        //    {
        //        bool abort = false;
        //        // Check right side for 1's
        //        for (int y = r; y < r + size + 1; y++)
        //        {
        //            if (matrix[y][c + size] == '0')
        //            {
        //                abort = true;
        //                break;
        //            }
        //        }
        //        if (abort)
        //            break;

        //        // Check bottom side for 1's
        //        for (int x = c; x < c + size + 1; x++)
        //        {
        //            if (matrix[r + size][x] == '0')
        //            {
        //                abort = true;
        //                break;
        //            }
        //        }
        //        if (abort)
        //            break;

        //        size++;
        //    }
        //    return size * size;
        //}
    }
}