using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//There are n gas stations along a circular route, where the amount of gas at the ith station is gas[i].
//You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from the ith station to its next(i + 1)th station.You begin the journey with an empty tank at one of the gas stations.
//Given two integer arrays gas and cost, return the starting gas station's index if you can travel around the circuit once in the clockwise direction, otherwise return -1. If there exists a solution, it is guaranteed to be unique
/// </summary>
public class _00134_GasStation
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int n = gas.Length;

        int total_tank = 0;
        int curr_tank = 0;
        int starting_station = 0;
        for (int i = 0; i < n; ++i)
        {
            total_tank += gas[i] - cost[i];
            curr_tank += gas[i] - cost[i];
            // If one couldn't get here,
            if (curr_tank < 0)
            {
                // Pick up the next station as the starting one.
                starting_station = i + 1;
                // Start with an empty tank.
                curr_tank = 0;
            }
        }
        return total_tank >= 0 ? starting_station : -1;
    }






    /// <summary>
    /// /////////////////////////////////////
    /// </summary>
    /// <param name="gas"></param>
    /// <param name="cost"></param>
    /// <returns></returns>
    public int CanCompleteCircuit2(int[] gas, int[] cost)
    {
        if (gas.Length == 1)
            return gas[0] >= cost[0] ? 0 : -1;
        List<int> startLocs = new();
        int sum = 0;
        // Use prefix sum to find possible starting locations in a greedy way.
        for (int i = 0; i < gas.Length; i++)
        {
            sum = sum + gas[i] - cost[i];
            if (sum < 0)
            {
                // Sum hit zero, you cannot start from any location to the left.
                startLocs.Clear();
                sum = 0;
            }
            else if (cost[i] < gas[i])
            {
                // Can start here.
                startLocs.Add(i);
            }
        }

        for (int i = 0; i < startLocs.Count; i++)
        {
            // Try a loop at this starting location.
            int current = startLocs[i];
            int count = gas.Length;
            sum = 0;
            while (count >= 0)
            {
                sum = sum + gas[current] - cost[current];
                if (sum < 0)
                {
                    // Ran out of gas.
                    break;
                }
                count--;
                if (count == 0)
                {
                    return startLocs[i];
                }
                current++;
                if (current > gas.Length - 1)
                {
                    current = 0;
                }
            }
        }
        return -1;
    }
}