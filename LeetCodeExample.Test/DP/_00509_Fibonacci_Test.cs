using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
        //    The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, such that each number is the sum of the two preceding ones, starting from 0 and 1. That is,
        // F(0) = 0, F(1) = 1
        // F(n) = F(n - 1) + F(n - 2), for n > 1.
        // Given n, calculate F(n).
    /// </summary>
    public class _00509_Fibonacci_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        Dictionary<int, int> map = new Dictionary<int, int>();

        public int Fib(int n)
        {
            if (n < 2)
                return n;

            if (map.ContainsKey(n))
                return map[n];

            int val = Fib(n - 1) + Fib(n - 2);
            map.Add(n, val);

            return val;
        }

        public int Fib2(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            int[] memo = new int[n + 1];
            memo[0] = 0;
            memo[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2];
            }
            return memo[n];
        }
    }
}