using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00409_LongestPalindrome_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = LongestPalindrome("abccccdd");
            Assert.AreEqual(7, answer);

            answer = LongestPalindrome("a");
            Assert.AreEqual(1, answer);

            answer = LongestPalindrome("bb");
            Assert.AreEqual(2, answer);

            answer = LongestPalindrome("AAAAAA");
            Assert.AreEqual(6, answer);
        }

        public int LongestPalindrome(string s)
        {
            if (s.Length == 1)
                return 1;

            HashSet<int> chars = new HashSet<int>();
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                // A palindrome is a mirror - you need two characters, one on each side, to match up
                if (chars.Contains(s[i]))
                {
                    count += 2;
                    chars.Remove(s[i]);
                }
                else
                {
                    chars.Add(s[i]);
                }
            }

            // A palindrome can also have one extra character in the middle. Let's see if there is an extra character
            // to put there
            if (chars.Any())
            {
                count++;
            }

            return count;
        }
    }
}