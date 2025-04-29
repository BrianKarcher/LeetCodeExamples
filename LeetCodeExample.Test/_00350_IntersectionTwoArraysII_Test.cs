using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given two integer arrays nums1 and nums2, return an array of their intersection.
    // Each element in the result must appear as many times as it shows in both arrays and
    // you may return the result in any order.
    /// </summary>
    public class _00350_IntersectionTwoArraysII_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            // num : count
            Dictionary<int, int> dict1 = new Dictionary<int, int>();

            foreach (var num in nums1)
            {
                if (!dict1.ContainsKey(num))
                    dict1.Add(num, 0);
                dict1[num]++;
            }

            List<int> result = new List<int>();
            foreach (var num2 in nums2)
            {
                if (dict1.ContainsKey(num2))
                {
                    result.Add(num2);
                    dict1[num2]--;
                    if (dict1[num2] == 0)
                        dict1.Remove(num2);
                }
            }

            return result.ToArray();
        }
    }
}