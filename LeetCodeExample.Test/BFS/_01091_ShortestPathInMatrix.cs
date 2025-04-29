using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given an n x n binary matrix grid, return the length of the shortest clear path in the matrix.If there is no clear path, return -1.

    //    A clear path in a binary matrix is a path from the top-left cell (i.e., (0, 0)) to the bottom-right cell(i.e., (n - 1, n - 1)) such that:

    //All the visited cells of the path are 0.
    //All the adjacent cells of the path are 8-directionally connected(i.e., they are different and they share an edge or a corner).
    //The length of a clear path is the number of visited cells of this path.
    /// </summary>
    public class _01091_ShortestPathInMatrix
    {
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            if (grid[0][0] == 1)
                return -1;

            int size = grid.Length;
            bool[,] visited = new bool[size, size];

            // Do a BFS
            Queue<(int r, int c)> queue = new Queue<(int, int)>();
            queue.Enqueue((0, 0));
            visited[0, 0] = true;

            int dist = 0;
            // 8-directional
            List<(int r, int c)> dirs = new List<(int, int)> { (-1, 0), (1, 0), (0, -1), (0, 1), (-1, -1), (-1, 1), (1, -1), (1, 1) };
            while (queue.Count != 0)
            {
                dist++;
                int queueSize = queue.Count;
                for (int i = 0; i < queueSize; i++)
                {
                    var cell = queue.Dequeue();
                    if (cell.r == size - 1 && cell.c == size - 1)
                        return dist;

                    foreach (var dir in dirs)
                    {
                        int newr = cell.r + dir.r;
                        int newc = cell.c + dir.c;
                        if (newr < 0 || newc < 0 || newr > size - 1 || newc > size - 1)
                            continue;
                        if (grid[newr][newc] == 1)
                            continue;
                        if (visited[newr, newc])
                            continue;
                        visited[newr, newc] = true;
                        queue.Enqueue((newr, newc));
                    }
                }
            }
            return -1;
        }
    }
}