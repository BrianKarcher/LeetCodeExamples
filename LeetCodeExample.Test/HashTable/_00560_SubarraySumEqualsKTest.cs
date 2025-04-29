using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer k, return the total number of continuous subarrays whose sum equals to k.
    /// </summary>
    public class _00560_SubarraySumEqualsKTest
    {
        public int SubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int sum = 0;
            int count = 0;
            map.Add(0, 1);
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (map.ContainsKey(sum - k))
                {
                    count += map[sum - k];
                }
                if (!map.ContainsKey(sum))
                    map.Add(sum, 1);
                else
                    map[sum]++;
            }
            return count;
        }
    }
}