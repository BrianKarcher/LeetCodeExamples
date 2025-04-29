using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
   // You are climbing a staircase.It takes n steps to reach the top.
   // Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
    /// </summary>
    public class _00070_ClimbingStairs_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = ClimbStairs(2);
            Assert.AreEqual(2, answer);

            answer = ClimbStairs(3);
            Assert.AreEqual(3, answer);

            answer = ClimbStairs(4);
            Assert.AreEqual(5, answer);

            answer = ClimbStairs(45);
            Assert.AreEqual(1836311903, answer);
        }

        Dictionary<int, int> map;

        public int ClimbStairs(int n)
        {
            map = new Dictionary<int, int>();
            return Recurse(n);
        }

        public int Recurse(int n)
        {
            // Base case
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;

            if (map.ContainsKey(n))
            {
                return map[n];
            }

            // Can take one step or two
            int val = Recurse(n - 1) + Recurse(n - 2);
            // Memoize
            map.Add(n, val);
            return val;
        }


        /////////////
        /// <summary>
        /// 
        /// </summary>
        int?[] memo;

        public int ClimbStairs2(int n)
        {
            memo = new int?[n];
            return dp(0, n);
        }

        public int dp(int current, int n)
        {
            if (current == n)
                return 1;
            if (current > n)
                return 0;

            if (memo[current] != null)
            {
                return memo[current].Value;
            }

            int oneStep = dp(current + 1, n);
            int twoStep = dp(current + 2, n);

            int combo = oneStep + twoStep;
            memo[current] = combo;
            return combo;
        }
    }
}