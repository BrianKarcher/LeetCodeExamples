using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00070_ClimbingStairs2_Test
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

        // Space: O(n)
        // Time: O(n)
        public int ClimbStairs(int n)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;

            if (map.ContainsKey(n))
                return map[n];

            int val = ClimbStairs(n - 1) + ClimbStairs(n - 2);
            map.Add(n, val);

            return val;
        }
    }
}