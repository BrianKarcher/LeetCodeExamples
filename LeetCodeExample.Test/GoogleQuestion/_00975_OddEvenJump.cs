using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //    You are given an integer array arr.From some starting index, you can make a series of jumps.The(1st, 3rd, 5th, ...) jumps in the series are called odd-numbered jumps, and the(2nd, 4th, 6th, ...) jumps in the series are called even-numbered jumps.Note that the jumps are numbered, not the indices.

    //You may jump forward from index i to index j (with i < j) in the following way:

    //During odd-numbered jumps(i.e., jumps 1, 3, 5, ...), you jump to the index j such that arr[i] <= arr[j] and arr[j] is the smallest possible value.If there are multiple such indices j, you can only jump to the smallest such index j.
    //During even-numbered jumps (i.e., jumps 2, 4, 6, ...), you jump to the index j such that arr[i] >= arr[j] and arr[j] is the largest possible value.If there are multiple such indices j, you can only jump to the smallest such index j.
    //It may be the case that for some index i, there are no legal jumps.
    //A starting index is good if, starting from that index, you can reach the end of the array (index arr.length - 1) by jumping some number of times(possibly 0 or more than once).

    //Return the number of good starting indices.
    /// </summary>
    public class _00975_OddEvenJump
    {
        public int OddEvenJumps(int[] arr)
        {
            // On a given i, can we reach the end by going odd?
            bool[] odd = new bool[arr.Length];
            // On a given i, can we reach the end by going even?
            bool[] even = new bool[arr.Length];

            var sortedSet = new SortedSet<(int val, int index)>(Comparer<(int val, int index)>.Create((a, b) =>
            {
                if (a.val < b.val)
                    return -1;
                return 1;
            }));

            int count = 0;

            // dp
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (i == arr.Length - 1)
                {
                    // Last entry automatically can reach the end
                    odd[i] = true;
                    even[i] = true;
                    count++;
                }
                else
                {
                    // Perform the first jump
                    // First jump is odd, so let's go to the smallest upper recorded value from here
                    // We do not search by index, so leave index 0
                    var upperSet = sortedSet.GetViewBetween((arr[i], 0), (Int32.MaxValue, 0));
                    if (!upperSet.Any())
                        odd[i] = false;
                    else
                    {
                        // We switch from odd to even, so put the next even's result into the odd dp
                        odd[i] = even[upperSet.Min.index];
                        // This is the first jump since it is odd, if it is true then the path to the end exists
                        if (odd[i])
                            count++;
                    }
                    // Next do an Even jump (for future dp checks - helping them out)
                    var lowerSet = sortedSet.GetViewBetween((Int32.MinValue, 0), (arr[i], 0));
                    if (!lowerSet.Any())
                        even[i] = false;
                    else
                    {
                        // We switch from even to odd, so put the next odd's result into the even dp
                        even[i] = odd[lowerSet.Max.index];
                    }
                }
                // Need to remove and re-enter the value if it exists so it is properly sorted.
                if (sortedSet.Contains((arr[i], 0)))
                    sortedSet.Remove((arr[i], 0));
                sortedSet.Add((arr[i], i));
            }
            return count;
        }
    }
}
