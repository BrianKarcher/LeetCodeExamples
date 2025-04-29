using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.
    //Note: You can only move either down or right at any point in time.
    /// </summary>
    public class _00064_MinimumPathSum
    {
        public int MinPathSum(int[][] grid)
        {
            int rowCount = grid.Length;
            int colCount = grid[0].Length;
            int[,] arr = new int[rowCount, colCount];
            arr[0, 0] = grid[0][0];
            // Can only move down or right, that means we can fill in the top and left row/column directly
            for (int c = 1; c < colCount; c++)
            {
                arr[0, c] = arr[0, c - 1] + grid[0][c];
            }
            for (int r = 1; r < rowCount; r++)
            {
                arr[r, 0] = arr[r - 1, 0] + grid[r][0];
            }
            for (int r = 1; r < rowCount; r++)
            {
                for (int c = 1; c < colCount; c++)
                {
                    var min = Math.Min(arr[r - 1, c], arr[r, c - 1]);
                    arr[r, c] = min + grid[r][c];
                }
            }
            return arr[rowCount - 1, colCount - 1];
        }

        /*Queue<(int r, int c)> queue;
        int colCount;
        int rowCount;
        int[][] _grid;
        int[,] arr;

        public int MinPathSum(int[][] grid) {
            _grid = grid;
            rowCount = grid.Length;
            colCount = grid[0].Length;
            arr = new int[rowCount, colCount];
            for (int r = 0; r < rowCount; r++) {
                for (int c = 0; c < colCount; c++) {
                    arr[r,c] = Int32.MaxValue;
                }
            }

            queue = new Queue<(int, int)>();
            queue.Enqueue((0, 0));
            arr[0,0] = grid[0][0];

            while (queue.Count != 0) {
                var cell = queue.Dequeue();
                CellCheck(cell.r - 1, cell.c, arr[cell.r, cell.c]);
                CellCheck(cell.r + 1, cell.c, arr[cell.r, cell.c]);
                CellCheck(cell.r, cell.c - 1, arr[cell.r, cell.c]);
                CellCheck(cell.r, cell.c + 1, arr[cell.r, cell.c]);
            }
            return arr[rowCount - 1, colCount - 1];
        }

        public void CellCheck(int r, int c, int adjValue) {
            // bounds check
            if (r < 0 || c < 0 || r > rowCount - 1 || c > colCount - 1)
                return;
            if (adjValue + _grid[r][c] < arr[r,c]) {
                arr[r,c] = adjValue + _grid[r][c];
                queue.Enqueue((r, c));
            }
        }*/
    }
}