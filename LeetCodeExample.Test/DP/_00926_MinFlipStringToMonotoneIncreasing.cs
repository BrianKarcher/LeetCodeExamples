using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//A binary string is monotone increasing if it consists of some number of 0's (possibly none), followed by some number of 1's(also possibly none).
//You are given a binary string s.You can flip s[i] changing it from 0 to 1 or from 1 to 0.
//Return the minimum number of flips to make s monotone increasing.
/// </summary>
public class _00926_MinFlipStringToMonotoneIncreasing
{
    public int MinFlipsMonoIncr(string s)
    {
        int[,] map = new int[s.Length, 2];
        map[0, 0] = s[0] == '0' ? 0 : 1;
        map[0, 1] = s[1] == '1' ? 0 : 1;
        for (int i = 1; i < s.Length; i++)
        {
            // The zero bucket cannot take items from the ones bucket.
            map[i, 0] = map[i - 1, 0] + (s[i] == '0' ? 0 : 1);
            // The ones bucket can take items from the zero or ones buckets.
            // since it is monotone increasing. We take the min of the two.
            map[i, 1] = Math.Min(map[i - 1, 0], map[i - 1, 1]) + (s[i] == '1' ? 0 : 1);
        }
        /*for (int j = 0; j < 2; j++) {
            for (int i = 0; i < s.Length; i++) {
                Console.Write($"{map[i, j]},");
            }
            Console.WriteLine();
        }*/
        return Math.Min(map[s.Length - 1, 0], map[s.Length - 1, 1]);
    }
}