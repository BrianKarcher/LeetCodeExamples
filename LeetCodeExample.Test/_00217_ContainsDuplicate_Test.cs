using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
    /// </summary>
    /// Loop through the array ONCE, adding each value into a hash set. If a repeat is found, return true. If end is reached and no
    /// duplicate found, return false.
    /// Time: O(n). - Single loop
    /// Space: O(n). - Hashmap
    public class _00217_ContainsDuplicate_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = ContainsDuplicate(new int[] { 1, 2, 3, 1 });
            Assert.AreEqual(true, answer);

            arr = new HashSet<int>();
            answer = ContainsDuplicate(new int[] { 1, 2, 3, 4 });
            Assert.AreEqual(false, answer);

            arr = new HashSet<int>();
            answer = ContainsDuplicate(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 });
            Assert.AreEqual(true, answer);
        }

        HashSet<int> arr = new HashSet<int>();

        public bool ContainsDuplicate(int[] nums)
        {
            if (nums.Length <= 1)
                return false;

            for (int i = 0; i < nums.Length; i++)
            {
                if (arr.Contains(nums[i]))
                    return true;
                arr.Add(nums[i]);
            }
            return false;
        }
    }
}