using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    We define a harmonious array as an array where the difference between its maximum value and its minimum value is exactly 1.

    //Given an integer array nums, return the length of its longest harmonious subsequence among all its possible subsequences.

    //A subsequence of array is a sequence that can be derived from the array by deleting some or no elements without changing the order of the remaining elements.
    /// </summary>
    public class _00594_LongestHarmoniousSubsequence
    {
        public int FindLHS(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int res = 0;
            foreach (int num in nums)
            {
                if (!map.ContainsKey(num))
                    map.Add(num, 0);
                map[num]++;
                if (map.ContainsKey(num + 1))
                    res = Math.Max(res, map[num] + map[num + 1]);
                if (map.ContainsKey(num - 1))
                    res = Math.Max(res, map[num] + map[num - 1]);
            }
            return res;
        }

        public int FindLHS2(int[] nums)
        {
            //var orderedNums = nums.OrderBy(i => i);
            Dictionary<int, int> counts = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!counts.ContainsKey(nums[i]))
                    counts.Add(nums[i], 0);
                counts[nums[i]]++;
            }
            int max = 0;
            var orderedNums = counts.OrderBy(i => i.Key).ToList();
            for (int i = 0; i < orderedNums.Count - 1; i++)
            {
                if (orderedNums[i].Key + 1 == orderedNums[i + 1].Key)
                    max = Math.Max(max, orderedNums[i].Value + orderedNums[i + 1].Value);
            }
            return max;
        }
    }
}