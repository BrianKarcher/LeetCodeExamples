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
    public class _00744_SmallestLetterGreaterThanTarget_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = NextGreatestLetter(new char[] { 'c', 'f', 'j' }, 'a');
            Assert.AreEqual('c', answer);

            answer = NextGreatestLetter(new char[] { 'c', 'f', 'j' }, 'c');
            Assert.AreEqual('f', answer);

            answer = NextGreatestLetter(new char[] { 'c', 'f', 'j' }, 'd');
            Assert.AreEqual('f', answer);

            answer = NextGreatestLetter(new char[] { 'c', 'f', 'j' }, 'g');
            Assert.AreEqual('j', answer);

            answer = NextGreatestLetter(new char[] { 'c', 'f', 'j' }, 'j');
            Assert.AreEqual('c', answer);
        }

        public char NextGreatestLetter(char[] letters, char target)
        {
            // Letters wrap around condition, return first letter in this case
            if (letters[letters.Length - 1] <= target)
                return letters[0];

            int l = 0;
            int r = letters.Length - 1;
            // 2-space since we are checking two elements at a time
            while (l < r)
            {
                int m = (l + r) / 2;
                if (target >= letters[m])
                    l = m + 1;
                else
                    r = m;
            }
            return letters[l];
        }
    }
}