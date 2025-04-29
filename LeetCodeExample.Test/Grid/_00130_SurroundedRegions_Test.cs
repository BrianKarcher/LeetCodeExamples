using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given an m x n matrix board containing 'X' and 'O', capture all regions that are 4-directionally surrounded by 'X'.

    //A region is captured by flipping all 'O's into 'X's in that surrounded region.
    /// </summary>
    public class _00130_SurroundedRegions_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        //public class Solution
        //{
        //    protected Integer ROWS = 0;
        //    protected Integer COLS = 0;

        //    public void solve(char[][] board)
        //    {
        //        if (board == null || board.length == 0)
        //        {
        //            return;
        //        }
        //        this.ROWS = board.length;
        //        this.COLS = board[0].length;

        //        List<Pair<Integer, Integer>> borders = new LinkedList<Pair<Integer, Integer>>();
        //        // Step 1). construct the list of border cells
        //        for (int r = 0; r < this.ROWS; ++r)
        //        {
        //            borders.add(new Pair(r, 0));
        //            borders.add(new Pair(r, this.COLS - 1));
        //        }
        //        for (int c = 0; c < this.COLS; ++c)
        //        {
        //            borders.add(new Pair(0, c));
        //            borders.add(new Pair(this.ROWS - 1, c));
        //        }

        //        // Step 2). mark the escaped cells
        //        for (Pair<Integer, Integer> pair : borders)
        //        {
        //            this.BFS(board, pair.first, pair.second);
        //        }

        //        // Step 3). flip the cells to their correct final states
        //        for (int r = 0; r < this.ROWS; ++r)
        //        {
        //            for (int c = 0; c < this.COLS; ++c)
        //            {
        //                if (board[r][c] == 'O')
        //                    board[r][c] = 'X';
        //                if (board[r][c] == 'E')
        //                    board[r][c] = 'O';
        //            }
        //        }
        //    }

        //    protected void BFS(char[][] board, int r, int c)
        //    {
        //        LinkedList<(int, int)> queue = new LinkedList<(int, int)>();
        //        queue.AddLast((r, c));

        //        while (queue.Count != 0)
        //        {
        //            Pair<Integer, Integer> pair = queue.pollFirst();
        //            int row = pair.first, col = pair.second;
        //            if (board[row][col] != 'O')
        //                continue;

        //            board[row][col] = 'E';
        //            if (col < this.COLS - 1)
        //                queue.AddLast(new Pair<>(row, col + 1));
        //            if (row < this.ROWS - 1)
        //                queue.AddLast(new Pair<>(row + 1, col));
        //            if (col > 0)
        //                queue.AddLast(new Pair<>(row, col - 1));
        //            if (row > 0)
        //                queue.AddLast(new Pair<>(row - 1, col));
        //        }
        //    }
        //}


        class Pair<U, V>
        {
            public U first;
            public V second;

            public Pair(U first, V second)
            {
                this.first = first;
                this.second = second;
            }
        }

           int colCount;
        int rowCount;
        public void Solve(char[][] board)
        {
            rowCount = board.Length;
            colCount = board[0].Length;
            bool[,] visited = new bool[rowCount, colCount];
            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    if (visited[r, c])
                        continue;
                    visited[r, c] = true;
                    if (board[r][c] == 'O')
                    {
                        bfs(board, visited, r, c);
                    }
                }
            }
        }

        public void bfs(char[][] board, bool[,] visited, int r, int c)
        {
            // Use a queue to process, and a List to record, connected O's
            // Keep a flag if we have reached an edge. If we never reach an edge, convert all O's into X's in the list
            Queue<(int r, int c)> queue = new Queue<(int, int)>();
            List<(int r, int c)> lst = new List<(int, int)>();

            queue.Enqueue((r, c));
            lst.Add((r, c));
            List<(int r, int c)> directions = new List<(int, int)>() { (1, 0), (-1, 0), (0, 1), (0, -1) };
            bool hitEdge;
            if (r == 0 || c == 0 || r == rowCount - 1 || c == colCount - 1)
                hitEdge = true;
            else
                hitEdge = false;

            while (queue.Count != 0)
            {
                var item = queue.Dequeue();
                foreach (var dir in directions)
                {
                    int newR = item.r + dir.r;
                    int newC = item.c + dir.c;
                    // Bounds check
                    if (newR < 0 || newC < 0 || newR > rowCount - 1 || newC > colCount - 1)
                        continue;
                    // Must not have been visited
                    if (visited[newR, newC])
                        continue;
                    visited[newR, newC] = true;
                    // Must be an 'O'
                    if (board[newR][newC] != 'O')
                        continue;
                    // Did we hit an edge?
                    if (newR == 0 || newC == 0 || newR == rowCount - 1 || newC == colCount - 1)
                    {
                        hitEdge = true;
                    }
                    // All checks out, add it to the queue and the list
                    queue.Enqueue((newR, newC));
                    lst.Add((newR, newC));
                }
            }
            // Entire BFS is done. Let's check if the region isn't surrounded
            if (!hitEdge)
            {
                foreach (var item in lst)
                {
                    // Convert the found 'O's into 'X's
                    board[item.r][item.c] = 'X';
                }
            }
        }
    }
}