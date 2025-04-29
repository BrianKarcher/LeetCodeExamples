using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
        // Given an integer rowIndex, return the rowIndexth(0-indexed) row of the Pascal's triangle.
        // In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
    /// </summary>
    public class _00119_PascalTriangle_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = GetRow(3);
            Assert.AreEqual(new List<int> { 1,3,3,1 }, answer);

            answer = GetRow(0);
            Assert.AreEqual(new List<int> { 1 }, answer);

            answer = GetRow(1);
            Assert.AreEqual(new List<int> { 1,1 }, answer);
        }

        public IList<int> GetRow(int rowIndex)
        {
            if (rowIndex == 0)
            {
                return new List<int> { 1 };
            }
            List<int> old = new List<int> { 1 };

            for (int i = 1; i <= rowIndex; i++)
            {
                List<int> n = new List<int>(old.Count + 1);
                n.Add(1);
                for (int j = 0; j < old.Count - 1; j++)
                {
                    n.Add(old[j] + old[j + 1]);
                }
                n.Add(1);

                old = n;
            }
            return old;
        }
    }
}