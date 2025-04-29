using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an integer array nums, return the number of longest increasing subsequences.

    //Notice that the sequence has to be strictly increasing.
    /// </summary>
    public class _00673_NumberOfLongestIncreasingSubsequence
    {
        //        The idea is to use two arrays len[n] and cnt[n] to record the maximum length of Increasing Subsequence and the coresponding number of these sequence which ends with nums[i], respectively. That is:

        //len[i]: the length of the Longest Increasing Subsequence which ends with nums[i].
        //cnt[i]: the number of the Longest Increasing Subsequence which ends with nums[i].

        //Then, the result is the sum of each cnt[i] while its corresponding len[i] is the maximum length.

        public int FindNumberOfLIS(int[] nums)
        {
            int n = nums.Length, res = 0, max_len = 0;
            int[] len = new int[n], cnt = new int[n];
            for (int i = 0; i < n; i++)
            {
                len[i] = cnt[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (len[i] == len[j] + 1) cnt[i] += cnt[j];
                        if (len[i] < len[j] + 1)
                        {
                            len[i] = len[j] + 1;
                            cnt[i] = cnt[j];
                        }
                    }
                }
                if (max_len == len[i]) res += cnt[i];
                if (max_len < len[i])
                {
                    max_len = len[i];
                    res = cnt[i];
                }
            }
            return res;
        }


        //        The idea is to modify classic LIS solution which uses binary search to find the "insertion point" of a currently processed value.At dyn[k] we don't store a single number representing the smallest value such that there exists a LIS of length k+1 as in classic LIS solution. Instead, at dyn[k] we store all such values that were once endings of a k+1 LIS (so we keep the history as well).
        //These values are held in the first part of the pairs in vector<pair<int, int>> which we get by indexing dyn vector.So for example in a pair x = { a, b}
        //        the first part -- a, indicates that there exists a LIS of length k+1 such that it ends with a value a.The second part -- b, represents the number of possible options for which LIS of length k+1 ends with a value equal to or greater than a. This is the place where we use prefix sums.
        //If we want to know how many options do we have to end a LIS of length m with value y, we just binary search for the index i of a pair with first part strictly less than y in dyn[m - 2]. Then the number of options is dyn[m - 2].back().second - dyn[m - 2][i - 1].second or just dyn[m-2].back() if i is 0.
        //That is the basic idea, the running time is O(NlogN), because we just do 2 binary searches for every element of the input.Space complexity is O(N), as every element of the input will be contained in the dyn vector exactly once.
        //Feel free to post any corrections or simpler explanations :)

        public int FindNumberOfLIS2(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            List<List<(int, int)>> dyn = new List<List<(int, int)>>(nums.Length + 1);
            int max_so_far = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                // bsearch insertion point
                int l = 0, r = max_so_far;
                while (l < r)
                {
                    int mid = l + (r - l) / 2;
                    if (dyn[mid].Last().Item1 < nums[i])
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid;
                    }
                }

                // bsearch number of options
                int options = 1;
                int row = l - 1;
                if (row >= 0)
                {
                    int l1 = 0, r1 = dyn[row].Count;
                    while (l1 < r1)
                    {
                        int mid = l1 + (r1 - l1) / 2;
                        if (dyn[row][mid].Item1 < nums[i])
                        {
                            r1 = mid;
                        }
                        else
                        {
                            l1 = mid + 1;
                        }
                    }

                    options = dyn[row].Last().Item2;
                    options -= (l1 == 0) ? 0 : dyn[row][l1 - 1].Item2;
                }


                dyn[l].Add((nums[i], (!dyn[l].Any() ? options : dyn[l].Last().Item2 + options)));
                if (l == max_so_far)
                {
                    max_so_far++;
                }
            }

            return dyn[max_so_far - 1].Last().Item2;

        }
    }
}