using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    /// https://www.youtube.com/watch?v=rw4s4M3hFfs
    // Moving to a new location and want to find an apartment you want to live in.
    // You have one street on a single line. At each "block" or each index is an apartment
    // You might want to consider living in. 
    // 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1
    // Pick apartment that is close to things that you really value. 
    /// </summary>
    public class Question
    {
        //public int[] TwoSum(List<List<(string name, bool has)>> blocks, string[] reqs)
        public int[] TwoSum(List<Dictionary<string, bool>> blocks, string[] reqs)
        {
            // Key = num, value = index
            // Need to search by other num, not index
            Dictionary<int, int> kvps = new Dictionary<int, int>();
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    var val = nums[i];
            //    var otherNum = target - val;
            //    if (kvps.TryGetValue(otherNum, out var otherIndex))
            //    {
            //        return new int[] { otherIndex, i };
            //    }
            //    kvps.TryAdd(val, i);
            //}

            return null;
        }
    }
}