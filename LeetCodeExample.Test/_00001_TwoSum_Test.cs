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
    public class _00001_TwoSum_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            Assert.AreEqual(0, answer[0]);
            Assert.AreEqual(1, answer[1]);

            answer = TwoSum(new int[] { 3, 2, 4 }, 6);
            Assert.AreEqual(1, answer[0]);
            Assert.AreEqual(2, answer[1]);

            answer = TwoSum(new int[] { 3, 3 }, 6);
            Assert.AreEqual(0, answer[0]);
            Assert.AreEqual(1, answer[1]);
        }

        public int[] TwoSum(int[] nums, int target)
        {
            // Key = num, value = index
            // Need to search by other num, not index
            Dictionary<int, int> kvps = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var val = nums[i];
                var otherNum = target - val;
                if (kvps.TryGetValue(otherNum, out var otherIndex))
                {
                    return new int[] { otherIndex, i };
                }
                kvps.TryAdd(val, i);
            }

            return null;
        }

        //public int[] TwoSum(int[] nums, int target)
        //{
        //    // Key = num, value = index
        //    // Need to search by other num, not index
        //    HashSet<int> cache = new();
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        var val = nums[i];
        //        var otherNum = target - val;
        //        if (cache.Contains(otherNum))
        //        {
        //            return new int[] { otherIndex, i };
        //        }
        //        kvps.TryAdd(val, i);
        //    }

        //    return null;
        //}
    }
}