using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    We are playing the Guess Game.The game is as follows:
    //I pick a number from 1 to n. You have to guess which number I picked.
    //Every time you guess wrong, I will tell you whether the number I picked is higher or lower than your guess.
    //You call a pre-defined API int guess(int num), which returns 3 possible results:
    //-1: The number I picked is lower than your guess (i.e.pick<num).
    //1: The number I picked is higher than your guess (i.e.pick > num).
    //0: The number I picked is equal to your guess(i.e.pick == num).
    //Return the number that I picked.
    /// </summary>
    public class _00374_GuessNumberHigherOrLower_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //var answer = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            //Assert.AreEqual(0, answer[0]);
            //Assert.AreEqual(1, answer[1]);

            //answer = TwoSum(new int[] { 3, 2, 4 }, 6);
            //Assert.AreEqual(1, answer[0]);
            //Assert.AreEqual(2, answer[1]);

            //answer = TwoSum(new int[] { 3, 3 }, 6);
            //Assert.AreEqual(0, answer[0]);
            //Assert.AreEqual(1, answer[1]);
        }

        public int GuessNumber(int n)
        {
            int l = 1;
            int r = n;
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                int g = guess(m);
                if (g == 0)
                    return m;
                else if (g == -1)
                    r = m - 1;
                else
                    l = m + 1;
            }
            return -1;
        }

        int guess(int num)
        {
            return -1;
        }
    }
}