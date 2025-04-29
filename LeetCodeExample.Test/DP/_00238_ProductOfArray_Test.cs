using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.DP
{
    public class ProductOfArray_238_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            int[] answer;
            answer = ProductExceptSelf(new int[] { 1, 2, 3, 4 });
            Assert.AreEqual(new int[] { 24, 12, 8, 6 }, answer);
        }

        public int[] ProductExceptSelf(int[] nums)
        {
            // Store product of numbers to the left of the item in the array
            int[] left = new int[nums.Length];
            int tempProduct = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                left[i] = tempProduct;
                tempProduct *= nums[i];
            }

            // Store product of numbers to the right of the item in the array
            int[] right = new int[nums.Length];
            tempProduct = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                right[i] = tempProduct;
                tempProduct *= nums[i];
            }

            int[] result = new int[nums.Length];
            // Multiply product of items to the left to the product of items to the right
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = left[i] * right[i];
            }

            return result;
        }
    }
}