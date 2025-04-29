using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given an integer rowIndex, return the rowIndexth(0-indexed) row of the Pascal's triangle.
    // In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
    /// </summary>
    public class _00119_PascalTriangleII_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public IList<int> GetRow(int rowIndex)
        {
            return Recurse(0, rowIndex, new List<int>());
        }

        IList<int> Recurse(int currentIndex, int rowIndex, List<int> lst)
        {
            List<int> newList = new List<int>();

            newList.Add(1);
            if (currentIndex > 0)
            {
                for (int i = 0; i < lst.Count - 1; i++)
                {
                    newList.Add(lst[i] + lst[i + 1]);
                }
                newList.Add(1);
            }

            if (currentIndex == rowIndex)
                return newList;

            return Recurse(currentIndex + 1, rowIndex, newList);
        }

        // Leetcode example #1:
        // Recursion
        // Logic: In Pascal's triangle, each number is the sum of the two numbers directly above it.
        // https://leetcode.com/problems/pascals-triangle-ii/solution/
        private int getNum(int row, int col)
        {
            if (row == 0 || col == 0 || row == col)
            {
                return 1;
            }

            return getNum(row - 1, col - 1) + getNum(row - 1, col);
        }

        public List<int> getRow(int rowIndex)
        {
            List<int> ans = new List<int>();

            for (int i = 0; i <= rowIndex; i++)
            {
                ans.Add(getNum(rowIndex, i));
            }

            return ans;
        }
    }
}