using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
        // Given an array of non-negative integers nums, you are initially positioned at the first index of the array.
        // Each element in the array represents your maximum jump length at that position.
        // Your goal is to reach the last index in the minimum number of jumps.
        // You can assume that you can always reach the last index.
    /// </summary>
    public class _00045_JumpGameII_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
        }

        // Leetcode
        public int jump(int[] nums)
        {
            int jumps = 0, currentJumpEnd = 0, farthest = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                // we continuously find the how far we can reach in the current jump
                farthest = Math.Max(farthest, i + nums[i]);
                // if we have come to the end of the current jump,
                // we need to make another jump
                if (i == currentJumpEnd)
                {
                    jumps++;
                    currentJumpEnd = farthest;
                }
            }
            return jumps;
        }

        // dp
        public int Jump(int[] nums)
        {
            return Recurse(0, nums);
        }

        Dictionary<int, int> map = new Dictionary<int, int>();

        public int Recurse(int index, int[] nums)
        {
            // base case
            if (index > nums.Length - 1)
                return Int32.MaxValue;
            if (index == nums.Length - 1)
                return 0;

            // Memoization, turns this into O(n)
            if (map.ContainsKey(index))
                return map[index];

            int minJumps = Int32.MaxValue;

            for (int i = 1; i <= nums[index]; i++)
            {
                int rec = Recurse(index + i, nums);
                minJumps = Math.Min(minJumps, rec);
            }

            // Fixes int32 overflow issue.
            int jumps = Math.Max(minJumps, minJumps + 1);

            map.Add(index, jumps);

            // This is one more jump!
            return jumps;
        }
    }
}