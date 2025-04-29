using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an integer matrix isWater of size m x n that represents a map of land and water cells.

    //    If isWater[i][j] == 0, cell(i, j) is a land cell.
    //If isWater[i][j] == 1, cell(i, j) is a water cell.
    //You must assign each cell a height in a way that follows these rules:

    //The height of each cell must be non-negative.
    //If the cell is a water cell, its height must be 0.
    //Any two adjacent cells must have an absolute height difference of at most 1. A cell is adjacent to another cell if the former is directly north, east, south, or west of the latter(i.e., their sides are touching).
    //Find an assignment of heights such that the maximum height in the matrix is maximized.

    //Return an integer matrix height of size m x n where height[i][j] is cell(i, j)'s height. If there are multiple solutions, return any of them.
    /// </summary>
    public class _01765_MapOfHighestPeak
    {
        public int[][] HighestPeak(int[][] isWater)
        {
            int rowCount = isWater.Length;
            int colCount = isWater[0].Length;

            int[][] map = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                map[i] = new int[colCount];
            }

            Queue<(int r, int c)> queue = new Queue<(int, int)>();
            bool[,] visited = new bool[rowCount, colCount];

            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    if (isWater[r][c] == 1)
                    {
                        queue.Enqueue((r, c));
                        visited[r, c] = true;
                        //map[r][c] = 0;
                    }
                }
            }

            int height = 0;
            while (queue.Count != 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var cell = queue.Dequeue();
                    map[cell.r][cell.c] = height;
                    //Console.WriteLine($"Setting {cell.r},{cell.c} to {height}");
                    // Find cells to add to the queue
                    // Up
                    if (cell.r > 0 && !visited[cell.r - 1, cell.c])
                    {
                        visited[cell.r - 1, cell.c] = true;
                        queue.Enqueue((cell.r - 1, cell.c));
                    }
                    // Down
                    if (cell.r < rowCount - 1 && !visited[cell.r + 1, cell.c])
                    {
                        visited[cell.r + 1, cell.c] = true;
                        queue.Enqueue((cell.r + 1, cell.c));
                    }
                    // Left
                    if (cell.c > 0 && !visited[cell.r, cell.c - 1])
                    {
                        visited[cell.r, cell.c - 1] = true;
                        queue.Enqueue((cell.r, cell.c - 1));
                    }
                    // Right
                    if (cell.c < colCount - 1 && !visited[cell.r, cell.c + 1])
                    {
                        visited[cell.r, cell.c + 1] = true;
                        queue.Enqueue((cell.r, cell.c + 1));
                    }
                }
                height++;
            }
            return map;
        }
    }
}