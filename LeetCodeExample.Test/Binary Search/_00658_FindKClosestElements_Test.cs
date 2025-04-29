using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given a sorted integer array arr, two integers k and x, return the k closest integers to x in the array.The result should also be sorted in ascending order.


    //    An integer a is closer to x than an integer b if:

    //    |a - x| < |b - x|, or
    //    |a - x| == |b - x| and a < b
    /// </summary>
    public class _00658_FindKClosestElements_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 4, 3);
            Assert.AreEqual(new List<int> { 1, 2, 3, 4 }, answer);

            answer = FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 4, -1);
            Assert.AreEqual(new List<int> { 1, 2, 3, 4 }, answer);

            answer = FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 2, -1);
            Assert.AreEqual(new List<int> { 1, 2 }, answer);

            answer = FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 3, 3);
            Assert.AreEqual(new List<int> { 2, 3, 4 }, answer);

            answer = FindClosestElements(new int[] { 1, 1, 1, 10, 10, 10 }, 1, 9);
            Assert.AreEqual(new List<int> { 10 }, answer);
        }

        //public IList<int> FindClosestElements(int[] arr, int k, int x)
        //{
        //    List<int> result = new List<int>();

        //    // Base case
        //    if (arr.Length == k)
        //    {
        //        for (int i = 0; i < k; i++)
        //        {
        //            result.Add(arr[i]);
        //        }

        //        return result;
        //    }

        //    int l = 0;
        //    int r = arr.Length;
        //    // Find midpoint
        //    //int midIdx = -1;
        //    while (l < r)
        //    {
        //        int m = l + (r - l) / 2;
        //        if (x <= arr[m])
        //            r = m;
        //        else
        //            l = m + 1;
        //    }

        //    l -= 1;
        //    r = l + 1;

        //    // While the window size is less than k
        //    while (r - l - 1 < k)
        //    {
        //        // Be careful to not go out of bounds
        //        if (l == -1)
        //        {
        //            r += 1;
        //            continue;
        //        }

        //        // Expand the window towards the side with the closer number
        //        // Be careful to not go out of bounds with the pointers
        //        if (r == arr.Length || Math.Abs(arr[l] - x) <= Math.Abs(arr[r] - x))
        //        {
        //            l -= 1;
        //        }
        //        else
        //        {
        //            r += 1;
        //        }
        //    }

        //    List<int> lst = new List<int>();

        //    for (int i = l + 1; i < r; i++)
        //    {
        //        lst.Add(arr[i]);
        //    }
        //    return lst;
        //}

        public List<int> FindClosestElements(int[] arr, int k, int x)
        {
            // Initialize binary search bounds
            int left = 0;
            int right = arr.Length - k;

            // Binary search against the criteria described
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (x - arr[mid] > arr[mid + k] - x)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            // Create output in correct format
            List<int> result = new List<int>();
            for (int i = left; i < left + k; i++)
            {
                result.Add(arr[i]);
            }

            return result;
        }
    }
}