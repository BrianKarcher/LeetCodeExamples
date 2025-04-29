using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given a circular integer array nums(i.e., the next element of nums[nums.length - 1] is nums[0]), return the next greater number for every element in nums.

//The next greater number of a number x is the first greater number to its traversing-order next in the array, which means you could search circularly to find its next greater number.If it doesn't exist, return -1 for this number.
/// </summary>
public class _00503_NextGreaterElementII
{
    // Keep record of indices not yet set. It is a monotonic decreasing stack.
    Stack<int> stack = new();
    int[] map;
    public int[] NextGreaterElements(int[] nums)
    {
        map = new int[nums.Length];
        Array.Fill(map, -1);
        for (int i = 0; i < nums.Length; i++)
        {
            CheckStack(nums, i);
            stack.Push(i);
        }
        // The array is circular so do another lap to see if we find a greater item
        // than what is in the stack.
        for (int i = 0; i < nums.Length; i++)
        {
            CheckStack(nums, i);
        }
        return map;
    }

    void CheckStack(int[] nums, int index)
    {
        while (stack.Count != 0 && nums[stack.Peek()] < nums[index])
        {
            map[stack.Pop()] = nums[index];
        }
    }
}