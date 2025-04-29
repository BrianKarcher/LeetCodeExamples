using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExample.Test.Common.Union_Find
{
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