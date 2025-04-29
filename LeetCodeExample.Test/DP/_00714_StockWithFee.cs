using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // You are given an array prices where prices[i] is the price of a given stock on the ith day, and an integer fee representing a transaction fee.
    // Find the maximum profit you can achieve.You may complete as many transactions as you like, but you need to pay the transaction fee for each transaction.
    // Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).
    /// </summary>
    public class _00714_StockWithFee
    {
        //          1   3   2   8   4   9
        // NOHOLD   0   0   0   5   5   8
        // HOLD     -1  -1  -1  -1  1   1

        public int MaxProfit(int[] prices, int fee)
        {
            if (prices.Length == 0)
                return 0;

            const int HOLD = 0;
            const int NOHOLD = 1;

            int[,] dp = new int[prices.Length, 2];
            dp[0, NOHOLD] = 0;
            dp[0, HOLD] = -prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                dp[i, NOHOLD] = Math.Max(dp[i - 1, NOHOLD], dp[i - 1, HOLD] + prices[i] - fee);
                dp[i, HOLD] = Math.Max(dp[i - 1, HOLD], dp[i - 1, NOHOLD] - prices[i]);
            }
            return dp[prices.Length - 1, NOHOLD];
        }
    }
}