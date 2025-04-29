using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //There are several cards arranged in a row, and each card has an associated number of points.The points are given in the integer array cardPoints.
    //In one step, you can take one card from the beginning or from the end of the row.You have to take exactly k cards.
    //Your score is the sum of the points of the cards you have taken.
    //Given the integer array cardPoints and the integer k, return the maximum score you can obtain.
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
            var answer = MaxScore(new int[] { 1, 2, 3, 4, 5, 6, 1 }, 3);
            Assert.AreEqual(12, answer);

            answer = MaxScore(new int[] { 2, 2, 2 }, 2);
            Assert.AreEqual(4, answer);

            answer = MaxScore(new int[] { 9, 7, 7, 9, 7, 7, 9 }, 7);
            Assert.AreEqual(55, answer);

            answer = MaxScore(new int[] { 1, 1000, 1 }, 1);
            Assert.AreEqual(1, answer);

            answer = MaxScore(new int[] { 1, 79, 80, 1, 1, 1, 200, 1 }, 3);
            Assert.AreEqual(202, answer);

            answer = MaxScore(new int[] { 96, 90, 41, 82, 39, 74, 64, 50, 30 }, 8);
            Assert.AreEqual(536, answer);
        }

        // Sliding Window function
        public int MaxScore(int[] cardPoints, int k)
        {
            int currentMax = 0;
            int currentSum = 0;

            int lo = k;
            int hi = cardPoints.Length;

            // Set up the Sum for the kick-start
            for (int j = 0; j < k; j++)
            {
                currentSum += cardPoints[j];
            }

            currentMax = currentSum;

            // My old method had two for loops inside of this loop, one counting up the "lo", and the other
            // counting up the "hi". Realized that simply incrementing and decrementing currentSum
            // is MUCH faster. It is O(n) now.
            for (int i = 1; i < k + 1; i++)
            {
                // Take a card from the lo
                if (lo > 0)
                    currentSum -= cardPoints[lo - 1];

                // Add a card from the hi
                if (hi <= cardPoints.Length)
                    currentSum += cardPoints[hi - 1];

                currentMax = Math.Max(currentMax, currentSum);

                // Slide the window
                lo--;
                hi--;
            }
            return currentMax;
        }
    }
}