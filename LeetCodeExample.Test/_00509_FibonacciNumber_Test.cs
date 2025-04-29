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
    public class _00509_FibonacciNumber_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = Fib(2);
            Assert.AreEqual(1, answer);

            answer = Fib(3);
            Assert.AreEqual(2, answer);

            answer = Fib(4);
            Assert.AreEqual(3, answer);
        }

        public int Fib(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            return Recurse(n, 2, 1, 0);
        }

        public int Fib2(int N)
        {
            if (N <= 1)
            {
                return N;
            }

            int current = 0;
            int prev1 = 1;
            int prev2 = 0;

            for (int i = 2; i <= N; i++)
            {
                current = prev1 + prev2;
                prev2 = prev1;
                prev1 = current;
            }
            return current;
        }

        public int fib3(int N)
        {
            if (N <= 1)
            {
                return N;
            }
            return fib3(N - 1) + fib3(N - 2);
        }

        // Creating a hash map with 0 -> 0 and 1 -> 1 pairs
        private Dictionary<int, int> cache = new Dictionary<int, int>();

        public int fib(int N)
        {
            if (N <= 1)
                return N;
            if (cache.ContainsKey(N))
            {
                return cache[N];
            }
            int val = fib(N - 1) + fib(N - 2);
            cache.Add(N, val);
            return val;
        }

        public int Recurse(int targetIndex, int currentIndex, int prev1, int prev2)
        {
            int currentValue = prev1 + prev2;
            if (currentIndex == targetIndex)
                return currentValue;

            return Recurse(targetIndex, currentIndex + 1, currentValue, prev1);
        }
    }
}