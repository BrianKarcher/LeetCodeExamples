using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
        //Given an integer array nums, return the length of the longest strictly increasing subsequence.
        //A subsequence is a sequence that can be derived from an array by deleting some or no elements without changing the order of the remaining elements.For example, [3,6,2,7] is a subsequence of the array[0, 3, 1, 6, 2, 2, 7].
    /// </summary>
    public class _00300_LongestIncreasingSubsequence_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //var ans = lengthOfLIS2(new int[] { 5, 7, -24, 12, 10, 2, 3, 12, 5, 6, 35 });

            var array = new int[] { 5, 7, -24, 12, 10, 2, 3, 12, 5, 6, 35 };
            int n = array.Length;

            var ans = LongestIncreasingSubsequence(array, n);
        }

        public int LengthOfLIS(int[] nums)
        {
            var tails = new List<int>();
            foreach (int num in nums)
            {
                int pos = binarySearch(tails, num);
                if (pos == -1)
                {
                    tails.Add(num);
                }
                else
                {
                    tails[pos] = num;
                }
            }
            return tails.Count;
        }

        private int binarySearch(List<int> tails, int num)
        {
            if (tails.Count == 0)
            {
                return -1;
            }
            int lo = 0, hi = tails.Count - 1;
            while (lo + 1 < hi)
            {
                int mid = (lo + hi) / 2;
                if (tails[mid] >= num)
                {
                    hi = mid;
                }
                else
                {
                    lo = mid;
                }
            }

            if (tails[lo] < num && tails[hi] < num)
            {
                return -1;
            }
            return tails[lo] >= num ? lo : hi;
        }

        // Big O (worst case): O(n^2)
        // Space: O(n)
        // Big Omega (best possible time): O(n^2)
        // Big Theta (average time): O(n^2)
        // We CANNOT use Binary Search since Binary Search can return an invalid subsequence.
        public int lengthOfLIS(int[] nums)
        {
            int[] dp = new int[nums.Length];
            Array.Fill(dp, 1);

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            int longest = 0;
            foreach (int c in dp)
            {
                longest = Math.Max(longest, c);
            }

            return longest;
        }

        public int[] lengthOfLIS2(int[] nums)
        {
            int[] dp = new int[nums.Length];
            Array.Fill(dp, 1);

            int[] refer = new int[nums.Length];
            Array.Fill(refer, -1);

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (dp[j] + 1 > dp[i])
                        {
                            dp[i] = dp[j] + 1;
                            refer[i] = j;
                        }
                    }
                }
            }

            int longest = 0;
            int longestIndex = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (dp[i] > longest)
                {
                    longest = dp[i];
                    longestIndex = i;
                }
            }

            // We found the end of the longest sequence, loop back through it to build it
            int current = longestIndex;
            List<int> seq = new List<int>();
            while (current != -1)
            {
                seq.Add(nums[current]);
                current = refer[current];
            }

            seq.Reverse();
            return seq.ToArray();
        }


        List<int> LongestIncreasingSubsequence(int[] arr, int n)
        {

            // Add boundary case, when array n is zero
            // Depend on smart pointers

            int[] tailIndices = new int[n];

            // Initialized with 0
            for (int i = 0; i < n; i++)
                tailIndices[i] = 0;

            int[] prevIndices = new int[n];

            // initialized with -1
            for (int i = 0; i < n; i++)
                prevIndices[i] = -1;

            // it will always point to empty
            // location
            int len = 1;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] < arr[tailIndices[0]])

                    // new smallest value
                    tailIndices[0] = i;

                else if (arr[i] > arr[tailIndices[len - 1]])
                {

                    // arr[i] wants to extend
                    // largest subsequence
                    prevIndices[i] = tailIndices[len - 1];
                    tailIndices[len++] = i;
                }
                else
                {

                    // arr[i] wants to be a potential
                    // candidate of future subsequence
                    // It will replace ceil value in
                    // tailIndices
                    int pos = GetCeilIndex(arr,
                                           tailIndices, -1, len - 1, arr[i]);

                    prevIndices[i] = tailIndices[pos - 1];
                    tailIndices[pos] = i;
                }
            }

            Console.Write("LIS of given input");
            List<int> subseq = new List<int>();

            for (int i = tailIndices[len - 1]; i >= 0;
                 i = prevIndices[i])
                subseq.Add(arr[i]);


            return subseq;
        }

        // Binary search
        int GetCeilIndex(int[] arr, int[] T, int l,
                                int r, int key)
        {

            while (r - l > 1)
            {
                int m = l + (r - l) / 2;

                if (arr[T[m]] >= key)
                    r = m;
                else
                    l = m;
            }

            return r;
        }
    }
}