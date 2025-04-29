using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given an integer rowIndex, return the rowIndexth(0-indexed) row of the Pascal's triangle.
    // In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
    /// </summary>
    public class _00119_PascalTriangleIIDP_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        // LeetCode example
        // DP

        private Dictionary<(int Row, int Col), int> cache = new Dictionary<(int Row, int Col), int>();

        private int getNum2(int row, int col)
        {
            (int Row, int Col) rowCol = new (row, col);

            if (cache.ContainsKey(rowCol))
            {
                return cache[rowCol];
            }

            int computedVal =
                (row == 0 || col == 0 || row == col) ? 1 : getNum2(row - 1, col - 1) + getNum2(row - 1, col);

            cache.Add(rowCol, computedVal);

            return computedVal;
        }

        public List<int> getRow2(int rowIndex)
        {
            List<int> ans = new List<int>();

            for (int i = 0; i <= rowIndex; i++)
            {
                ans.Add(getNum2(rowIndex, i));
            }

            return ans;
        }
    }
}