using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
    //Return the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers.length.
    //The tests are generated such that there is exactly one solution.You may not use the same element twice.
    /// </summary>
    public class _00167_TwoSumII2_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = TwoSum2(new int[] { 2, 7, 11, 15 }, 9);
            Assert.AreEqual(1, answer[0]);
            Assert.AreEqual(2, answer[1]);

            answer = TwoSum2(new int[] { 2, 3, 4 }, 6);
            Assert.AreEqual(1, answer[0]);
            Assert.AreEqual(3, answer[1]);

            answer = TwoSum2(new int[] { -1, 0 }, -1);
            Assert.AreEqual(1, answer[0]);
            Assert.AreEqual(2, answer[1]);

            answer = TwoSum2(new int[] { 12, 13, 23, 28, 43, 44, 59, 60, 61, 68, 70, 86, 88, 92, 124, 125, 136, 168, 173, 173, 180, 199, 212, 221, 227, 230, 277, 282, 306, 314, 316, 321, 325, 328, 336, 337, 363, 365, 368, 370, 370, 371, 375, 384, 387, 394, 400, 404, 414, 422, 422, 427, 430, 435, 457, 493, 506, 527, 531, 538, 541, 546, 568, 583, 585, 587, 650, 652, 677, 691, 730, 737, 740, 751, 755, 764, 778, 783, 785, 789, 794, 803, 809, 815, 847, 858, 863, 863, 874, 887, 896, 916, 920, 926, 927, 930, 933, 957, 981, 997 }, 542);
            Assert.AreEqual(24, answer[0]);
            Assert.AreEqual(32, answer[1]);
        }

        //public int[] TwoSum(int[] numbers, int target)
        //{
        //    // Key = distance to target, Value = indice
        //    Dictionary<int, int> distToTargetDict = new Dictionary<int, int>();

        //    int[] rtn = null;

        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        int val = numbers[i];
        //        int distToTarget = target - val;
        //        if (distToTargetDict.ContainsKey(val))
        //        {
        //            // Found the other value, let's return them with a base index of 1
        //            rtn = new int[] { distToTargetDict[val] + 1, i + 1 };
        //            break;
        //        }
        //        if (!distToTargetDict.ContainsKey(distToTarget))
        //        {
        //            distToTargetDict.Add(distToTarget, i);
        //        }
        //    }

        //    return rtn;
        //}

        /// <summary>
        /// "Closing Window" function. Others call it a 2 pointer.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum2(int[] numbers, int target)
        {
            int lo = 0;
            int hi = numbers.Length - 1;

            while (lo < hi)
            {
                int val = numbers[lo] + numbers[hi];
                if (val < target)
                    lo++;
                else if (val > target)
                    hi--;
                else
                {
                    return new int[] { lo + 1, hi + 1 };
                }
            }

            return null;
        }
    }
}