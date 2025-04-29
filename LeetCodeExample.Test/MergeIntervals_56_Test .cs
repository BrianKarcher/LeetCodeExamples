using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    /// Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.
    /// </summary>
    public class MergeIntervals_56_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            int answer;
            answer = NumDecodings("12");
            Assert.AreEqual(2, answer);
            answer = NumDecodings("226");
            Assert.AreEqual(3, answer);
            answer = NumDecodings("0");
            Assert.AreEqual(0, answer);
            answer = NumDecodings("06");
            Assert.AreEqual(0, answer);
            answer = NumDecodings("111111111111111111111111111111111111111111111");

        }

        private Dictionary<int, int> map;

        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            map = new Dictionary<int, int>();
            // This is what kick starts everything
            // This also ensures that short-circuited paths return a zero since only paths that get to the end
            // get this "1"
            map.Add(s.Length, 1);
            return Iterate(s, 0);
        }
        public int Iterate(string s, int index)
        {
            // If we have already calculated the perms up to this index, don't recalculate it
            // This is Memoization
            if (map.ContainsKey(index))
                return map[index];

            // Single-digit branch
            int firstDigit = s[index];
            // Regardless of anything else, a 0 at index needs to be short-circuted.
            // 0 is invalid. 06 is invalid, etc.
            if (firstDigit == '0')
            {
                map.Add(index, 0);
                return 0;
            }

            // Recursive call, this always gets called since we determined that there is a first value
            int count = Iterate(s, index + 1);

            // Double-digit branch
            if (index < s.Length - 1 && Int32.Parse(s.Substring(index, 2)) < 27)
            {
                count += Iterate(s, index + 2);
            }
            map.Add(index, count);
            return count;
        }
    }
}