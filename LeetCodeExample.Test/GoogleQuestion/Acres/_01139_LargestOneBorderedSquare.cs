using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //Given a 2D grid of 0s and 1s, return the number of elements in the largest square subgrid that has all 1s on its border, or 0 if such a subgrid doesn't exist in the grid.
    /// </summary>
    public class _01139_LargestOneBorderedSquare
    {
        public int largest1BorderedSquare(int[][] grid)
        {

            int m = grid.Length;
            int n = grid[0].Length;

            int[,] ver = new int[m,n];
            int[,] hor = new int[m,n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[j][i] == 1)
                    {
                        ver[j,i] = j == 0 ? ver[j,i] = 1 : ver[j - 1,i] + 1;
                    }
                    else
                    {
                        ver[j,i] = 0;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        hor[i,j] = j == 0 ? hor[i,j] = 1 : hor[i,j - 1] + 1;
                    }
                    else
                    {
                        hor[i,j] = 0;
                    }
                }
            }

            int max = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    bool found = false;
                    for (int len = Math.Min(ver[i,j], hor[i,j]); len > max && !found; len--)
                    {

                        if (ver[i,j + 1 - len] >= len && hor[i + 1 - len,j] >= len)
                        {
                            max = len;
                            found = true;
                        }
                    }
                }
            }

            return max * max;
        }

        public int Largest1BorderedSquare2(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            // Counts of how many 1's are in a certain direction of that cell
            int[,] left = new int[rows, cols];
            int[,] right = new int[rows, cols];
            int[,] up = new int[rows, cols];
            int[,] down = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == 0)
                        continue;

                    int count = 1;
                    // left count
                    for (int i = c - 1; i >= 0; i--)
                    {
                        if (grid[r][i] == 0)
                            break;
                        count++;
                    }
                    left[r, c] = count;

                    count = 1;
                    // right count
                    for (int i = c + 1; i < cols; i++)
                    {
                        if (grid[r][i] == 0)
                            break;
                        count++;
                    }
                    right[r, c] = count;

                    count = 1;
                    // up count
                    for (int i = r - 1; i >= 0; i--)
                    {
                        if (grid[i][c] == 0)
                            break;
                        count++;
                    }
                    up[r, c] = count;

                    count = 1;
                    // down count
                    for (int i = r + 1; i < rows; i++)
                    {
                        if (grid[i][c] == 0)
                            break;
                        count++;
                    }
                    down[r, c] = count;
                }
            }

            int maxSize = 0;
            // With the arrays populated we can now check for the largest square (hopefully)
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // Check the four directions from this cell
                    int cellSize = down[r, c];
                    for (int size = cellSize; size > 0; size--)
                    {
                        //Console.WriteLine($"Checking ({r},{c}), {size}");
                        if (size == 0)
                            continue;
                        // First check down and see if we can go right
                        if (r + size - 1 >= rows || right[r + size - 1, c] < size)
                            continue;
                        // Next check bottom right and see if we can go up
                        if (c + size - 1 >= cols || r + size - 1 >= rows || up[r + size - 1, c + size - 1] < size)
                            continue;
                        // Next check top right and see if we can go left
                        if (c + size - 1 < 0 || left[r, c + size - 1] < size)
                            continue;

                        maxSize = Math.Max(maxSize, size * size);
                        // This is the max it will ever be for this cell, exit the for
                        break;
                    }
                }
            }
            return maxSize;
        }
    }
}