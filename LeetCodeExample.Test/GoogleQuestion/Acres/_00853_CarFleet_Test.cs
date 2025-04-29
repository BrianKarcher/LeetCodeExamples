using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00853_CarFleet_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = CarFleet(12, new int[] { 10, 8, 0, 5, 3 }, new int[] { 2, 4, 1, 1, 3 });
            Assert.AreEqual(3, answer);

            answer = CarFleet(10, new int[] { 3 }, new int[] { 3 });
            Assert.AreEqual(1, answer);

            answer = CarFleet(10, new int[] { 6, 8 }, new int[] { 3, 2 });
            Assert.AreEqual(2, answer);
        }

        public int CarFleet(int target, int[] position, int[] speed)
        {
            List<(int p, int s)> ps = new List<(int p, int s)>();

            for (int i = 0; i < position.Length; i++)
            {
                ps.Add((position[i], speed[i]));
            }

            var orderedPS = ps.OrderByDescending(i => i.p).ToList();

            int carFleetCount = 1;
            float iterations = (target - orderedPS[0].p) / (float)orderedPS[0].s;
            float lastIteration = iterations;

            for (int i = 1; i < orderedPS.Count(); i++)
            {
                float iter = (target - orderedPS[i].p) / (float)orderedPS[i].s;
                if (iter > lastIteration)
                {
                    carFleetCount++;
                    lastIteration = iter;
                }
            }
            return carFleetCount;
        }
    }
}