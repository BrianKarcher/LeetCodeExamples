using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    /// This uses Dynamic Programming (DP) and Memoization (cached results)
    /// </summary>
    public class DecodeWays_91_DP_Test
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

        //A message containing letters from A-Z can be encoded into numbers using the following mapping:

        //'A' -> "1"
        //'B' -> "2"
        //...
        //'Z' -> "26"
        //To decode an encoded message, all the digits must be grouped then mapped back into letters using the reverse of the mapping above(there may be multiple ways). For example, "11106" can be mapped into:

        //"AAJF" with the grouping(1 1 10 6)
        //"KJF" with the grouping(11 10 6)
        //Note that the grouping(1 11 06) is invalid because "06" cannot be mapped into 'F' since "6" is different from "06".

        //Given a string s containing only digits, return the number of ways to decode it.

        //The answer is guaranteed to fit in a 32-bit integer.

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

        //public int Iterate(string s)
        //{
        //    // We hit an end leaf, return 1 since this branch was successful
        //    if (string.IsNullOrEmpty(s))
        //        return 1;

        //    int count = 0;
        //    bool foundLetter = false;

        //    // Single-digit branch
        //    int singleDigit = s[0];
        //    //int singleDigit = Int32.Parse(s[0]);
        //    if (singleDigit >= '1' && singleDigit <= '9')
        //    {
        //        // Recursive call
        //        count += Iterate(s[1..]); // We pulled out one digit
        //        foundLetter = true;
        //    }

        //    // Double-digit branch
        //    if (s.Length > 1)
        //    {
        //        string doubleDigit = s.Substring(0, 2);
        //        int iDoubleDigit = Int32.Parse(doubleDigit);
        //        if (iDoubleDigit >= 10 && iDoubleDigit <= 26)
        //        {
        //            // Recursive call
        //            count += Iterate(s[2..]); // We pulled out two digits
        //            foundLetter = true;
        //        }
        //    }

        //    // Short-circuit the search if no letter could be grabbed, return 0
        //    if (!foundLetter)
        //        return 0;

        //    return count;
        //}



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