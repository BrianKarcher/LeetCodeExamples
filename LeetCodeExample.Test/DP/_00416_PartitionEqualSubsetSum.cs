using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given an integer array nums, return true if you can partition the array into two subsets such that the sum of the elements in both subsets is equal or false otherwise.
/// </summary>
public class _00416_PartitionEqualSubsetSum
{
    bool?[,] memo;

    public bool CanPartition(int[] nums)
    {
        int totalSum = 0;
        foreach (int num in nums)
        {
            totalSum += num;
        }
        // If totalSum is odd, it cannot be partitioned into equal sum subset.
        if (totalSum % 2 != 0) return false;
        int subSetSum = totalSum / 2;
        memo = new bool?[nums.Length + 1, subSetSum + 1];
        return dp(nums, nums.Length - 1, subSetSum);
    }

    bool dp(int[] nums, int index, int subSetSum)
    {
        // Base cases
        if (subSetSum == 0)
            return true;

        if (index == 0 || subSetSum < 0)
            return false;

        if (memo[index, subSetSum] != null)
            return memo[index, subSetSum].Value;

        bool ans = dp(nums, index - 1, subSetSum - nums[index])
            || dp(nums, index - 1, subSetSum);
        memo[index, subSetSum] = ans;
        return ans;
    }
}