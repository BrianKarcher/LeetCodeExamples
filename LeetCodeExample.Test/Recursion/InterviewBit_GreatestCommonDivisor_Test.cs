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
    public class InterviewBit_GreatestCommonDivisor_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
        }

        public int gcd(int A, int B)
        {
            if (A > B)
                return Recurse(A, B);
            else
                return Recurse(B, A);
        }

        public int Recurse(int A, int B)
        {
            int max = Math.Max(A, B);
            int min = Math.Min(A, B);

            // Base case
            if (min == 0)
                return max;

            return Recurse(max % min, min);
        }
    }
}