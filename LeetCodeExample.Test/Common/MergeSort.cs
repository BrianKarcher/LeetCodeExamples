using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExample.Test.Leetcode_Templates
{
    class MergeSort
    {
        /**
         * Merge two sorted arrays in O(n + m)
         */
        public double[] Sort(int[] nums1, int[] nums2)
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
