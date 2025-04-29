using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You are given an empty 2D binary grid grid of size m x n.The grid represents a map where 0's represent water and 1's represent land.Initially, all the cells of grid are water cells (i.e., all the cells are 0's).

    //We may perform an add land operation which turns the water at position into a land. You are given an array positions where positions[i] = [ri, ci] is the position (ri, ci) at which we should operate the ith operation.
    //Return an array of integers answer where answer[i] is the number of islands after turning the cell (ri, ci) into a land.

    //An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
    /// </summary>
    public class _00305_NumberOfIslandsII_Test
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
        public IList<int> NumIslands2(int m, int n, int[][] positions)
        {
            rowCount = m;
            colCount = n;
            dsu = new DSU(rowCount * colCount);
            int[,] grid = new int[rowCount, colCount];
            List<int> rtn = new List<int>();
            List<(int r, int c)> directions = new List<(int, int)>() { (1, 0), (-1, 0), (0, 1), (0, -1) };
            HashSet<int> singleCellIsland = new HashSet<int>();
            for (int i = 0; i < positions.Length; i++)
            {
                int r = positions[i][0];
                int c = positions[i][1];
                int gridIndex = r * colCount + c;
                grid[r, c] = 1;
                // An island is being plotted here, create the union to all four adjacent islands if they are also "1"
                bool foundUnion = false;
                foreach (var dir in directions)
                {
                    int newR = r + dir.r;
                    int newC = c + dir.c;
                    // bounds check
                    if (newR < 0 || newR > rowCount - 1 || newC < 0 || newC > colCount - 1)
                        continue;
                    if (grid[newR, newC] == 0)
                        continue;
                    int gridIndex2 = newR * colCount + newC;
                    // If we found a union for a single cell island, it is no longer a single cell island!
                    if (singleCellIsland.Contains(gridIndex2))
                        singleCellIsland.Remove(gridIndex2);
                    dsu.Union(gridIndex, gridIndex2);
                    foundUnion = true;
                }
                // For single-size islands, add them to the SingleCellIsland hash
                if (!foundUnion)
                    singleCellIsland.Add(gridIndex);
                rtn.Add(dsu.islands.Count + singleCellIsland.Count);
            }
            return rtn;
        }

        public class DSU
        {
            public int[] parent;
            int[] rank;
            // hash keeps the id's of the parents for the islands that we will union
            // This provides the immediate O(1) response to the caller so they don't have to do an M*N lookup
            public HashSet<int> islands = new HashSet<int>();

            public DSU(int size)
            {
                parent = new int[size];
                for (int i = 0; i < size; i++) parent[i] = i;
                rank = new int[size];
            }

            public int Find(int x)
            {
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
                    RemoveIsland(xr);
                    AddIsland(yr);
                    parent[xr] = yr;
                }
                else if (rank[xr] > rank[yr])
                {
                    RemoveIsland(yr);
                    AddIsland(xr);
                    parent[yr] = xr;
                }
                else
                {
                    RemoveIsland(yr);
                    AddIsland(xr);
                    parent[yr] = xr;
                    rank[xr]++;
                }
                return true;
            }

            private void AddIsland(int i)
            {
                islands.Add(i);
            }

            private void RemoveIsland(int i)
            {
                if (islands.Contains(i))
                {

                    islands.Remove(i);
                }
            }
        }
    }
}