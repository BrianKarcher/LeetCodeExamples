using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //There is an m x n grid, where(0, 0) is the top-left cell and(m - 1, n - 1) is the bottom-right cell.You are given an integer array startPos where startPos = [startrow, startcol] indicates that initially, a robot is at the cell (startrow, startcol). You are also given an integer array homePos where homePos = [homerow, homecol] indicates that its home is at the cell (homerow, homecol).

    //The robot needs to go to its home. It can move one cell in four directions: left, right, up, or down, and it can not move outside the boundary. Every move incurs some cost.You are further given two 0-indexed integer arrays: rowCosts of length m and colCosts of length n.

    //If the robot moves up or down into a cell whose row is r, then this move costs rowCosts[r].
    //If the robot moves left or right into a cell whose column is c, then this move costs colCosts[c].
    //Return the minimum total cost for this robot to return home.
    /// </summary>
    public class _02087_MinCostHomecomingGrid
    {
        public int MinCost(int[] startPos, int[] homePos, int[] rowCosts, int[] colCosts)
        {
            int x1 = startPos[1];
            int x2 = homePos[1];
            int y1 = startPos[0];
            int y2 = homePos[0];

            int xDir = x1 < x2 ? 1 : -1;
            int yDir = y1 < y2 ? 1 : -1;

            int cost = 0;
            for (int i = x1; i != x2; i += xDir)
            {
                cost += colCosts[i + xDir];
            }
            for (int i = y1; i != y2; i += yDir)
            {
                cost += rowCosts[i + yDir];
            }

            return cost;
        }

        public int MinCost2(int[] startPos, int[] homePos, int[] rowCosts, int[] colCosts)
        {
            int x1 = startPos[1];
            int x2 = homePos[1];
            int y1 = startPos[0];
            int y2 = homePos[0];

            // Horizontal cost
            int minX = Math.Min(x1, x2);
            int maxX = Math.Max(x1, x2);
            int minY = Math.Min(y1, y2);
            int maxY = Math.Max(y1, y2);

            int cost = 0;
            for (int i = minX; i <= maxX; i++)
            {
                Console.WriteLine($"x: {i}");
                cost += colCosts[i];
            }
            for (int i = minY; i <= maxY; i++)
            {
                Console.WriteLine($"y: {i}");
                cost += rowCosts[i];
            }
            // Subtract home position cost
            cost -= rowCosts[y1];
            cost -= colCosts[x1];
            return cost;
        }
    }
}