using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Find all valid combinations of k numbers that sum up to n such that the following conditions are true:
    // Only numbers 1 through 9 are used.
    // Each number is used at most once.
    // Return a list of all possible valid combinations. The list must not contain the same combination twice, and the combinations may be returned in any order.    /// </summary>
    public class _00216_CombinationSum3
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            Perm(n, 0, 0, k, new List<int>());
            return lst;
        }

        List<IList<int>> lst = new List<IList<int>>();

        void Perm(int remain, int num, int index, int k, IList<int> arr)
        {
            // index is 0-based, k is 1-based
            if (index == k)
            {
                if (remain == 0)
                {
                    List<int> newList = new List<int>(arr);
                    lst.Add(newList);
                }
                return;
            }

            for (int i = num + 1; i <= 9; i++)
            {
                // Optimization: early stopping
                if (remain - i < 0)
                    break;

                arr.Add(i);
                Perm(remain - i, i, index + 1, k, arr);
                // Backtrack
                arr.RemoveAt(arr.Count - 1);
            }
        }
    }
}
