using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given a signed 32-bit integer x, return x with its digits reversed.
    // If reversing x causes the value to go outside the signed 32-bit integer range[-231, 231 - 1], then return 0.
    /// </summary>
    public class _00007_ReverseInteger_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
        }

        public int Reverse(int x)
        {
            if (x == 0)
                return 0;

            long oldnum = (long)x;
            long newnum = 0;
            while (oldnum != 0)
            {
                // Pluck out the first number
                long num = oldnum % 10;
                oldnum = oldnum / 10;

                newnum *= 10;
                newnum += num;
                // check if we exceed the bounds of a 32-bit int. Negative numbers have one extra number in the range
                //if ((x > 0 && newnum > (long)Int32.MaxValue) || (x < 0 && newnum > (long)Int32.MaxValue + 1))
                //    return 0;
                if ((newnum > (long)Int32.MaxValue) || (newnum < (long)Int32.MinValue))
                    return 0;
            }

            return (int)newnum;
        }
    }
}