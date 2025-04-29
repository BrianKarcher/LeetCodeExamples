using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
        //    You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees(clockwise).
        //You have to rotate the image in-place, which means you have to modify the input 2D matrix directly.DO NOT allocate another 2D matrix and do the rotation.
    /// </summary>
    public class _00048_RotateImage_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        int[][] _matrix;

        public void Rotate(int[][] matrix)
        {
            // We can solve in constant space by swapping the top row (minus the top-right item)
            // first with the right column. Then swap the top row with the bottom row.
            // Then swap the top row with the left row.
            // Then shrink the boundaries and repeat until boundries cannot be shrunk anymore.

            int l = 0;
            int r = matrix[0].Length - 1;
            int u = 0;
            int d = matrix.Length - 1;
            _matrix = matrix;
            int size = matrix.Length - 1;

            while (l < r)
            {
                // Swap top row with right column.
                for (int i = 0; i < size; i++)
                {
                    Swap(u, l + i, u + i, r);
                }
                // Swap top row with bottom row (going right to left)
                for (int i = 0; i < size; i++)
                {
                    Swap(u, l + i, d, r - i);
                }
                // Swap top row with left column (going up).
                for (int i = 0; i < size; i++)
                {
                    Swap(u, l + i, d - i, l);
                }
                l++;
                r--;
                u++;
                d--;
                size -= 2;
            }
        }

        public void Swap(int r, int c, int r2, int c2)
        {
            int temp = _matrix[r][c];
            _matrix[r][c] = _matrix[r2][c2];
            _matrix[r2][c2] = temp;
        }
    }
}