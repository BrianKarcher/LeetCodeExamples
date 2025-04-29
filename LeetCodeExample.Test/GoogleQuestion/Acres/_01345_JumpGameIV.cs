using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //    Given an array of integers arr, you are initially positioned at the first index of the array.
    //    In one step you can jump from index i to index:

    //    i + 1 where: i + 1 < arr.length.
    //    i - 1 where: i - 1 >= 0.
    //j where: arr[i] == arr[j] and i != j.
    //    Return the minimum number of steps to reach the last index of the array.

    //    Notice that you can not jump outside of the array at any time.
    /// </summary>
    public class _01345_JumpGameIV
    {
        public int MinJumps(int[] arr)
        {
            if (arr.Length == 1)
                return 0;

            // Num : List of indices containing that number
            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                //adj[arr[i]] = adj.GetDefaultValue(arr[i], 0) + 1;
                if (!adj.ContainsKey(arr[i]))
                    adj.Add(arr[i], new List<int>());
                adj[arr[i]].Add(i);
            }

            HashSet<int> visited = new HashSet<int>();
            // Queue contains indexes
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            visited.Add(0);

            int dist = 0;
            while (queue.Count != 0)
            {
                int size = queue.Count;
                dist++;
                for (int i = 0; i < size; i++)
                {
                    var item = queue.Dequeue();
                    // Check - 1
                    if (item > 0 && !visited.Contains(item - 1))
                    {
                        // Impossible to reach the end when going backwards, don't check that
                        visited.Add(item - 1);
                        queue.Enqueue(item - 1);
                    }
                    // Check + 1
                    if (item < arr.Length - 1 && !visited.Contains(item + 1))
                    {
                        if (item + 1 == arr.Length - 1)
                            return dist;
                        visited.Add(item + 1);
                        queue.Enqueue(item + 1);
                    }
                    // Check other entries with the same number
                    //Console.WriteLine($"{item}");
                    var num = arr[item];
                    var sameNums = adj[num];
                    // Be greedy, start with the index closest to the end
                    for (int j = sameNums.Count - 1; j >= 0; j--)
                    {
                        int otherIndex = sameNums[j];
                        if (otherIndex == i)
                            continue;
                        if (visited.Contains(otherIndex))
                            continue;
                        if (otherIndex == arr.Length - 1)
                            return dist;
                        visited.Add(otherIndex);
                        queue.Enqueue(otherIndex);
                    }

                    // Clear the list to prevent redundant search
                    adj[num].Clear();
                }
            }
            return 0;
        }
    }
}