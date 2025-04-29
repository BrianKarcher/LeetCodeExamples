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

        /*int[,] prob;

        public double KnightProbability(int n, int k, int row, int column) {
            prob = new int[k, 2];
            dp(0, n, k, row, column);
            double rtn = 1;
            for (int i = 0; i < k; i++) {
                // Prevent divide by zero
                if (prob[i, 0] != 0)
                    rtn *= (double) prob[i,1] / (double)prob[i,0];
            }
            return rtn;
        }

        List<(int r, int c)> dirs = new List<(int, int)> {(-2, 1), (-1, 2), (1, 2), (2, 1), (2, -1), (1, -2), (-1, -2), (-2, -1)};

        void dp(int turn, int n, int k, int r, int c) {
            if (turn == k) {
                return;
            }

            foreach (var dir in dirs) {
                int nr = r + dir.r;
                int nc = c + dir.c;
                // Increment attempt
                prob[turn, 0]++;
                if (nr >= 0 && nc >= 0 && nr < n && nc < n) {
                    prob[turn, 1]++; // Increment "on board"
                    // Still on the board, do next move
                    dp(turn + 1, n, k, nr, nc);
                }
            }
        }*/
    }
}