using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // You are given an m x n integer matrix grid where each cell is either 0 (empty) or 1 (obstacle). You can move up, down, left, or right from and to an empty cell in one step.
    // Return the minimum number of steps to walk from the upper left corner (0, 0) to the lower right corner(m - 1, n - 1) given that you can eliminate at most k obstacles.If it is not possible to find such walk return -1.
    /// </summary>
    public class _01293_GridShortestPathObstElim_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = ShortestPath(new int[][] { new int[] { 0, 0, 0 }, new int[] { 1, 1, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 }, new int[] { 0, 0, 0 } }, 1);
            Assert.AreEqual(6, answer);

            answer = ShortestPath(new int[][] { new int[] { 0, 1, 1 }, new int[] { 1, 1, 1 }, new int[] { 1, 0, 0 } }, 1);
            Assert.AreEqual(-1, answer);

            answer = ShortestPath(new int[][] { new int[] { 0, 1, 1 }, new int[] { 1, 1, 1 }, new int[] { 1, 0, 0 } }, 2);
            Assert.AreEqual(4, answer);


            answer = ShortestPath(new int[][] { new int[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1 }, new int[] { 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1 }, new int[] { 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0 }, new int[] { 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1 }, new int[] { 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1 }, new int[] { 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1 }, new int[] { 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1 }, new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0 }, new int[] { 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0 }, new int[] { 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0 }, new int[] { 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 0 } }, 27);
            Assert.AreEqual(24, answer);
            
        }

        public int ShortestPath(int[][] grid, int k)
        {
            var size = DoShortestPath(grid, k);
            return size;
        }

        //public int DoShortestPath(int[][] grid, int k)
        //{
        //    // Do a BFS to find the shortest path in the grid.
        //    int size = 0;
        //    Queue<(int row, int col, int r)> q = new Queue<(int, int, int)>();
        //    HashSet<(int row, int col, int r)> visited = new HashSet<(int, int, int)>();

        //    q.Enqueue((0, 0, k));
        //    while (q.Count != 0)
        //    {
        //        int queueSize = q.Count;
        //        // Go out one breadth
        //        for (int i = 0; i < queueSize; i++)
        //        {
        //            var cell = q.Dequeue();
        //            if (cell.col == grid[0].Length - 1 && cell.row == grid.Length - 1)
        //                return size;
        //            // left
        //            AddPos(cell.row, cell.col - 1, grid, q, visited, cell.r);
        //            // right
        //            AddPos(cell.row, cell.col + 1, grid, q, visited, cell.r);
        //            // up
        //            AddPos(cell.row - 1, cell.col, grid, q, visited, cell.r);
        //            // down
        //            AddPos(cell.row + 1, cell.col, grid, q, visited, cell.r);
        //        }
        //        size++;
        //    }
        //    return -1;
        //}

        //void AddPos(int row, int col, int[][] grid, Queue<(int row, int col, int r)> q, HashSet<(int row, int col, int r)> visited, int k)
        //{
        //    if (row < 0 || col < 0 || row > grid.Length - 1 || col > grid[0].Length - 1)
        //        return;

        //    if (visited.Contains((row, col, k)))
        //        return;

        //    if (grid[row][col] == 1 && k == 0)
        //        return;

        //    if (grid[row][col] == 1)
        //        k--;

        //    visited.Add((row, col, k));
        //    q.Enqueue((row, col, k));
        //}

        //public int DoShortestPath(int[][] grid, int k)
        //{
        //    // Do a BFS to find the shortest path in the grid.
        //    int size = 0;
        //    Queue<(int row, int col, int r)> q = new Queue<(int, int, int)>();
        //    HashSet<(int row, int col)> visited = new HashSet<(int, int)>();

        //    q.Enqueue((0, 0, k));
        //    while (q.Count != 0)
        //    {
        //        int queueSize = q.Count;
        //        // Go out one breadth
        //        for (int i = 0; i < queueSize; i++)
        //        {
        //            var cell = q.Dequeue();
        //            if (cell.col == grid[0].Length - 1 && cell.row == grid.Length - 1)
        //                return size;
        //            // left
        //            AddPos(cell.row, cell.col - 1, grid, q, visited, cell.r);
        //            // right
        //            AddPos(cell.row, cell.col + 1, grid, q, visited, cell.r);
        //            // up
        //            AddPos(cell.row - 1, cell.col, grid, q, visited, cell.r);
        //            // down
        //            AddPos(cell.row + 1, cell.col, grid, q, visited, cell.r);
        //        }
        //        size++;
        //    }
        //    return -1;
        //}

        //void AddPos(int row, int col, int[][] grid, Queue<(int row, int col, int r)> q, HashSet<(int row, int col)> visited, int k)
        //{
        //    if (row < 0 || col < 0 || row > grid.Length - 1 || col > grid[0].Length - 1)
        //        return;

        //    if (visited.Contains((row, col)))
        //        return;

        //    if (grid[row][col] == 1 && k == 0)
        //        return;

        //    if (grid[row][col] == 1)
        //        k--;

        //    visited.Add((row, col));
        //    q.Enqueue((row, col, k));
        //}

        public int DoShortestPath(int[][] grid, int k)
        {
            // Do a BFS to find the shortest path in the grid.
            int size = 0;
            Queue<(int row, int col, int r)> q = new Queue<(int, int, int)>();
            // The visited graph will store the number of k's remaining.
            int[][] visited = new int[grid.Length][];
            for (int j = 0; j < grid.Length; j++)
            {
                visited[j] = new int[grid[0].Length];
                for (int l = 0; l < grid[0].Length; l++)
                {
                    visited[j][l] = Int32.MinValue;
                }
            }

            //HashSet<(int row, int col)> visited = new HashSet<(int, int)>();

            q.Enqueue((0, 0, k));
            while (q.Count != 0)
            {
                int queueSize = q.Count;
                // Go out one breadth
                for (int i = 0; i < queueSize; i++)
                {
                    var cell = q.Dequeue();
                    if (cell.col == grid[0].Length - 1 && cell.row == grid.Length - 1)
                        return size;
                    // left
                    AddPos(cell.row, cell.col - 1, grid, q, visited, cell.r);
                    // right
                    AddPos(cell.row, cell.col + 1, grid, q, visited, cell.r);
                    // up
                    AddPos(cell.row - 1, cell.col, grid, q, visited, cell.r);
                    // down
                    AddPos(cell.row + 1, cell.col, grid, q, visited, cell.r);
                }
                size++;
            }
            return -1;
        }

        void AddPos(int row, int col, int[][] grid, Queue<(int row, int col, int r)> q, int[][] visited, int k)
        {
            if (row < 0 || col < 0 || row > grid.Length - 1 || col > grid[0].Length - 1)
                return;

            //if (visited[row][col])
            //    return;

            if (grid[row][col] == 1)
            {
                k--;
                if (k < 0)
                    return;                
            }

            // We've been here with the same or more obstacles remaining? Skip it.
            if (visited[row][col] >= k)
                return;

            visited[row][col] = Math.Max(visited[row][col], k);

            //visited.Add((row, col));
            q.Enqueue((row, col, k));
        }
    }
}