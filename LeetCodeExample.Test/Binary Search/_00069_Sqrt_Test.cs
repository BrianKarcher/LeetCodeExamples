using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given a non-negative integer x, compute and return the square root of x.
    // Since the return type is an integer, the decimal digits are truncated, and only the integer part of the result is returned.
    // Note: You are not allowed to use any built-in exponent function or operator, such as pow(x, 0.5) or x ** 0.5.
    /// </summary>
    public class _00069_Sqrt_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = MySqrt(4);
            Assert.AreEqual(2, answer);

            answer = MySqrt(8);
            Assert.AreEqual(2, answer);

            answer = MySqrt(9);
            Assert.AreEqual(3, answer);

            answer = MySqrt(2147395599);
            Assert.AreEqual(46339, answer);
        }

        public int MySqrt(int x)
        {
            int l = 0;
            int r = x;

            while (l <= r)
            {
                int m = l + (r - l) / 2;
                long m2 = (long)m * m;
                if (m2 == x)
                    return m;
                else if (x < m2)
                    r = m - 1;
                else
                    l = m + 1;
            }

            // It has decimals. Return the (int) of the right value since r < l currently.
            return r;
        }
    }
}