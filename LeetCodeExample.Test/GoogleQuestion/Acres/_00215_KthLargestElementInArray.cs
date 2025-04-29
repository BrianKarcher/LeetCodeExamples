using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    // Given an integer array nums and an integer k, return the kth largest element in the array.
    // Note that it is the kth largest element in the sorted order, not the kth distinct element.
    /// </summary>
    public class _00215_KthLargestElementInArray
    {
        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int> pq = new PriorityQueue<int>(Comparer<int>.Create((i1, i2) => i2.CompareTo(i1)));
            for (int i = 0; i < nums.Length; i++)
            {
                pq.Enqueue(nums[i]);
            }
            for (int i = 0; i < k - 1; i++)
            {
                pq.Dequeue();
            }
            return pq.Dequeue();
        }
    }
}