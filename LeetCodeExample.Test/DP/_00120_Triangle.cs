using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given a triangle array, return the minimum path sum from top to bottom.

    //For each step, you may move to an adjacent number of the row below.More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.
    /// </summary>
    public class _00120_Triangle
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            return dp(triangle, 0, 0);
        }

        Dictionary<(int level, int i), int> map = new Dictionary<(int, int), int>();

        int dp(IList<IList<int>> triangle, int level, int i)
        {
            // base case
            if (level == triangle.Count - 1)
                return triangle[level][i];

            if (map.ContainsKey((level, i)))
                return map[(level, i)];

            int left = dp(triangle, level + 1, i);
            int right = dp(triangle, level + 1, i + 1);

            int min = Math.Min(left, right) + triangle[level][i];
            map.Add((level, i), min);

            return min;
        }
    }
}