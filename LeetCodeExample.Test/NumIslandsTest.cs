using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    public class NumIslandsTest
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

        // Ensure we don't check the same cell twice
        HashSet<(int row, int column)> visitedCell;
        // Instantiate the flood-fill queue here so we don't have to keep initializing new memory
        Queue<(int row, int column)> cellCheckQueue;

        int totalRowCount, totalColumnCount;


        public int NumIslands(char[][] grid)
        {
            int count = 0;

            totalRowCount = grid.Length;
            totalColumnCount = grid[0].Length;
            visitedCell = new HashSet<(int row, int column)>();
            cellCheckQueue = new Queue<(int row, int column)>();

            // Use a flood-fill algorithm

            for (int rowIndex = 0; rowIndex < grid.Length; rowIndex++)
            {
                char[] row = grid[rowIndex];
                for (int columnIndex = 0; columnIndex < row.Length; columnIndex++)
                {
                    int cell = row[columnIndex];
                    // Skip cell if we have already tabulated it
                    if (visitedCell.Contains((rowIndex, columnIndex)))
                        continue;
                    if (cell == '1')
                    {
                        count++;
                        cellCheckQueue.Clear();
                        // This function got too busy, putting the flood fill in another function
                        FloodFill(grid, rowIndex, columnIndex);
                    }
                    else
                    {
                        visitedCell.Add((rowIndex, columnIndex));
                    }
                }
            }
            return count;
        }

        public void FloodFill(char[][] grid, int row, int column)
        {
            // The actual flood-fill algorithm, search all nearby nodes for land (BFS), doing bounds checks

            cellCheckQueue.Enqueue((row, column));

            while (cellCheckQueue.Count != 0)
            {
                var cell = cellCheckQueue.Dequeue();

                // Breadth First Search
                // On Land cells we add the nearby cells to the queue.
                if (grid[cell.row][cell.column] == '1')
                {
                    // Left
                    QueueCellIfValid(cell.row, cell.column - 1);
                    // Right
                    QueueCellIfValid(cell.row, cell.column + 1);
                    // Top
                    QueueCellIfValid(cell.row - 1, cell.column);
                    // Bottom
                    QueueCellIfValid(cell.row + 1, cell.column);
                }

                // Regardless if the cell is land or water, since we visited it and checked it add it as a visited cell.
                visitedCell.Add(cell);
            }
        }

        public void QueueCellIfValid(int row, int column)
        {
            // We do the check before adding to ensure an O(n) operation
            // Bounds check
            if (row < 0 || row >= totalRowCount || column < 0 || column >= totalColumnCount)
                return;
            // Skip visited cells
            if (visitedCell.Contains((row, column)))
                return;

            cellCheckQueue.Enqueue((row, column));
        }
    }
}