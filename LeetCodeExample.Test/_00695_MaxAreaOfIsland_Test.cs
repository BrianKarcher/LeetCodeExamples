using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You are given an m x n binary matrix grid.An island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.
    //The area of an island is the number of cells with a value 1 in the island.
    //Return the maximum area of an island in grid.If there is no island, return 0.
    /// </summary>
    public class _00695_MaxAreaOfIsland_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = MaxAreaOfIsland(new int[][] {  new int[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                                                        new int[] {0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                                                        new int[] {0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                        new int[] {0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 },
                                                        new int[] {0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 },
                                                        new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                                                        new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                                                        new int[] {0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 } });
            Assert.AreEqual(6, answer);

            answer = MaxAreaOfIsland(new int[][] {  new int[] { 0, 0, 0, 0, 0, 0, 0, 0 } });
            Assert.AreEqual(0, answer);
        }

        // Return the area of the largest island (connected 1's)
        public int MaxAreaOfIsland(int[][] grid)
        {
            int maxArea = 0;

            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    if (grid[row][col] == 1)
                    {
                        // Found an island, let's find the area!
                        // Perform a BFS to flood fill the island
                        int area = FindAreaOfIsland(grid, row, col);
                        maxArea = Math.Max(maxArea, area);
                    }
                }
            }
            return maxArea;
        }

        // BFS search to find the area of the island
        // delete the island as we go (turn 1's to 0's), so no land tile gets counted twice (memoization)
        public int FindAreaOfIsland(int[][] grid, int row, int col)
        {
            int gridHeight = grid.Length;
            int gridWidth = grid[0].Length;
            int area = 0;

            Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
            queue.Enqueue((row, col));
            while (queue.Any())
            {
                var cell = queue.Dequeue();
                // Bounds check
                if (cell.row < 0 || cell.row >= gridHeight || cell.col < 0 || cell.col >= gridWidth)
                    continue;

                // Skip water tiles
                if (grid[cell.row][cell.col] == 0)
                    continue;

                // This must be a land tile
                area++;

                // Turn the tile into water so it does not get counted again
                // This is an in-place memoization tactic
                grid[cell.row][cell.col] = 0;

                // Queue up 1 Right
                queue.Enqueue((cell.row, cell.col + 1));
                // Queue up 1 Left
                queue.Enqueue((cell.row, cell.col - 1));
                // Queue up 1 Up
                queue.Enqueue((cell.row - 1, cell.col));
                // Queue up 1 Down
                queue.Enqueue((cell.row + 1, cell.col));

            }
            return area;
        }
    }
}