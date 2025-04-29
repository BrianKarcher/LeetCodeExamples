using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.Union
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00684_RedundantConnection_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        // O(Nα(N))≈O(N), where NN is the number of vertices (and also the number of edges) in the graph, and α is the Inverse-Ackermann function
        public int[] FindRedundantConnection(int[][] edges)
        {
            DSU dsu = new DSU(10000);
            foreach (var edge in edges)
            {
                if (!dsu.Union(edge[0], edge[1]))
                {
                    return edge;
                }
            }
            return null;
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
}