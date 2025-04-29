using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an m x n grid where each cell can have one of three values:

    //0 representing an empty cell,
    //1 representing a fresh orange, or
    //2 representing a rotten orange.
    //Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.

    //Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.
    /// </summary>
    public class _00994_RottingOranges
    {
        public int OrangesRotting(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            //bool[,] visited = new bool[rows,cols];
            int mins = -1;
            Queue<(int r, int c)> queue = new Queue<(int, int)>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == 2)
                    {
                        queue.Enqueue((r, c));
                        grid[r][c] = 0;
                    }
                }
            }
            List<(int r, int c)> dirs = new List<(int, int)>() { (1, 0), (-1, 0), (0, 1), (0, -1) };
            while (queue.Count != 0)
            {
                int size = queue.Count;
                mins++;
                for (int i = 0; i < size; i++)
                {
                    var item = queue.Dequeue();
                    foreach (var dir in dirs)
                    {
                        int newc = item.c + dir.c;
                        int newr = item.r + dir.r;
                        if (newc < 0 || newr < 0 || newc >= cols || newr >= rows)
                            continue;
                        if (grid[newr][newc] != 1)
                            continue;
                        grid[newr][newc] = 0;
                        queue.Enqueue((newr, newc));
                    }
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        return -1;
                    }
                }
            }

            return Math.Max(0, mins);
        }
    }
}