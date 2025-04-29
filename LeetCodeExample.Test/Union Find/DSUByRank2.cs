using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExample.Test.Union_Find2
{
    public class DSU
    {
        int[] parent;
        int[] rank;

        public DSU(int size)
        {
            parent = new int[size];
            //for (int i = 0; i < size; i++) parent[i] = i;
            Array.Fill(parent, -1);
            rank = new int[size];
            Array.Fill(rank, 0);
        }

        public bool IsValid(int i)
        {
            return parent[i] >= 0;
        }

        public void SetParent(int i)
        {
            parent[i] = i;
        }

        public int Find(int x)
        {
            if (parent[x] != x) parent[x] = Find(parent[x]);
            return parent[x];
        }

        public bool Union(int x, int y)
        {
            int rootx = Find(x), rooty = Find(y);
            if (rootx == rooty)
            {
                return false;
            }
            else if (rank[rootx] < rank[rooty])
            {
                parent[rootx] = rooty;
            }
            else if (rank[rootx] > rank[rooty])
            {
                parent[rooty] = rootx;
            }
            else
            {
                parent[rooty] = rootx;
                rank[rootx]++;
            }
            return true;
        }
    }
}