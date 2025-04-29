using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Write a function that reverses a string. The input string is given as an array of characters s.
    /// </summary>
    public class _00344_ReverseString_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public void ReverseString(char[] s)
        {
            Recurse(s, 0);
        }

        void Recurse(char[] s, int index)
        {
            // Base case
            if (index == s.Length / 2)
                return;

            char temp = s[index];
            s[index] = s[s.Length - 1 - index];
            s[s.Length - 1 - index] = temp;
            Recurse(s, index + 1);
        }
    }
}