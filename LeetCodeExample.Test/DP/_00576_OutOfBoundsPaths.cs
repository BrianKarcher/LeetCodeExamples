using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//There is an m x n grid with a ball.The ball is initially at the position [startRow, startColumn]. You are allowed to move the ball to one of the four adjacent cells in the grid (possibly out of the grid crossing the grid boundary). You can apply at most maxMove moves to the ball.

//Given the five integers m, n, maxMove, startRow, startColumn, return the number of paths to move the ball out of the grid boundary. Since the answer can be very large, return it modulo 109 + 7.
/// </summary>
public class _00576_OutOfBoundsPaths
{
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
    {
        int[,] grid = new int[m, n];
        grid[startRow, startColumn] = 1;
        int ans = 0;
        int modu = 1000000007;
        List<(int r, int c)> dirs = new List<(int, int)>() { (1, 0), (-1, 0), (0, 1), (0, -1) };
        for (int i = 0; i < maxMove; i++)
        {
            // So we don't mess up the previous moves.
            int[,] newGrid = new int[m, n];
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (grid[r, c] == 0)
                        continue;
                    // We have paths to move.
                    // Move all paths on this cell around in one large bucket to all
                    // possible directions.
                    foreach (var dir in dirs)
                    {
                        int newR = r + dir.r;
                        int newC = c + dir.c;
                        if (newR < 0 || newR > m - 1 || newC < 0 || newC > n - 1)
                        {
                            ans = (ans + grid[r, c]) % modu;
                            continue;
                        }
                        newGrid[newR, newC] = (newGrid[newR, newC] + grid[r, c]) % modu;
                    }
                }
            }
            grid = newGrid;
        }
        return ans;
    }
}