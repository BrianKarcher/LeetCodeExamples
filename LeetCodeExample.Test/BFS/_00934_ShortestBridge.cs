using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You are given an n x n binary matrix grid where 1 represents land and 0 represents water.
    //An island is a 4-directionally connected group of 1's not connected to any other 1's.There are exactly two islands in grid.
    //You may change 0's to 1's to connect the two islands to form one island.

    //Return the smallest number of 0's you must flip to connect the two islands.
    /// </summary>
    public class _00934_ShortestBridge
    {
        public int ShortestBridge(int[][] grid)
        {
            Queue<(int x, int y)> islandQueue = new Queue<(int x, int y)>();

            // Find and extract the first island
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    if (grid[row][col] == 1)
                    {
                        ExtractIsland(grid, col, row, islandQueue);
                        break;
                    }
                }
                if (islandQueue.Count != 0)
                {
                    break;
                }
            }

            List<(int r, int c)> dirs = new List<(int, int)> { (-1, 0), (1, 0), (0, 1), (0, -1) };
            // Expand the bridges until we hit the next island.
            // BFS
            int size = 0;
            while (islandQueue.Count != 0)
            {
                int count = islandQueue.Count;
                for (int i = 0; i < count; i++)
                {
                    (int x, int y) = islandQueue.Dequeue();
                    foreach (var dir in dirs)
                    {
                        int newX = x + dir.c;
                        int newY = y + dir.r;
                        //Console.WriteLine($"Checking {newX}, {newY}, size {size}");
                        // Bounds check
                        if (newX < 0 || newY < 0 || newY > grid.Length - 1 || newX > grid[0].Length - 1)
                        {
                            continue;
                        }
                        if (grid[newY][newX] == 1)
                        {
                            //Console.WriteLine($"Found land at {newX}, {newY}, size {size}");
                            return size;
                        }
                        else if (grid[newY][newX] == 0)
                        {
                            grid[newY][newX] = -1;
                            //Console.WriteLine($"Bridge Queueing {newX}, {newY}, size {size}");
                            islandQueue.Enqueue((newX, newY));
                        }
                    }
                }
                size++;
            }
            return size;
        }

        // Expand the island. Delete the island as we go and mark as visited.
        void ExtractIsland(int[][] grid, int x, int y, Queue<(int x, int y)> q)
        {
            if (x < 0 || y < 0 || y >= grid.Length || x >= grid[0].Length || grid[y][x] != 1)
            {
                return;
            }
            // mark visited
            grid[y][x] = -1;
            q.Enqueue((x, y));
            ExtractIsland(grid, x - 1, y, q);
            ExtractIsland(grid, x, y - 1, q);
            ExtractIsland(grid, x + 1, y, q);
            ExtractIsland(grid, x, y + 1, q);
        }
    }
}