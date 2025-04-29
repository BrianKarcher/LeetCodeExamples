using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an integer array nums of length n, and an integer array queries of length m.

    //    Return an array answer of length m where answer[i] is the maximum size of a subsequence that you can take from nums such that the sum of its elements is less than or equal to queries[i].

    //A subsequence is an array that can be derived from another array by deleting some or no elements without changing the order of the remaining elements.
    /// </summary>
    public class _02389_LongestSubsequenceWithLimitedSum
    {
        public int[] AnswerQueries(int[] nums, int[] queries)
        {
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] += nums[i - 1];
            }

            int[] ans = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                ans[i] = bs(nums, queries[i]);
            }
            return ans;
        }

        public int bs(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] == target)
                {
                    return mid + 1;
                }
                else if (target > nums[mid])
                {
                    // move left
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return l;
        }
    }
}