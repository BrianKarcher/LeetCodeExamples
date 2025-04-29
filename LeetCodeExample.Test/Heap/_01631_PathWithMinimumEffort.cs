using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You are a hiker preparing for an upcoming hike.You are given heights, a 2D array of size rows x columns, where heights[row][col] represents the height of cell(row, col). You are situated in the top-left cell, (0, 0), and you hope to travel to the bottom-right cell, (rows - 1, columns - 1) (i.e., 0-indexed). You can move up, down, left, or right, and you wish to find a route that requires the minimum effort.
    //  A route's effort is the maximum absolute difference in heights between two consecutive cells of the route.

    //  Return the minimum effort required to travel from the top-left cell to the bottom-right cell.
    /// </summary>
    public class _01631_PathWithMinimumEffort
    {
        public int MinimumEffortPath(int[][] heights)
        {
            int rows = heights.Length;
            int cols = heights[0].Length;
            //int[,] effort = new int[rows,cols];
            // The priority queue ensures that we will always enter a cell with the minimum 
            // effort, so no need to ever revisit a cell
            bool[,] visited = new bool[rows, cols];
            PriorityQueue<(int effort, int r, int c)> pq = new PriorityQueue<(int, int, int)>();
            pq.Enqueue((0, 0, 0));
            List<(int r, int c)> dirs = new List<(int, int)>() { (1, 0), (-1, 0), (0, 1), (0, -1) };
            while (pq.Count() != 0)
            {
                var cell = pq.Dequeue();
                //Console.WriteLine($"{cell.r}, {cell.c}, {cell.effort}");
                if (cell.r == rows - 1 && cell.c == cols - 1)
                    return cell.effort;
                if (visited[cell.r, cell.c])
                    continue;
                visited[cell.r, cell.c] = true;
                foreach (var dir in dirs)
                {
                    int newr = cell.r + dir.r;
                    int newc = cell.c + dir.c;
                    if (newr < 0 || newc < 0 || newr > rows - 1 || newc > cols - 1)
                        continue;
                    var newEffort = Math.Abs(heights[cell.r][cell.c] - heights[newr][newc]);
                    var maxEffort = Math.Max(cell.effort, newEffort);
                    pq.Enqueue((maxEffort, newr, newc));
                    //Console.WriteLine($"Queueing up {newr} {newc} {maxEffort}");
                }
            }
            return 0;
        }
    }
}