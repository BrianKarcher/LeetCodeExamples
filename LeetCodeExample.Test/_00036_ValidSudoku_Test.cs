using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
        //Determine if a 9 x 9 Sudoku board is valid.Only the filled cells need to be validated according to the following rules:

        //Each row must contain the digits 1-9 without repetition.
        //Each column must contain the digits 1-9 without repetition.
        //Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
        //Note:

        //A Sudoku board (partially filled) could be valid but is not necessarily solvable.
        //Only the filled cells need to be validated according to the mentioned rules.
    /// </summary>
    public class _00036_ValidSudoku_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        HashSet<char> vals = new HashSet<char>();
        char[][] _board;

        public bool IsValidSudoku(char[][] board)
        {
            _board = board;
            // First check each row for unique values
            for (int r = 0; r < board.Length; r++)
            {
                vals.Clear();
                for (int c = 0; c < board[0].Length; c++)
                {
                    if (!CheckValue(r, c))
                        return false;
                }
            }

            // Check each column for unique values
            for (int c = 0; c < board[0].Length; c++)
            {
                vals.Clear();
                for (int r = 0; r < board.Length; r++)
                {
                    if (!CheckValue(r, c))
                        return false;
                }
            }

            // Check each interior 3x3 grid
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    vals.Clear();

                    for (int r = i * 3; r < i * 3 + 3; r++)
                    {
                        for (int c = j * 3; c < j * 3 + 3; c++)
                        {
                            if (!CheckValue(r, c))
                                return false;
                        }
                    }
                }
            }

            return true;
        }

        public bool CheckValue(int r, int c)
        {
            if (_board[r][c] == '.')
                return true;

            if (vals.Contains(_board[r][c]))
                return false;

            vals.Add(_board[r][c]);

            return true;
        }
    }
}