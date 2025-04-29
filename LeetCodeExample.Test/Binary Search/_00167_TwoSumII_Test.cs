using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.Let these two numbers be numbers[index1] and numbers[index2] where 1 <= first<second <= numbers.length.
    //Return the indices of the two numbers, index1 and index2, as an integer array[index1, index2] of length 2.

    //The tests are generated such that there is exactly one solution.You may not use the same element twice.
    /// </summary>
    public class _00167_TwoSumII_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public int[] TwoSum(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int comp = target - numbers[i];
                int otherIndex = search(i + 1, numbers.Length - 1, numbers, comp);
                if (otherIndex != -1)
                {
                    return new int[] { i + 1, otherIndex + 1 };
                }
            }
            return null;
        }

        int search(int l, int r, int[] numbers, int target)
        {
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                int midVal = numbers[m];
                if (midVal == target)
                    return m;
                else if (target > midVal)
                    l = m + 1;
                else
                    r = m - 1;
            }
            return -1;
        }
    }
}