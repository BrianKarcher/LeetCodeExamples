using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given a 2D matrix matrix, handle multiple queries of the following type:

    //Calculate the sum of the elements of matrix inside the rectangle defined by its upper left corner(row1, col1) and lower right corner(row2, col2).
    //Implement the NumMatrix class:

    //NumMatrix(int[][] matrix) Initializes the object with the integer matrix matrix.
    //int sumRegion(int row1, int col1, int row2, int col2) Returns the sum of the elements of matrix inside the rectangle defined by its upper left corner (row1, col1) and lower right corner (row2, col2).
    //You must design an algorithm where sumRegion works on O(1) time complexity.
    /// </summary>
    public class _00304_RangeSumQuery2D
    {
        // 1    2   3
        // 4    5   6
        // 7    8   9

        //  1   3   6
        //  5   12  21
        //  12  27  45
        // dp[r, c] = dp[r - 1, c] + dp[r, c - 1] + mat[r, c] - dp[r - 1, c - 1]

        int[,] sums;
        public NumMatrix(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            sums = new int[rows + 1, cols + 1];

            for (int r = 1; r <= rows; r++)
            {
                for (int c = 1; c <= cols; c++)
                {
                    sums[r, c] = sums[r - 1, c] + sums[r, c - 1] + matrix[r - 1][c - 1] - sums[r - 1, c - 1];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            // We find the sum of the box from (0,0) to the bottom-right of the block.
            // Need to subtract the left and up side areas
            // Add in one top-left box since it got subtracted twice
            return sums[row2 + 1, col2 + 1] - sums[row2 + 1, col1] - sums[row1, col2 + 1] + sums[row1, col1];
        }
    }
}