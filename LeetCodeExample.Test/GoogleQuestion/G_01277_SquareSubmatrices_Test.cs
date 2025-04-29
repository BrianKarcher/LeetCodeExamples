using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class G_01277_SquareSubmatrices_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = CountSquares(new int[][] {   new int[] {0, 1, 1, 1 },
                                                      new int[] {1, 1, 1, 1 },
                                                      new int[] {0, 1, 1, 1 } });
            Assert.AreEqual(15, answer);

            answer = CountSquares(new int[][] {   new int[] {1, 0, 1 },
                                                      new int[] {1, 1, 0 },
                                                      new int[] {1, 1, 0 } });
            Assert.AreEqual(7, answer);
        }

        public int CountSquares(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int[,] dp = new int[rows,cols];
            int total = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == 0) continue;
                    else
                    {
                        if (i == 0 || j == 0)
                        {
                            dp[i,j] = 1;
                        }
                        else
                        {
                            int up = dp[i - 1,j];
                            int left = dp[i,j - 1];
                            int diag = dp[i - 1,j - 1];
                            dp[i,j] = Math.Min(up, Math.Min(left, diag)) + 1;
                        }
                        total += dp[i,j];
                    }
                }
            }
            return total;

        }

        //public int CountSquares(int[][] matrix)
        //{
        //    int squareCount = 0;

        //    // Iterate over each square
        //    for (int y = 0; y < matrix.Length; y++)
        //    {
        //        for (int x = 0; x < matrix[0].Length; x++)
        //        {
        //            squareCount += GetExpandedSquares(matrix, x, y, 1);
        //        }
        //    }

        //    return squareCount;
        //}

        //public int GetExpandedSquares(int[][] matrix, int x, int y, int size)
        //{
        //    // Bounds check
        //    if (y + size > matrix.Length || x + size > matrix[0].Length)
        //        return 0;

        //    int count = 0;

        //    // On each expand, only need to check the bottom row
        //    // TODO: Find out some way to speed this up

        //    for (int i = x; i < x + size; i++)
        //    {
        //        if (matrix[y + size - 1][i] == 0)
        //        {
        //            return 0;
        //        }
        //    }

        //    // And the right column
        //    for (int i = y; i < y + size; i++)
        //    {
        //        if (matrix[i][x + size - 1] == 0)
        //        {
        //            return 0;
        //        }
        //    }

        //    // This square checks out
        //    count++;

        //    // Expand the squares

        //    count += GetExpandedSquares(matrix, x, y, size + 1);

        //    return count;
        //}
    }
}