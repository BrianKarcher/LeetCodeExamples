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
            Array.Sort(candidates);
            Perm(candidates, 0, target, 0, new List<int>());
            return lst;
        }

        List<IList<int>> lst = new List<IList<int>>();

        void Perm(int[] candidates, int sum, int target, int n, IList<int> arr)
        {
            if (sum == target)
            {
                List<int> newList = new List<int>(arr);
                lst.Add(newList);
                return;
            }

            for (int i = n; i < candidates.Length; i++)
            {
                // This one is a little complicated.
                // Basically, for this entry in the combination, say we are looking for index 2
                // and the value is 1, it is pointless to attempt to put another 1 into this same slot
                // as it would just be a duplicate.
                if (i > n && candidates[i] == candidates[i - 1])
                    continue;

                // Optimization: early stopping
                if (sum + candidates[i] > target)
                    break;

                arr.Add(candidates[i]);
                Perm(candidates, sum + candidates[i], target, i + 1, arr);
                // Backtrack
                arr.RemoveAt(arr.Count - 1);
            }
        }
    }
}