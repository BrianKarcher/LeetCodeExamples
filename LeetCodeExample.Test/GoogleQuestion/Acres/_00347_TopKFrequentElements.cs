using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    // Given an integer array nums and an integer k, return the k most frequent elements.You may return the answer in any order.
    /// </summary>
    public class _00347_TopKFrequentElements
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                    map.Add(nums[i], 0);
                map[nums[i]]++;
            }
            //var orderedArray = map.OrderByDescending(i => i.Value).ToArray();
            var pq = new PriorityQueue<int>(Comparer<int>.Create((i1, i2) => map[i1] - map[i2]));
            foreach (var key in map.Keys)
            {
                pq.Enqueue(key);
                if (pq.Count() > k)
                    pq.Dequeue();
            }
            int[] rtn = new int[k];
            for (int i = 0; i < k; i++)
            {
                rtn[i] = pq.Dequeue();
            }
            return rtn;
        }

        //public int[] TopKFrequent(int[] nums, int k)
        //{
        //    Dictionary<int, int> map = new Dictionary<int, int>();
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (!map.ContainsKey(nums[i]))
        //            map.Add(nums[i], 0);
        //        map[nums[i]]++;
        //    }
        //    var orderedArray = map.OrderByDescending(i => i.Value).ToArray();
        //    int[] rtn = new int[k];
        //    for (int i = 0; i < k; i++)
        //    {
        //        rtn[i] = orderedArray[i].Key;
        //    }
        //    return rtn;
        //}
    }
}