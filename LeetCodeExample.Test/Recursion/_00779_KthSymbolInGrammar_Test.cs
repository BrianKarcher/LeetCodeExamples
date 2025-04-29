using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    We build a table of n rows(1-indexed). We start by writing 0 in the 1st row.Now in every subsequent row, we look at the previous row and replace each occurrence of 0 with 01, and each occurrence of 1 with 10.
    //   For example, for n = 3, the 1st row is 0, the 2nd row is 01, and the 3rd row is 0110.
    // Given two integer n and k, return the kth (1-indexed) symbol in the nth row of a table of n rows.
    /// </summary>
    public class _00779_KthSymbolInGrammar_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
        }

        public int KthGrammar(int n, int k)
        {
            if (n == 1)
                return 0;
            int parent = KthGrammar(n - 1, (k / 2) + k % 2);
            bool isKOdd = k % 2 == 1;
            if (parent == 0)
            {
                if (isKOdd) return 0;
                else return 1;
            }
            else
            {
                if (isKOdd) return 1;
                else return 0;
            }
        }
    }
}