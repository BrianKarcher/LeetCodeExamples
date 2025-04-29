using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an m x n matrix, return all elements of the matrix in spiral order.
    /// </summary>
    public class _00054_SpiralMatrix_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            // This is the boundary to keep within
            // The boundary will get smaller as we reach a boundary limit and change direction
            int firstRow = 0;
            int lastRow = matrix.Length - 1;
            int firstCol = 0;
            int lastCol = matrix[0].Length - 1;

            int col = 0;
            int row = 0;
            List<int> rtn = new List<int>();

            // directions are right, down, left, up, in that order for the spiral
            List<(int r, int c)> directions = new List<(int, int)> { (0, 1), (1, 0), (0, -1), (-1, 0) };

            // store the current direction
            int dir = 0;
            while (true)
            {
                rtn.Add(matrix[row][col]);

                int newRow = row + directions[dir].r;
                int newCol = col + directions[dir].c;
                // Check to see if the next cell, as pointed by the direction, is already visited or out of bounds
                if (newRow < firstRow || newRow > lastRow || newCol < firstCol || newCol > lastCol)
                {
                        // And if so, change the direction and recalculate the new row and new cell based
                        // on the new direction
                        dir++;
                    // Spiral directions loop like so
                    if (dir > 3)
                        dir = 0;
                    newRow = row + directions[dir].r;
                    newCol = col + directions[dir].c;

                    // Decide which boundary to shrink                    
                    if (dir == 0) // If new dir is right, then the left boundary shrinks
                        firstCol++;
                    else if (dir == 1) // If new dir is down, then the top boundary shrinks
                        firstRow++;
                    else if (dir == 2) // If new dir is left, then the right boundary shrinks
                        lastCol--;
                    else if (dir == 3) // If new dir is up, then the bottom boundary shrinks
                        lastRow--;

                    // Base case
                    // End of matrix check
                    // If any of the boundaries exceed each other, then the spiral is complete
                    if (firstCol > lastCol || firstRow > lastRow)
                        return rtn;
                }
                row = newRow;
                col = newCol;
            }
        }

        //public IList<int> SpiralOrder(int[][] matrix)
        //{
        //    int rowCount = matrix.Length;
        //    int colCount = matrix[0].Length;
        //    // This matrix defines the cells we have visited
        //    bool[,] visited = new bool[rowCount, colCount];

        //    int col = 0;
        //    int row = 0;
        //    List<int> rtn = new List<int>();

        //    // directions are right, down, left, up, in that order for the spiral
        //    List<(int r, int c)> directions = new List<(int, int)> { (0, 1), (1, 0), (0, -1), (-1, 0) };

        //    // store the current direction
        //    int dir = 0;
        //    while (true)
        //    {
        //        // Base case
        //        // End of matrix check
        //        if (row < 0 || row > rowCount - 1 || col < 0 || col > colCount - 1 || visited[row, col])
        //            return rtn;
        //        rtn.Add(matrix[row][col]);
        //        visited[row, col] = true;

        //        int newRow = row + directions[dir].r;
        //        int newCol = col + directions[dir].c;
        //        // Check to see if the next cell, as pointed by the direction, is already visited or out of bounds
        //        if (newRow < 0 || newRow > rowCount - 1 || newCol < 0 || newCol > colCount - 1 || visited[newRow, newCol])
        //        {
        //            // And if so, change the direction and recalculate the new row and new cell based
        //            // on the new direction
        //            dir++;
        //            // Spiral directions loop like so
        //            if (dir > 3)
        //                dir = 0;
        //            newRow = row + directions[dir].r;
        //            newCol = col + directions[dir].c;
        //        }
        //        row = newRow;
        //        col = newCol;
        //    }
        //}
    }
}