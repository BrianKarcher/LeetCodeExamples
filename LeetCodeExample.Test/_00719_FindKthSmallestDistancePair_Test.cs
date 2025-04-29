using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // The distance of a pair of integers a and b is defined as the absolute difference between a and b.
    // Given an integer array nums and an integer k, return the kth smallest distance among all the pairs nums[i] and nums[j] where 0 <= i<j<nums.length.
    /// </summary>
    public class _00719_FindKthSmallestDistancePair_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var ans = SmallestDistancePair(new int[] { 1, 3, 1 }, 1);
            Assert.AreEqual(0, ans);

            ans = SmallestDistancePair(new int[] { 1, 1, 1 }, 2);
            Assert.AreEqual(0, ans);

            ans = SmallestDistancePair(new int[] { 1, 6, 1 }, 3);
            Assert.AreEqual(5, ans);
        }

        //public int SmallestDistancePair(int[] nums, int k)
        //{
        //    List<int> orderedNums = nums.OrderBy(i => i).ToList();
        //    List<int> distances = new List<int>();
        //    for (int i = 1; i < orderedNums.Count; i++)
        //    {
        //        distances.Add(Math.Abs(orderedNums[i - 1] - orderedNums[i]));
        //    }
        //    var orderedDistances = distances.OrderBy(i => i).ToList();
        //    return orderedDistances[k - 1];
        //}


        // Time Complexity: O(N log W + N log N), where N is the length of nums, and W
        // is equal to nums[nums.length - 1] - nums[0]. The log W factor comes from our
        // binary search, and we do O(N) work inside our call to possible (or to calculate
        // count in Java). The final O(N log N) factor comes from sorting.

        //Space Complexity: O(1). No additional space is used except for integer variables.
        public int SmallestDistancePair(int[] nums, int k)
        {
            Array.Sort(nums);

            // The binary search will be based on the DISTANCE from the lo to the hi.
            // Not the value.
            // The binary search will adjust left or right based on how many items fall within the distance
            // range from lo - performed by a linear count operation
            int distLo = 0;
            int distHi = nums[nums.Length - 1] - nums[0];
            // 2-space search, the result will appear at the end of the while loop
            while (distLo < distHi)
            {
                int distMid = distLo + (distHi - distLo) / 2;

                int count = 0;
                int lIdx = 0;
                // Loop through the entire array, and count up how many items are less than the distance distMid
                for (int rIdx = 0; rIdx < nums.Length; rIdx++)
                {
                    // move the left index to the right until the distance is less than distMid
                    while (nums[rIdx] - nums[lIdx] > distMid)
                        lIdx++;
                    count += rIdx - lIdx;
                }
                if (k > count)
                    distLo = distMid + 1;
                else
                    distHi = distMid;
            }
            return distLo;
        }
    }
}