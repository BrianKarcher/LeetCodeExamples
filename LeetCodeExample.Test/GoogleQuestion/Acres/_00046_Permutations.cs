using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    // Given an array nums of distinct integers, return all the possible permutations.You can return the answer in any order.
    /// </summary>
    public class _00046_Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            rtn = new List<IList<int>>();
            List<int> coll = new List<int>();
            Perm(nums, coll);
            return rtn;
        }

        IList<IList<int>> rtn;
        void Perm(int[] nums, List<int> coll)
        {
            // Base case
            if (coll.Count == nums.Length)
            {
                List<int> copy = new List<int>(coll);
                rtn.Add(copy);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                // Make sure this index is not in coll
                if (coll.Contains(nums[i]))
                    continue;

                coll.Add(nums[i]);
                Perm(nums, coll);
                // Backtrack
                coll.RemoveAt(coll.Count - 1);
            }
        }
    }
}