using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given an m x n matrix grid where each cell is either a wall 'W', an enemy 'E' or empty '0', return the maximum enemies you can kill using one bomb.You can only place the bomb in an empty cell.

//The bomb kills all the enemies in the same row and column from the planted point until it hits the wall since it is too strong to be destroyed.
/// </summary>
public class _00361_BombEnemy
{
    int[,] ans;
    public int MaxKilledEnemies(char[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        ans = new int[m, n];

        int[] prevColumn = new int[m];
        // From left
        //Console.WriteLine($"From left");
        for (int c = 0; c < n; c++)
        {
            for (int r = 0; r < m; r++)
            {
                prevColumn[r] = Process(grid, c, r, prevColumn[r]);
            }
        }

        prevColumn = new int[m];
        // From right
        //Console.WriteLine($"From right");
        for (int c = n - 1; c >= 0; c--)
        {
            for (int r = 0; r < m; r++)
            {
                prevColumn[r] = Process(grid, c, r, prevColumn[r]);
            }
        }

        int[] prevRow = new int[n];
        // From top
        //Console.WriteLine($"From top");
        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                prevRow[c] = Process(grid, c, r, prevRow[c]);
            }
        }

        int max = 0;
        prevRow = new int[n];
        // From bottom
        //Console.WriteLine($"From bottom");
        for (int r = m - 1; r >= 0; r--)
        {
            for (int c = 0; c < n; c++)
            {
                prevRow[c] = Process(grid, c, r, prevRow[c]);
                if (grid[r][c] == '0')
                {
                    max = Math.Max(max, ans[r, c]);
                }
            }
        }
        return max;
    }

    int Process(char[][] grid, int c, int r, int prev)
    {
        //Console.WriteLine($"Checking cell {c},{r}");
        // If a 0, add the enemies encountered up to this point
        if (grid[r][c] == '0')
        {
            ans[r, c] += prev;
            return prev;
        }
        else if (grid[r][c] == 'E')
        {
            return prev + 1;
        }
        else if (grid[r][c] == 'W')
        {
            return 0;
        }
        return prev;
    }
}