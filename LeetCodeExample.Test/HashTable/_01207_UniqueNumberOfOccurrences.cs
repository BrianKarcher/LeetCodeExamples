using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given an array of integers arr, return true if the number of occurrences of each value in the array is unique or false otherwise.
/// </summary>
public class _01207_UniqueNumberOfOccurrences
{
    public bool UniqueOccurrences(int[] arr)
    {
        Dictionary<int, int> map = new();
        for (int i = 0; i < arr.Length; i++)
        {
            map.TryAdd(arr[i], 0);
            map[arr[i]]++;
        }
        HashSet<int> counts = new(map.Values);
        return counts.Count == map.Count;
    }
}