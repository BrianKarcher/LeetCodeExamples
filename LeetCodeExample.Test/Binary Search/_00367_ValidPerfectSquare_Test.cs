using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given a positive integer num, write a function which returns True if num is a perfect square else False.

    // Follow up: Do not use any built-in library function such as sqrt.
    /// </summary>
    public class _00367_ValidPerfectSquare_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = IsPerfectSquare(16);
            Assert.AreEqual(true, answer);
            answer = IsPerfectSquare(14);
            Assert.AreEqual(false, answer);
            answer = IsPerfectSquare(2147483647);
            Assert.AreEqual(false, answer);
            
        }

        public bool IsPerfectSquare(int num)
        {
            long l = 0;
            long r = num;
            long lnum = (long)num;

            while (l <= r)
            {
                long m = l + (r - l) / 2;
                long val = m * m;
                if (val == num)
                    return true;
                if (num < val)
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }
            return false;
        }
    }
}