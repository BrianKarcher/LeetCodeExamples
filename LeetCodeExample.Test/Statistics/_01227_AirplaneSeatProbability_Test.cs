using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
   // n passengers board an airplane with exactly n seats.The first passenger has lost the ticket and picks a seat randomly.But after that, the rest of passengers will:
   // Take their own seat if it is still available,
   // Pick other seats randomly when they find their seat occupied
   // What is the probability that the n-th person can get his own seat?
    /// </summary>
    public class _01227_AirplaneSeatProbability_Test
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

        public double NthPersonGetsNthSeat(int n)
        {
            if (n == 1)
                return 1;
            else
                return 0.5;
        }
    }
}