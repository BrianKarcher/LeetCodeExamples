using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    // There is an m x n rectangular island that borders both the Pacific Ocean and Atlantic Ocean.The Pacific Ocean touches the island's left and top edges, and the Atlantic Ocean touches the island's right and bottom edges.
    // The island is partitioned into a grid of square cells.You are given an m x n integer matrix heights where heights[r][c] represents the height above sea level of the cell at coordinate(r, c).
    // The island receives a lot of rain, and the rain water can flow to neighboring cells directly north, south, east, and west if the neighboring cell's height is less than or equal to the current cell's height.Water can flow from any cell adjacent to an ocean into the ocean.
    // Return a 2D list of grid coordinates result where result[i] = [ri, ci] denotes that rain water can flow from cell (ri, ci) to both the Pacific and Atlantic oceans.
    /// </summary>
    public class _00417_PacificAtlanticWaterFlow
    {
        bool[,] visited;
        int rows;
        int cols;
        List<(int r, int c)> dirs = new List<(int, int)>() { (-1, 0), (1, 0), (0, -1), (0, 1) };

        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            rows = heights.Length;
            cols = heights[0].Length;
            bool[,] flowsIntoPacific = new bool[rows, cols];
            bool[,] flowsIntoAtlantic = new bool[rows, cols];

            // Do two DFS's, one for the Pacific, the other for Atlantic
            // Pacific
            visited = new bool[rows, cols];

            // Left side
            for (int i = 0; i < rows; i++)
            {
                dfs(i, 0, flowsIntoPacific, heights);
            }
            // Top side
            for (int i = 0; i < cols; i++)
            {
                dfs(0, i, flowsIntoPacific, heights);
            }

            visited = new bool[rows, cols];
            // right side
            for (int i = 0; i < rows; i++)
            {
                dfs(i, cols - 1, flowsIntoAtlantic, heights);
            }
            // Bottom side
            for (int i = 0; i < cols; i++)
            {
                dfs(rows - 1, i, flowsIntoAtlantic, heights);
            }

            List<IList<int>> rtn = new List<IList<int>>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (flowsIntoPacific[r, c] && flowsIntoAtlantic[r, c])
                        rtn.Add(new List<int> { r, c });
                }
            }
            return rtn;
        }

        void dfs(int r, int c, bool[,] setter, int[][] heights)
        {
            setter[r, c] = true;
            visited[r, c] = true;
            // Check adjacent cells
            foreach (var dir in dirs)
            {
                if (CheckAndAdd(heights[r][c], r + dir.r, c + dir.c, heights))
                    dfs(r + dir.r, c + dir.c, setter, heights);
            }
        }

        bool CheckAndAdd(int prevValue, int nr, int nc, int[][] heights)
        {
            // Bounds check
            if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                return false;

            if (visited[nr, nc])
                return false;

            if (heights[nr][nc] < prevValue)
                return false;

            return true;
        }


        //bool[,] visited;
        //Queue<(int r, int c)> queue;
        //int rows;
        //int cols;

        //public IList<IList<int>> PacificAtlantic(int[][] heights)
        //{
        //    rows = heights.Length;
        //    cols = heights[0].Length;
        //    bool[,] flowsIntoPacific = new bool[rows, cols];
        //    bool[,] flowsIntoAtlantic = new bool[rows, cols];

        //    // Do two BFS's, one for the Pacific, the other for Atlantic
        //    // Pacific
        //    queue = new Queue<(int, int)>();
        //    //HashSet<(int r, int c)> visited = new HashSet<(int, int)>();
        //    visited = new bool[rows, cols];

        //    List<(int r, int c)> dirs = new List<(int, int)>() { (-1, 0), (1, 0), (0, -1), (0, 1) };

        //    // Left side
        //    for (int i = 0; i < rows; i++)
        //    {
        //        queue.Enqueue((i, 0));
        //    }
        //    // Top side
        //    for (int i = 0; i < cols; i++)
        //    {
        //        queue.Enqueue((0, i));
        //    }

        //    while (queue.Count != 0)
        //    {
        //        var item = queue.Dequeue();
        //        flowsIntoPacific[item.r, item.c] = true;
        //        visited[item.r, item.c] = true;
        //        // Check adjacent cells
        //        foreach (var dir in dirs)
        //        {
        //            CheckAndAdd(heights[item.r][item.c], item.r + dir.r, item.c + dir.c, heights);
        //        }
        //    }

        //    visited = new bool[rows, cols];
        //    // right side
        //    for (int i = 0; i < rows; i++)
        //    {
        //        queue.Enqueue((i, cols - 1));
        //    }
        //    // Bottom side
        //    for (int i = 0; i < cols; i++)
        //    {
        //        queue.Enqueue((rows - 1, i));
        //    }

        //    while (queue.Count != 0)
        //    {
        //        var item = queue.Dequeue();
        //        flowsIntoAtlantic[item.r, item.c] = true;
        //        visited[item.r, item.c] = true;
        //        // Check adjacent cells
        //        foreach (var dir in dirs)
        //        {
        //            CheckAndAdd(heights[item.r][item.c], item.r + dir.r, item.c + dir.c, heights);
        //        }
        //    }

        //    List<IList<int>> rtn = new List<IList<int>>();
        //    for (int r = 0; r < rows; r++)
        //    {
        //        for (int c = 0; c < cols; c++)
        //        {
        //            if (flowsIntoPacific[r, c] && flowsIntoAtlantic[r, c])
        //                rtn.Add(new List<int> { r, c });
        //        }
        //    }
        //    return rtn;
        //}

        //void CheckAndAdd(int prevValue, int nr, int nc, int[][] heights)
        //{
        //    // Bounds check
        //    if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
        //        return;

        //    if (visited[nr, nc])
        //        return;

        //    if (heights[nr][nc] < prevValue)
        //        return;

        //    visited[nr, nc] = true;
        //    queue.Enqueue((nr, nc));
        //}
    }
}