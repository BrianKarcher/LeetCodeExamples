using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //There are n people in a social group labeled from 0 to n - 1. You are given an array logs where logs[i] = [timestampi, xi, yi] indicates that xi and yi will be friends at the time timestampi.
    //Friendship is symmetric.That means if a is friends with b, then b is friends with a.Also, person a is acquainted with a person b if a is friends with b, or a is a friend of someone acquainted with b.
    //Return the earliest time for which every person became acquainted with every other person.If there is no such earliest time, return -1.
    /// </summary>
    public class _01101_EarliestMomentEveryoneFriends
    {
        public int EarliestAcq(int[][] logs, int n)
        {
            DSU dsu = new DSU(n);
            logs = logs.OrderBy(i => i[0]).ToArray();
            for (int i = 0; i < logs.Length; i++)
            {
                int[] log = logs[i];
                dsu.Union(log[1], log[2]);
                if (dsu.GetCount() == 1)
                {
                    return log[0];
                }
            }
            return -1;
        }

        public class DSU
        {
            int[] parent;
            int[] rank;
            int count;

            public DSU(int size)
            {
                parent = new int[size];
                for (int i = 0; i < size; i++) parent[i] = i;
                rank = new int[size];
                count = size;
                //Console.WriteLine($"{count}");
            }

            public int Find(int x)
            {
                // path compression
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
                count--;
                //Console.WriteLine($"{count}");
                return true;
            }

            public int GetCount() => count;
        }
    }
}