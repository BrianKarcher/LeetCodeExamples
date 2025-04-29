using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an integer n, return the number of structurally unique BST's (binary search trees) which has exactly n nodes of unique values from 1 to n.
    /// </summary>
    public class _00096_UniqueBinarySearchTrees
    {
        public int[,] cache;
        public int NumTrees(int n)
        {
            cache = new int[n + 1, n + 1];
            return Trees(1, n);
        }

        int Trees(int lo, int hi)
        {
            if (lo >= hi) return 1;
            if (cache[lo, hi] != 0) return cache[lo, hi];
            int total = 0;
            for (int i = lo; i <= hi; i++)
                total += Trees(lo, i - 1) * Trees(i + 1, hi);
            cache[lo, hi] = total;
            return total;
        }
    }
}