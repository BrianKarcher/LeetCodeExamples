using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
   // You are climbing a staircase.It takes n steps to reach the top.
   // Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
    /// </summary>
    public class G_00070_ClimbingStairs_Test
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

        public int ClimbStairs(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        /// <summary>
        /// /////////////////////////////////
        /// </summary>

        Dictionary<int, int> map;

        public int ClimbStairs2(int n)
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
    }
}