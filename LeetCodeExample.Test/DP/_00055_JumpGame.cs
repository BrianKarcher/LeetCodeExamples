using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an integer array nums.You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.
    //    Return true if you can reach the last index, or false otherwise.
    /// </summary>
    public class _00055_JumpGame
    {
        bool?[] memo;

        public bool CanJump(int[] nums)
        {
            memo = new bool?[nums.Length];
            return dp(0, nums);
        }

        public bool dp(int index, int[] nums)
        {
            if (index == nums.Length - 1)
            {
                return true;
            }
            if (index >= nums.Length)
            {
                return false;
            }

            if (memo[index] != null)
            {
                return memo[index].Value;
            }

            for (int i = 1; i <= nums[index]; i++)
            {
                int jumpToPos = index + i;
                if (dp(jumpToPos, nums))
                {
                    memo[index] = true;
                    return true;
                }
            }
            memo[index] = false;
            return false;
        }
    }
}