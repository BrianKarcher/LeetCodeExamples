using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//You are given a list of songs where the ith song has a duration of time[i] seconds.
//Return the number of pairs of songs for which their total duration in seconds is divisible by 60. Formally, we want the number of indices i, j such that i<j with (time[i] + time[j]) % 60 == 0.
/// </summary>
public class _01010_PairsOfSongsWithTotalDurationDivisibleBy60
{
    public int NumPairsDivisibleBy60(int[] time)
    {
        for (int i = 0; i < time.Length; i++)
        {
            time[i] = time[i] % 60;
        }
        // Comp : count
        int[] map = new int[61];
        //Dictionary<int, int> map = new();
        // Account for edge case when the value is exactly 60.
        //map.Add(60, 1);
        int count = 0;
        for (int i = 0; i < time.Length; i++)
        {
            // Try to find the complement where this value + comp = 60.
            // Like 2-sum.
            int comp = 60 - time[i];
            if (comp == 60)
            {
                comp = 0;
            }
            //Console.WriteLine($"Comp: {comp}");
            //Console.WriteLine($"Searching for {comp}");
            //if (map.ContainsKey(time[i])) {
            //Console.WriteLine($"Adding {i} {comp} - {map[comp]}");
            count += map[time[i]];
            //}
            //Console.WriteLine($"Adding at index {i} {time[i]}");
            //map.TryAdd(comp, 0);
            map[comp]++;
        }
        return count;
    }
}