using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//It is a sweltering summer day, and a boy wants to buy some ice cream bars.
//At the store, there are n ice cream bars.You are given an array costs of length n, where costs[i] is the price of the ith ice cream bar in coins.The boy initially has coins coins to spend, and he wants to buy as many ice cream bars as possible.
//Return the maximum number of ice cream bars the boy can buy with coins coins.
//Note: The boy can buy the ice cream bars in any order.
/// </summary>
public class _01833_MaximumIceCreamBars
{
    // Using Counting Sort (O(m + n))
    public int MaxIceCream(int[] costs, int coins)
    {
        int n = costs.Length;
        int icecreams = 0;

        int m = costs[0];
        foreach (int cost in costs)
        {
            m = Math.Max(m, cost);
        }

        int[] costsFrequency = new int[m + 1];
        foreach (int cost in costs)
        {
            costsFrequency[cost]++;
        }

        for (int cost = 1; cost <= m; ++cost)
        {
            // No ice cream is present costing 'cost'.
            if (costsFrequency[cost] == 0)
            {
                continue;
            }
            // We don't have enough 'coins' to even pick one ice cream.
            if (coins < cost)
            {
                break;
            }

            // Count how many icecreams of 'cost' we can pick with our 'coins'.
            // Either we can pick all ice creams of 'cost' or we will be limited by remaining 'coins'.
            int count = Math.Min(costsFrequency[cost], coins / cost);
            // We reduce price of picked ice creams from our coins.
            coins -= cost * count;
            icecreams += count;
        }

        return icecreams;
    }

    public int MaxIceCream2(int[] costs, int coins)
    {
        int count = 0;
        int coinsLeft = coins;
        Array.Sort(costs);
        for (int i = 0; i < costs.Length; i++)
        {
            if (costs[i] > coinsLeft)
            {
                break;
            }
            coinsLeft -= costs[i];
            count++;
        }
        return count;
    }
}