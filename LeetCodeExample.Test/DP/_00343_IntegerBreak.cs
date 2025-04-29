using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an integer n, break it into the sum of k positive integers, where k >= 2, and maximize the product of those integers.
    // Return the maximum product you can get.
    /// </summary>
    public class _00343_IntegerBreak
    {
        // 0    1   2   3   4   5   6   7   8   9   10
        // 1    1   1   2   4   6   9   12  18  27  36

        int?[] memo;

        public int IntegerBreak(int n)
        {
            memo = new int?[n + 1];
            return dp(n);
        }

        public int dp(int rem)
        {
            if (rem <= 1)
            {
                return 1;
            }
            if (rem < 0)
            {
                return 0;
            }

            if (memo[rem] != null)
            {
                return memo[rem].Value;
            }

            int max = Int32.MinValue;
            for (int i = 1; i < rem; i++)
            {
                // i + (rem - i) = rem
                max = Math.Max(max, Math.Max(i, dp(i)) * Math.Max(rem - i, dp(rem - i)));
            }
            memo[rem] = max;
            Console.WriteLine($"{rem}, {max}");
            return max;
        }
    }
}