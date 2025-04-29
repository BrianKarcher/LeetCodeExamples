using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    On an n x n chessboard, a knight starts at the cell(row, column) and attempts to make exactly k moves.The rows and columns are 0-indexed, so the top-left cell is (0, 0), and the bottom-right cell is (n - 1, n - 1).

    //A chess knight has eight possible moves it can make, as illustrated below.Each move is two cells in a cardinal direction, then one cell in an orthogonal direction.
    /// </summary>
    public class _00688_KnightProbabilityInChessboard
    {
        List<(int r, int c)> dirs = new List<(int, int)> { (-2, 1), (-1, 2), (1, 2), (2, 1), (2, -1), (1, -2), (-1, -2), (-2, -1) };

        private double SolveDFS(double[,,] dp, int N, int K, int r, int c)
        {
            // if 0 moves then probablity is 1
            if (K == 0) return 1;
            if (dp[r, c, K] != 0) return dp[r, c, K];
            double ans = 0;
            for (int i = 0; i < 8; i++)
            {
                int nr = r + dirs[i].r;
                int nc = c + dirs[i].c;
                if (nr >= 0 && nc >= 0 && nr < N && nc < N)
                {
                    ans = ans + SolveDFS(dp, N, K - 1, nr, nc);
                }
            }
            ans = ans / 8;
            dp[r, c, K] = ans;
            return ans;
        }
        public double KnightProbability(int N, int K, int r, int c)
        {
            double[,,] dp = new double[N, N, K + 1];
            return SolveDFS(dp, N, K, r, c);
        }
    }
}