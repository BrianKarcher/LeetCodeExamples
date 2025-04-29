using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
     //   Given a 2D array of characters grid of size m x n, you need to find if there exists any cycle consisting of the same value in grid.
     //   A cycle is a path of length 4 or more in the grid that starts and ends at the same cell.From a given cell, you can move to one of the cells adjacent to it - in one of the four directions (up, down, left, or right), if it has the same value of the current cell.
     //   Also, you cannot move to the cell that you visited in your last move.For example, the cycle (1, 1) -> (1, 2) -> (1, 1) is invalid because from(1, 2) we visited(1, 1) which was the last visited cell.
     //Return true if any cycle of the same value exists in grid, otherwise, return false.
    /// </summary>
    public class _01559_CycleCheck_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public bool ContainsCycle(char[][] grid)
        {
            bool[,] visited = new bool[grid.Length, grid[0].Length];

            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[0].Length; c++)
                {
                    if (!visited[r, c])
                    {
                        if (CycleCheck(grid[r][c], grid, visited, c, r, -1, -1))
                            return true;
                    }
                }
            }
            return false;
        }

        // Grids are undirectional, so remember the parent so we don't automatically loop back right away
        // Do a DFS
        public bool CycleCheck(char ch, char[][] grid, bool[,] visited, int x, int y, int parentX, int parentY)
        {

            // The four directions we can move
            List<(int r, int c)> directions = new List<(int, int)> { (-1, 0), (1, 0), (0, 1), (0, -1) };

            foreach (var dir in directions)
            {
                int newX = x + dir.c;
                int newY = y + dir.r;

                // Bounds check
                if (newX < 0 || newY < 0 || newX > grid[0].Length - 1 || newY > grid.Length - 1)
                    continue;

                // Needs to be the same character
                if (grid[newY][newX] != ch)
                    continue;
                // Prevent loop-back
                if (newX == parentX && newY == parentY)
                    continue;

                if (visited[newY, newX])
                    return true;

                visited[newY, newX] = true;

                if (CycleCheck(ch, grid, visited, newX, newY, x, y))
                    return true;
            }

            return false;
        }
    }
}