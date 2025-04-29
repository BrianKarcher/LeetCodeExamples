using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    A robot is located at the top-left corner of a m x n grid(marked 'Start' in the diagram below).
    //The robot can only move either down or right at any point in time.The robot is trying to reach the bottom-right corner of the grid(marked 'Finish' in the diagram below).
    //Now consider if some obstacles are added to the grids.How many unique paths would there be?
    //An obstacle and space is marked as 1 and 0 respectively in the grid.
    /// </summary>
    public class _00063_UniquePathsII_Test
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int rowCount = obstacleGrid.Length;
            int colCount = obstacleGrid[0].Length;
            //if (rowCount == 1 && colCount == 1)
            //    return 0;

            if (obstacleGrid[0][0] == 1)
                obstacleGrid[0][0] = 0;
            else
                obstacleGrid[0][0] = 1;

            // Do left column
            for (int r = 1; r < rowCount; r++)
            {
                if (obstacleGrid[r][0] == 1) // an Obstacle
                    obstacleGrid[r][0] = 0;
                else
                    obstacleGrid[r][0] = obstacleGrid[r - 1][0]; // Will be either a 1 or 0, depending if it has crossed an obstacle
            }
            // Do top row
            for (int c = 1; c < colCount; c++)
            {
                if (obstacleGrid[0][c] == 1) // an Obstacle
                    obstacleGrid[0][c] = 0;
                else
                    obstacleGrid[0][c] = obstacleGrid[0][c - 1]; // Will be either a 1 or 0, depending if it has crossed an obstacle
            }

            // Do rest
            for (int r = 1; r < rowCount; r++)
            {
                for (int c = 1; c < colCount; c++)
                {
                    if (obstacleGrid[r][c] == 1)
                        obstacleGrid[r][c] = 0;
                    else
                        obstacleGrid[r][c] = obstacleGrid[r - 1][c] + obstacleGrid[r][c - 1];
                }
            }

            return obstacleGrid[rowCount - 1][colCount - 1];
        }
    }
}