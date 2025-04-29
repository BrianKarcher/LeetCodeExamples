using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00088_MergeSortedArray
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int mi = m - 1;
            int ni = nums2.Length - 1;
            int i = nums1.Length - 1;
            // Interesting case. Let's do a merge sort but backwards
            // So we don't have to do any extra work
            while (mi >= 0 && ni >= 0)
            {
                if (nums1[mi] >= nums2[ni])
                {
                    // Pluck from nums1
                    nums1[i] = nums1[mi];
                    i--;
                    mi--;
                }
                else
                {
                    // Pluck from nums2
                    nums1[i] = nums2[ni];
                    ni--;
                    i--;
                }
            }
            // Do any remaining values
            while (mi >= 0)
            {
                // Pluck from nums1
                nums1[i] = nums1[mi];
                i--;
                mi--;
            }
            while (ni >= 0)
            {
                // Pluck from nums2
                nums1[i] = nums2[ni];
                i--;
                ni--;
            }
        }

        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            int i = 0;

            // Let's try not to create a new array
            // Move the elements to the end of the array nums1
            for (int j = nums1.Length - m; j < nums1.Length; j++)
            {
                nums1[j] = nums1[i];
                i++;
            }
            int mi = nums1.Length - m;
            int ni = 0;
            i = 0;
            //Console.WriteLine($"mi: {mi}, ni: {ni}");
            // Do a merge sort
            while (mi < nums1.Length && ni < n)
            {
                if (nums1[mi] <= nums2[ni])
                {
                    // Grab item from nums1
                    nums1[i] = nums1[mi];
                    i++;
                    mi++;
                }
                else
                {
                    // Grab item from nums2
                    nums1[i] = nums2[ni];
                    i++;
                    ni++;
                }
            }
            // Put in any remaining items
            while (mi < nums1.Length)
            {
                // Grab item from nums1
                nums1[i] = nums1[mi];
                i++;
                mi++;
            }

            while (ni < n && i < nums1.Length)
            {
                // Grab item from nums1
                nums1[i] = nums2[ni];
                i++;
                ni++;
            }
        }
    }
}