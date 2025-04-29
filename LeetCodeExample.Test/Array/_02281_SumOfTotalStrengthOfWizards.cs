using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//As the ruler of a kingdom, you have an army of wizards at your command.

//You are given a 0-indexed integer array strength, where strength[i] denotes the strength of the ith wizard.For a contiguous group of wizards (i.e.the wizards' strengths form a subarray of strength), the total strength is defined as the product of the following two values:

//The strength of the weakest wizard in the group.
//The total of all the individual strengths of the wizards in the group.
//Return the sum of the total strengths of all contiguous groups of wizards.Since the answer may be very large, return it modulo 109 + 7.

//A subarray is a contiguous non-empty sequence of elements within an array.
/// </summary>
public class _02281_SumOfTotalStrengthOfWizards
{
    public int TotalStrength(int[] strength)
    {
        int mod = 1000000007;
        int ans = 0;
        for (int i = 0; i < strength.Length; i++)
        {
            int min = Int32.MaxValue;
            int sumGroup = 0;
            for (int j = i; j < strength.Length; j++)
            {
                min = Math.Min(min, strength[j]);
                sumGroup = (sumGroup + strength[j]) % mod;
                ans = (ans + min * sumGroup) % mod;
            }
        }
        return ans;
    }
}