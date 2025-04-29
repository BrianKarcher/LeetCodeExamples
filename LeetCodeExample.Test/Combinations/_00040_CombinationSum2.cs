using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
       // Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target.You may return the combinations in any order.
       //The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of at least one of the chosen numbers is different.
       //It is guaranteed that the number of unique combinations that sum up to target is less than 150 combinations for the given input.
    /// </summary>
    public class _00040_CombinationSum2
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Perm(candidates, 0, target, -1, new List<int>());
            return lst;
        }

        List<IList<int>> lst = new List<IList<int>>();

        void Perm(int[] candidates, int sum, int target, int n, IList<int> arr)
        {
            string ar = "";
            /*for (int i = 0; i < arr.Count; i++)
                ar += arr[i] + ",";*
            Console.WriteLine($"Sum: {sum}, target: {target}, n: {n}, arr length: {arr.Count} - {ar}");*/
            // base case
            //if (n > arr.Count)
            //    return;

            if (sum == target)
            {
                for (int i = 0; i < arr.Count; i++)
                    ar += arr[i] + ",";
                Console.WriteLine($"(ADDING LIST) {ar}");
                //Console.WriteLine($"Adding list ");
                lst.Add(arr.ToList());
                return;
            }
            if (sum > target)
                return;

            for (int i = n + 1; i < candidates.Length; i++)
            {
                //sum += arr[n];
                arr.Add(candidates[i]);
                Perm(candidates, sum + candidates[i], target, i, arr);
                // Backtrack
                arr.RemoveAt(arr.Count - 1);
            }
        }
    }
}