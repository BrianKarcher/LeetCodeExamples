namespace LeetCodeExample.Test;

/// <summary>
//Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
//You may assume that each input would have exactly one solution, and you may not use the same element twice.
//You can return the answer in any order.
/// </summary>
public class _01480_RunningSumOf1DArray
{
    public int[] RunningSum(int[] nums)
    {
        //int[] ans = new int[nums.Length];
        //ans[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            nums[i] = nums[i - 1] + nums[i];
        }
        return nums;
    }
}