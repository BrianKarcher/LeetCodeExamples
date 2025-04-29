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
    public class _01423_MaximumPointsCards_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            Assert.AreEqual(0, answer[0]);
            Assert.AreEqual(1, answer[1]);

            answer = TwoSum(new int[] { 3, 2, 4 }, 6);
            Assert.AreEqual(1, answer[0]);
            Assert.AreEqual(2, answer[1]);

            answer = TwoSum(new int[] { 3, 3 }, 6);
            Assert.AreEqual(0, answer[0]);
            Assert.AreEqual(1, answer[1]);
        }

        public int MaxScore(int[] cardPoints, int k)
        {

        }
    }
}