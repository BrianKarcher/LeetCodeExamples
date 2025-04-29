using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You have n coins and you want to build a staircase with these coins.The staircase consists of k rows where the ith row has exactly i coins.The last row of the staircase may be incomplete.

    //Given the integer n, return the number of complete rows of the staircase you will build.
    /// </summary>
    public class _00441_ArrangeCoins
    {
        public int arrangeCoins(int n)
        {
            long left = 0, right = n;
            long k, curr;
            while (left <= right)
            {
                k = left + (right - left) / 2;
                curr = k * (k + 1) / 2;

                if (curr == n) return (int)k;

                if (n < curr)
                {
                    right = k - 1;
                }
                else
                {
                    left = k + 1;
                }
            }
            return (int)right;
        }

        public int ArrangeCoins(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            int row = 0;
            long count = 0;
            while (count <= (long)n)
            {
                row++;
                count += row;
            }
            return row - 1;
        }
    }
}