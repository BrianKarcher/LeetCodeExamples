using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    // From Daily Coding Problem
    /// <summary>
    // Given:
    // 'a' -> 1
    // 'b' -> 2
    // 'z' -> 26
    // Return the number of ways a decoded message can be decoded (from int to the original string
    // Example: 12 can be "ab", it can be "l". etc.
    // "01" -> 0. No message maps to 01.
    /// </summary>
    public class DecodeCount
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = NumWays("12");
            Assert.AreEqual(2, answer);

            answer = NumWays("27");
            Assert.AreEqual(1, answer);

            answer = NumWays("111");
            Assert.AreEqual(3, answer);

            answer = NumWays("10");
            Assert.AreEqual(1, answer);

            answer = NumWays("01");
            Assert.AreEqual(0, answer);
        }

        //public int NumWays(string input)
        //{
        //    int count = 1;

        //    //map = new Dictionary<string, int>();
        //    //return Recurse(input);
        //}

        Dictionary<char, int> chr = new Dictionary<char, int>();

        public int NumWays(string input)
        {
            map = new Dictionary<int, int>();
            return Recurse(input, 0);
        }

        Dictionary<int, int> map;

        //public int Recurse(string input)
        //{
        //    // Base case
        //    if (input.Length == 0)
        //        return 1;

        //    if (input[0] == '0')
        //        return 0;

        //    if (map.ContainsKey(input))
        //        return map[input];

        //    int count = 0;
        //    count += Recurse(input.Substring(1));
        //    // Can take out a two-digit character-index?
        //    if (input.Length >= 2)
        //    {
        //        // If the 2-digit string starts with a 1, all second digits are valid, ie 10 to 19
        //        if (input[0] == '1')
        //            count += Recurse(input.Substring(2));
        //        // However, if the first digit starts with a 2, the second digit max is a 6.
        //        if (input[0] == '2' && input[1] <= '6')
        //            count += Recurse(input.Substring(2));
        //    }

        //    map.Add(input, count);
        //    return count;
        //}

        public int Recurse(string input, int i)
        {
            // Base case
            if (i == input.Length)
                return 1;

            if (input[i] == '0')
                return 0;

            if (map.ContainsKey(i))
                return map[i];

            int count = 0;
            count += Recurse(input, i + 1);
            // Can take out a two-digit character-index?
            if (input.Length - i >= 2)
            {
                // If the 2-digit string starts with a 1, all second digits are valid, ie 10 to 19
                if (input[i] == '1')
                    count += Recurse(input, i + 2);
                // However, if the first digit starts with a 2, the second digit max is a 6.
                else if (input[i] == '2' && input[i+1] <= '6')
                    count += Recurse(input, i + 2);
            }

            map.Add(i, count);
            return count;
        }
    }
}