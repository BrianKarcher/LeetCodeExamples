using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    // Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
    // The overall run time complexity should be O(log (m+n)).
    /// </summary>
    public class _00004_MedianOfTwoSortedArrays_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double[] arr = MergeSort(nums1, nums2);
            // Odd length, can grab the middle value
            if (arr.Length % 2 == 1)
            {
                return arr[arr.Length / 2];
            }
            else
            {
                // Even, average the two middle values
                int mid = arr.Length / 2;
                return (arr[mid] + arr[mid - 1]) / 2;
            }
        }

        public double[] MergeSort(int[] nums1, int[] nums2)
        {
            // nums1 index
            int i = 0;
            // nums2 index
            int j = 0;
            // k is the index into the new array
            int k = 0;
            double[] arr = new double[nums1.Length + nums2.Length];

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    arr[k] = nums1[i];
                    k++;
                    i++;
                }
                else
                {
                    arr[k] = nums2[j];
                    j++;
                    k++;
                }
            }

            // Insert any leftovers - the while above doesn't always get them all
            while (i < nums1.Length)
            {
                arr[k] = nums1[i];
                i++;
                k++;
            }

            while (j < nums2.Length)
            {
                arr[k] = nums2[j];
                j++;
                k++;
            }
            return arr;
        }
    }
}