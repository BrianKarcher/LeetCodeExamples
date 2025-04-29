using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
     //   Given a 2D array of characters grid of size m x n, you need to find if there exists any cycle consisting of the same value in grid.
     //   A cycle is a path of length 4 or more in the grid that starts and ends at the same cell.From a given cell, you can move to one of the cells adjacent to it - in one of the four directions (up, down, left, or right), if it has the same value of the current cell.
     //   Also, you cannot move to the cell that you visited in your last move.For example, the cycle (1, 1) -> (1, 2) -> (1, 1) is invalid because from(1, 2) we visited(1, 1) which was the last visited cell.
     //Return true if any cycle of the same value exists in grid, otherwise, return false.
    /// </summary>
    public class _001559_DetectCyclesIn2DGrid_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        DSU dsu;
        int rowCount = 0;
        int colCount = 0;
        char[][] _grid;
        public bool ContainsCycle(char[][] grid)
        {
            _grid = grid;
            rowCount = grid.Length;
            colCount = grid[0].Length;
            dsu = new DSU(rowCount * colCount);
            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    // Only create edges down and to the right as to avoid accidental loop-back
                    if (!AddUnion(r, c, r, c + 1))
                        return true;
                    if (!AddUnion(r, c, r + 1, c))
                        return true;
                }
            }
            return false;
        }

        public bool AddUnion(int r1, int c1, int r2, int c2)
        {
            // Out of bounds, assume the union was successful
            if (r1 < 0 || r1 > rowCount - 1 || c1 < 0 || c1 > colCount - 1)
                return true;
            if (r2 < 0 || r2 > rowCount - 1 || c2 < 0 || c2 > colCount - 1)
                return true;
            // No union if the characters don't match
            if (_grid[r1][c1] != _grid[r2][c2])
                return true;
            // Convert 2D grid coords into 1d array
            int cell1 = r1 * colCount + c1;
            int cell2 = r2 * colCount + c2;
            return dsu.Union(cell1, cell2);
        }

        public class DSU
        {
            int[] parent;
            int[] rank;

            public DSU(int size)
            {
                parent = new int[size];
                for (int i = 0; i < size; i++) parent[i] = i;
                rank = new int[size];
            }

            public int Find(int x)
            { // path compression
                if (parent[x] != x) parent[x] = Find(parent[x]);
                return parent[x];
            }

            public bool Union(int x, int y)
            {
                int xr = Find(x), yr = Find(y);
                if (xr == yr)
                {
                    return false;
                }
                else if (rank[xr] < rank[yr])
                {
                    parent[xr] = yr;
                }
                else if (rank[xr] > rank[yr])
                {
                    parent[yr] = xr;
                }
                else
                {
                    parent[yr] = xr;
                    rank[xr]++;
                }
                return true;
            }
        }
    }
}