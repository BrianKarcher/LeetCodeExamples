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
    public class _00001_Time_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = LargestTimeFromDigits(new int[] { 1, 2, 3, 4 });
            Assert.AreEqual("23:41", answer);

            answer = LargestTimeFromDigits(new int[] { 0, 0, 0, 2 });
            Assert.AreEqual("20:00", answer);

            answer = LargestTimeFromDigits(new int[] { 2, 0, 6, 6 });
            Assert.AreEqual("20:00", answer);

        }

        public string LargestTimeFromDigits(int[] arr)
        {
            var lst = arr.ToList();
            string rtn = string.Empty;
            int max = 2;
            for (int i = 0; i < 4; i++)
            {
                int currIndex = -1;
                int currMax = -1;
                for (int j = 0; j < lst.Count; j++)
                {
                    if (lst[j] > currMax)
                    {
                        if (lst[j] > max)
                            continue;
                        currMax = lst[j];
                        currIndex = j;
                    }
                }
                if (currIndex == -1)
                {
                    return string.Empty;
                }
                rtn += lst[currIndex];
                var value = lst[currIndex];
                lst.RemoveAt(currIndex);

                if (i == 0)
                {
                    if (value < 2)
                    {
                        max = 9;
                    }
                    else
                    {
                        max = 3;
                    }
                }
                else if (i == 1)
                {
                    max = 5;
                }
                else if (i == 2)
                {
                    max = 9;
                }
                if (i == 1)
                {
                    rtn += ":";
                }
            }

            return rtn;


        }
    }
}