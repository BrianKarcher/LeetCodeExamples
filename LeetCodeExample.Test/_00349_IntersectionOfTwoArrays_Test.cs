using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given two integer arrays nums1 and nums2, return an array of their intersection.
    // Each element in the result must be unique and you may return the result in any order.
    /// </summary>
    public class _00349_IntersectionOfTwoArrays_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            // O(N + M)
            HashSet<int> hash1 = new HashSet<int>();
            // Hash the first array
            for (int i = 0; i < nums1.Length; i++)
            {
                hash1.Add(nums1[i]);
            }

            // This will remove duplicates automatically
            HashSet<int> final = new HashSet<int>();

            for (int i = 0; i < nums2.Length; i++)
            {
                if (hash1.Contains(nums2[i]))
                    final.Add(nums2[i]);
            }
            return final.ToArray();
        }

        // If sorted, Two Pointers
        int[] intersections(int[] nums1, int[] nums2)
        {
            nums1 = nums1.OrderBy(i => i).ToArray(); // assume sorted
            nums2 = nums2.OrderBy(i => i).ToArray(); // assume sorted
            List<int> intersections = new List<int>();
            int l = 0, r = 0;
            while (l < nums1.Length && r < nums2.Length)
            {
                int left = nums1[r], right = nums2[l];
                if (right == left)
                {
                    intersections.Add(right);
                    while (left == nums2[r]) r++;
                    while (right == nums1[l]) l++;
                    continue;
                }
                if (right > left) while (left == nums1[r]) r++;
                else while (right == nums2[l]) l++;

            }
            return intersections.ToArray();
        }
    }
}