using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an array prices where prices[i] is the price of a given stock on the ith day.

    //    Find the maximum profit you can achieve. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times) with the following restrictions:

    // After you sell your stock, you cannot buy stock on the next day(i.e., cooldown one day).
    // Note: You may not engage in multiple transactions simultaneously(i.e., you must sell the stock before you buy again).
    /// </summary>
    public class _00309_BestTimeToBuyStockCooldown
    {
        // days
        // Price:   1   2   3   0   2
        // Nohold   0   0   1   2   2
        // Hold     -1  -1  -1  1   1
        // Cooldown -~  1   2   -1  3

        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
                return 0;

            const int HOLD = 0;
            const int NOHOLD = 1;
            const int COOLDOWN = 2;
            int[,] dp = new int[prices.Length, 3];
            dp[0, NOHOLD] = 0;
            dp[0, HOLD] = -prices[0];
            dp[0, COOLDOWN] = Int32.MinValue;

            for (int i = 1; i < prices.Length; i++)
            {
                // In states HOLD or NOHOLD, money either rests or moves from state to state.
                dp[i, NOHOLD] = Math.Max(dp[i - 1, NOHOLD], dp[i - 1, COOLDOWN]);
                // To get to HOLD, you can either buy or keep holding
                dp[i, HOLD] = Math.Max(dp[i - 1, HOLD], dp[i - 1, NOHOLD] - prices[i]);
                dp[i, COOLDOWN] = dp[i - 1, HOLD] + prices[i];
            }
            return Math.Max(dp[prices.Length - 1, NOHOLD], dp[prices.Length - 1, COOLDOWN]);
        }
    }
}