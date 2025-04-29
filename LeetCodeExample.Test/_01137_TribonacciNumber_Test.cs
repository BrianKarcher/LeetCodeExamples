using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    The Tribonacci sequence Tn is defined as follows: 

    //T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0.

    //Given n, return the value of Tn.
    /// </summary>
    public class _01137_TribonacciNumber_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = Tribonacci(4);
            Assert.AreEqual(4, answer);

            answer = Tribonacci(25);
            Assert.AreEqual(1389537, answer);
        }

        Dictionary<int, int> map = new Dictionary<int, int>();


        public int Tribonacci(int n)
        {
            if (n <= 1)
                return n;
            if (n == 2)
                return 1;

            if (map.ContainsKey(n))
                return map[n];

            int val = Tribonacci(n - 1) + Tribonacci(n - 2) + Tribonacci(n - 3);
            map.Add(n, val);
            return val;
        }

        public int Tribonacci2(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            if (n == 2)
                return 1;

            int[] memo = new int[n + 1];
            memo[0] = 0;
            memo[1] = 1;
            memo[2] = 1;

            for (int i = 3; i <= n; i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2] + memo[i - 3];
            }
            return memo[n];
        }
    }
}