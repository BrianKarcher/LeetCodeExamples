using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // There is a city composed of n x n blocks, where each block contains a single building shaped like a vertical square prism.You are given a 0-indexed n x n integer matrix grid where grid[r][c] represents the height of the building located in the block at row r and column c.
    // A city's skyline is the the outer contour formed by all the building when viewing the side of the city from a distance. The skyline from each cardinal direction north, east, south, and west may be different.
    // We are allowed to increase the height of any number of buildings by any amount (the amount can be different per building). The height of a 0-height building can also be increased.However, increasing the height of a building should not affect the city's skyline from any cardinal direction.
    // Return the maximum total sum that the height of the buildings can be increased by without changing the city's skyline from any cardinal direction.
    /// </summary>
    public class _00807_MaxIncreaseCitySkyline
    {
        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int size = grid.Length;
            int[] south = new int[size];
            int[] east = new int[size];

            // south
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    south[c] = Math.Max(south[c], grid[r][c]);
                }
            }

            // east
            for (int c = 0; c < size; c++)
            {
                for (int r = 0; r < size; r++)
                {
                    east[r] = Math.Max(east[r], grid[r][c]);
                }
            }

            int rtn = 0;
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    int cellHeight = Math.Min(south[c], east[r]);
                    if (grid[r][c] < cellHeight)
                    {
                        rtn += cellHeight - grid[r][c];
                        //Console.Write($"{cellHeight}");
                    }
                }
                //Console.WriteLine();
            }

            return rtn;
        }
    }
}