using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//    Numbers can be regarded as the product of their factors.

//    For example, 8 = 2 x 2 x 2 = 2 x 4.
//Given an integer n, return all possible combinations of its factors.You may return the answer in any order.

//Note that the factors should be in the range [2, n - 1].
/// </summary>
public class _00254_FactorCombinations
{
    List<IList<int>> rtn = new();

    public IList<IList<int>> GetFactors(int n)
    {
        Recurse(n, 2, new List<int>());
        return rtn;
    }

    void Recurse(int n, int min, List<int> arr)
    {
        if (n == 1)
        {
            return;
        }

        for (int i = min; i <= n / 2; i++)
        {
            if (n % i == 0)
            {
                int other = n / i;
                // Don't go backwards to - hopefully - prevent duplicates.
                if (other < i)
                {
                    continue;
                }
                arr.Add(i);
                arr.Add(other);
                // Create a clone.
                rtn.Add(new List<int>(arr));
                arr.RemoveAt(arr.Count - 1); // Backtrack, remove "other".
                                             // Find out if "other" can be further factored
                                             //Console.WriteLine($"Checking {i},{other}");
                Recurse(other, i, arr);
                arr.RemoveAt(arr.Count - 1); // Backtrack, remove "i".
            }
        }
    }
}