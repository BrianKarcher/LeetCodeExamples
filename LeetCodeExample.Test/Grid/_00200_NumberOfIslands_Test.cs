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
    public class _00200_NumberOfIslands_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public int NumIslands(char[][] grid)
        {
            int count = 0;
            // Loop through each cell
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[0].Length; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        // Found land
                        count++;
                        // Erase the island from the grid
                        EraseIsland(r, c, grid);
                    }
                }
            }
            return count;
        }

        // Perform a DFS to erase the island
        public void EraseIsland(int r, int c, char[][] grid)
        {
            grid[r][c] = '0';
            // up
            if (r > 0 && grid[r - 1][c] == '1')
                EraseIsland(r - 1, c, grid);
            // down
            if (r < grid.Length - 1 && grid[r + 1][c] == '1')
                EraseIsland(r + 1, c, grid);
            // left
            if (c > 0 && grid[r][c - 1] == '1')
                EraseIsland(r, c - 1, grid);
            // right
            if (c < grid[0].Length - 1 && grid[r][c + 1] == '1')
                EraseIsland(r, c + 1, grid);
        }
    }
}