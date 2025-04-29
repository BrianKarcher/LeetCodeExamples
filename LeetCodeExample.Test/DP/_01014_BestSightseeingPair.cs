using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // You are given an integer array values where values[i] represents the value of the ith sightseeing spot.Two sightseeing spots i and j have a distance j - i between them.
    // The score of a pair(i<j) of sightseeing spots is values[i] + values[j] + i - j: the sum of the values of the sightseeing spots, minus the distance between them.
    // Return the maximum score of a pair of sightseeing spots.
    /// </summary>
    public class _01014_BestSightseeingPair
    {
        public int MaxScoreSightseeingPair(int[] values)
        {
            int[] bestPairValue = new int[values.Length];
            int max = Int32.MinValue;
            // Best starting pair is the first value
            bestPairValue[0] = values[0];
            // Left to right
            for (int i = 1; i < values.Length; i++)
            {
                // A sight seeing spot loses 1 value each index
                bestPairValue[i] = bestPairValue[i - 1] - 1;
                max = Math.Max(max, bestPairValue[i] + values[i]);
                // See if this is the new best sightseeing spot going forward to pair with
                if (values[i] > bestPairValue[i])
                {
                    bestPairValue[i] = values[i];
                }
            }
            return max;
        }
    }
}