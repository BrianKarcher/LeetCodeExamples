using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//The next greater element of some element x in an array is the first greater element that is to the right of x in the same array.

//You are given two distinct 0-indexed integer arrays nums1 and nums2, where nums1 is a subset of nums2.

//For each 0 <= i<nums1.length, find the index j such that nums1[i] == nums2[j] and determine the next greater element of nums2[j] in nums2.If there is no next greater element, then the answer for this query is -1.

//Return an array ans of length nums1.length such that ans[i] is the next greater element as described above.
/// </summary>
public class _00496_NextGreaterElementI
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        // value : next greater value.
        Dictionary<int, int> map = new();
        // A strictly decreasing monotonic stack - stores indexes.
        Stack<int> stack = new();
        // Crunch nums2.
        for (int i = 0; i < nums2.Length; i++)
        {
            while (stack.Count != 0 && nums2[i] > nums2[stack.Peek()])
            {
                // Found an item higher, register it.
                int pop = stack.Pop();
                //Console.WriteLine($"{pop} - {i}");
                map.Add(nums2[pop], nums2[i]);
            }
            stack.Push(i);
        }
        int[] rtn = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            if (map.ContainsKey(nums1[i]))
            {
                rtn[i] = map[nums1[i]];
            }
            else
            {
                rtn[i] = -1;
            }
        }
        return rtn;
    }
}