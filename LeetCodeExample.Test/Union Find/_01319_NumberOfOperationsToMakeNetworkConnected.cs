using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace LeetCodeExample.Test;

/// <summary>
//Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
//You may assume that each input would have exactly one solution, and you may not use the same element twice.
//You can return the answer in any order.
/// </summary>
public class _01319_NumberOfOperationsToMakeNetworkConnected
{
    public int MakeConnected(int n, int[][] connections)
    {
        if (n > connections.Length + 1)
        {
            return -1;
        }
        UnionFind dsu = new(n);
        for (int i = 0; i < connections.Length; i++)
        {
            dsu.Union(connections[i][0], connections[i][1]);
        }
        return dsu.Count - 1;
    }

    public class UnionFind
    {
        private int[] rank;
        private int[] parent;

        private int count;
        public int Count => count;

        public UnionFind(int count)
        {
            this.count = count;
            rank = new int[count];
            parent = new int[count];
            for (int i = 0; i < rank.Length; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public void Union(int a, int b)
        {
            int ai = Find(a);
            int bi = Find(b);
            if (ai == bi)
                return;
            else if (rank[ai] < rank[bi])
            {
                parent[ai] = parent[bi];
            }
            else if (rank[bi] < rank[ai])
            {
                parent[bi] = parent[ai];
            }
            else
            {
                parent[ai] = parent[bi];
                rank[ai]++;
            }
            this.count--;
        }

        private int Find(int i)
        {
            if (parent[i] != i)
            {
                // flatten the graph to improve speed.
                parent[i] = Find(parent[i]);
            }
            return parent[i];
        }
    }
}