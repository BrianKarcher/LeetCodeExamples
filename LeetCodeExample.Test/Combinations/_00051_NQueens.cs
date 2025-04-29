using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.
    // Given an integer n, return all distinct solutions to the n-queens puzzle. You may return the answer in any order.

    // Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space, respectively.
    /// </summary>
    public class _00051_NQueens
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            Recurse(n, 0, new List<IList<char>>());

            return finalBoards;
        }

        // Index = row, value = column
        IList<IList<string>> finalBoards = new List<IList<string>>(); // Queen's column position on each row, index = row

        void Recurse(int boardSize, int row, List<IList<char>> rows)
        {
            // Base case
            if (row == boardSize)
            {
                // Found a solution
                List<string> board = new List<string>();
                // Convert each row if chars into a string
                for (int i = 0; i < boardSize; i++)
                {
                    string r = new String(rows[i].ToArray());
                    board.Add(r);
                }
                finalBoards.Add(board);
                return;
            }

            // Find all possible queen positions on this row
            // Due to how queens work, only one queen can be placed on a row at a time
            // Same for columns (do a column check)
            // Also need to check for diagnols

            // Prepare column
            List<char> col = new List<char>();
            for (int i = 0; i < boardSize; i++)
                col.Add('.');
            rows.Add(col);

            // Check each column
            for (int newCol = 0; newCol < boardSize; newCol++)
            {
                // Check if a queen is possible in this column for this row

                bool abort = false;
                // Check if another queen is in this column
                for (int r = 0; r < rows.Count; r++)
                {
                    if (rows[r][newCol] == 'Q')
                    {
                        abort = true;
                    }
                }
                if (abort)
                    continue;

                // TODO : Check diagnols
                int diagSize = 1;
                for (int r = rows.Count - 2; r >= 0; r--)
                {
                    if (newCol - diagSize >= 0 && rows[r][newCol - diagSize] == 'Q')
                    {
                        abort = true;
                        break;
                    }
                    if (newCol + diagSize < boardSize && rows[r][newCol + diagSize] == 'Q')
                    {
                        abort = true;
                        break;
                    }
                    diagSize++;
                }
                if (abort)
                    continue;

                // This is a valid queen position, let's add it to cols, continue to the next row and test it
                col[newCol] = 'Q';

                Recurse(boardSize, row + 1, rows);

                // Backtrack
                col[newCol] = '.';
            }
            // Backtrack this row
            rows.RemoveAt(rows.Count - 1);
        }
    }
}