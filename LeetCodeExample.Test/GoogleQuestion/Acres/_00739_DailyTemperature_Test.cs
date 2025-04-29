using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    // Given an array of integers temperatures represents the daily temperatures, return an array answer such
    // that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature.
    // If there is no future day for which this is possible, keep answer[i] == 0 instead.
    /// </summary>
    public class _00739_DailyTemperature_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = DailyTemperatures(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 });
            Assert.AreEqual(new int[] { 1, 1, 4, 2, 1, 1, 0, 0 }, answer);

            answer = DailyTemperatures(new int[] { 30, 40, 50, 60 });
            Assert.AreEqual(new int[] { 1, 1, 1, 0 }, answer);

            answer = DailyTemperatures(new int[] { 30, 60, 90 });
            Assert.AreEqual(new int[] { 1, 1, 0 }, answer);
        }

        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] rtn = new int[temperatures.Length];

            // value : index
            Stack<(int Value, int Index)> cache = new Stack<(int, int)>();

            for (int i = 0; i < temperatures.Length; i++)
            {
                // First check the stack to see if there are any temperatures we can calculate
                // If this day is hotter than the item in the stack...
                while (cache.Any() && temperatures[i] > cache.Peek().Value)
                {
                    // Pop the item off of the stack
                    var temp = cache.Pop();
                    rtn[temp.Index] = i - temp.Index;
                }
                cache.Push((temperatures[i], i));
            }

            // Anything left over is 0
            while (cache.Any())
            {
                var temp = cache.Pop();
                rtn[temp.Index] = 0;
            }

            return rtn;
        }
    }
}