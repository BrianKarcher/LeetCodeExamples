using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an m x n grid of characters board and a string word, return true if word exists in the grid.
    // The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.
    /// </summary>
    public class _00079_WordSearch_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            
        }

        int rowCount = 0;
        int colCount = 0;

        public bool Exist(char[][] board, string word)
        {
            if (word == null || word.Length == 0)
                return false;

            rowCount = board.Length;
            colCount = board[0].Length;
            bool[,] visited = new bool[rowCount, colCount];

            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    if (board[r][c] == word[0])
                    {
                        // Found a possible beginning letter, let's DFS it
                        bool isFound = dfs(board, word, r, c, 0, visited);
                        if (isFound)
                            return true;
                    }
                }
            }
            return false;
        }

        // List of possible directions to go
        List<(int r, int c)> directions = new List<(int, int)>() { (-1, 0), (1, 0), (0, -1), (0, 1) };

        public bool dfs(char[][] board, string word, int row, int col, int index, bool[,] visited)
        {
            if (index == word.Length - 1)
                return true;

            visited[row, col] = true;

            char nextChar = word[index + 1];

            // There are multiple paths we can go (or example if looking for 'A', and 'A'
            // is both to up and to the right, need to check both possibilities.
            foreach (var dir in directions)
            {
                int newRow = row + dir.r;
                int newCol = col + dir.c;
                if (InBounds(newRow, newCol) && board[newRow][newCol] == nextChar && !visited[newRow, newCol])
                {
                    if (dfs(board, word, newRow, newCol, index + 1, visited))
                        return true;
                }
            }

            // This route was invalid, need to set visited back to false (backtrack).
            visited[row, col] = false;
            return false;
        }

        public bool InBounds(int row, int col)
        {
            return row >= 0 && row < rowCount && col >= 0 && col < colCount;
        }
    }
}