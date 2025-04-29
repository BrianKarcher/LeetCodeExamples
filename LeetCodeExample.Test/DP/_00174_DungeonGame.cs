using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    The demons had captured the princess and imprisoned her in the bottom-right corner of a dungeon.The dungeon consists of m x n rooms laid out in a 2D grid.Our valiant knight was initially positioned in the top-left room and must fight his way through dungeon to rescue the princess.
    //  The knight has an initial health point represented by a positive integer.If at any point his health point drops to 0 or below, he dies immediately.
    //  Some of the rooms are guarded by demons (represented by negative integers), so the knight loses health upon entering these rooms; other rooms are either empty(represented as 0) or contain magic orbs that increase the knight's health (represented by positive integers).
    //To reach the princess as quickly as possible, the knight decides to move only rightward or downward in each step.
    //Return the knight's minimum initial health so that he can rescue the princess.
    //Note that any room can contain threats or power-ups, even the first room the knight enters and the bottom-right room where the princess is imprisoned.
    /// </summary>
    public class _00174_DungeonGame
    {
        public int CalculateMinimumHP(int[][] dungeon)
        {
            int rowCount = dungeon.Length;
            int colCount = dungeon[0].Length;

            int[,] dp = new int[rowCount, colCount];

            dp[rowCount - 1, colCount - 1] = Math.Max(1, 1 - dungeon[rowCount - 1][colCount - 1]);

            for (int r = rowCount - 1; r >= 0; r--)
            {
                for (int c = colCount - 1; c >= 0; c--)
                {
                    // We already calculated the bottom right cell
                    if (r == rowCount - 1 && c == colCount - 1)
                        continue;
                    int right = CalculateMin(r, c, r, c + 1, dp, dungeon);
                    int down = CalculateMin(r, c, r + 1, c, dp, dungeon);
                    dp[r, c] = Math.Min(right, down);
                }
            }
            return dp[0, 0];
        }

        int CalculateMin(int cr, int cc, int nr, int nc, int[,] dp, int[][] dungeon)
        {
            if (nr > dungeon.Length - 1 || nc > dungeon[0].Length - 1)
                return Int32.MaxValue;

            return Math.Max(1, dp[nr, nc] - dungeon[cr][cc]);
        }
    }
}