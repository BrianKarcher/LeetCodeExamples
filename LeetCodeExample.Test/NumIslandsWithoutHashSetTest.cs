using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    public class NumIslandsWithoutHashSetTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            double answer;
            char[][] grid;
            grid = new char[][] {
                 new char[] { '1', '1', '1', '1', '0' },
                 new char[] { '1','1','0','1','0' },
                 new char[] { '1','1','0','0','0' },
                 new char[] { '0','0','0','0','0' }
            };
            answer = NumIslands(grid);
            Assert.AreEqual(1, answer);
            grid = new char[][] {
                new char[]  {'1', '1', '0', '0', '0' },
                new char[]  {'1','1','0','0','0' },
                new char[]  {'0','0','1','0','0' },
                new char[]  {'0','0','0','1','1' }
            };
            answer = NumIslands(grid);
            Assert.AreEqual(3, answer);
        }

        // Instantiate the flood-fill queue here so we don't have to keep initializing new memory
        Queue<(int row, int column)> cellCheckQueue;

        int totalRowCount, totalColumnCount;


        public int NumIslands(char[][] grid)
        {
            int count = 0;

            totalRowCount = grid.Length;
            totalColumnCount = grid[0].Length;
            cellCheckQueue = new Queue<(int row, int column)>();

            // Use a flood-fill algorithm

            for (int rowIndex = 0; rowIndex < grid.Length; rowIndex++)
            {
                char[] row = grid[rowIndex];
                for (int columnIndex = 0; columnIndex < row.Length; columnIndex++)
                {
                    int cell = row[columnIndex];

                    if (cell == '1')
                    {
                        count++;
                        cellCheckQueue.Clear();
                        // This function got too busy, putting the flood fill in another function
                        FloodFill(grid, rowIndex, columnIndex);
                    }
                }
            }
            return count;
        }

        public void FloodFill(char[][] grid, int row, int column)
        {
            // The actual flood-fill algorithm, search all nearby nodes for land (BFS), doing bounds checks

            cellCheckQueue.Enqueue((row, column));

            while (cellCheckQueue.TryDequeue(out var cell))
            {
                // Breadth First Search
                // On Land cells we add the nearby cells to the queue.
                if (grid[cell.row][cell.column] == '1')
                {
                    // Left
                    QueueCellIfValid(grid, cell.row, cell.column - 1);
                    // Right
                    QueueCellIfValid(grid, cell.row, cell.column + 1);
                    // Top
                    QueueCellIfValid(grid, cell.row - 1, cell.column);
                    // Bottom
                    QueueCellIfValid(grid, cell.row + 1, cell.column);
                    // Convert the cell to water so it doesn't get checked again
                    grid[cell.row][cell.column] = '0';
                }
            }
        }

        public void QueueCellIfValid(char[][] grid, int row, int column)
        {
            // We do the check before adding to ensure an O(n) operation
            // Bounds check
            if (row < 0 || row >= totalRowCount || column < 0 || column >= totalColumnCount)
                return;
            // Skip water cells
            if (grid[row][column] == '0')
                return;

            cellCheckQueue.Enqueue((row, column));
        }
    }
}