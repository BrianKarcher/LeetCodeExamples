using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // You are given an array prices where prices[i] is the price of a given stock on the ith day.
    // Find the maximum profit you can achieve. You may complete at most two transactions.
    // Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).
    /// </summary>
    public class _00123_BestTimeToBuyStockIII
    {
        // Bottom-up
        int maxProfit(int[] prices)
        {
            int n = prices.Length;

            int buyStock1 = Int32.MaxValue, buyStock2 = Int32.MaxValue;
            int profitStock1 = 0, profitStock2 = 0;

            for (int i = 0; i < n; i++)
            {
                buyStock1 = Math.Min(buyStock1, prices[i]);
                profitStock1 = Math.Max(profitStock1, prices[i] - buyStock1);
                buyStock2 = Math.Min(buyStock2, prices[i] - profitStock1);
                profitStock2 = Math.Max(profitStock2, prices[i] - buyStock2);

            }
            return profitStock2;

        }

        // Top-down
        public int MaxProfit(int[] prices)
        {
            return dp(prices, 0, false, 0);
        }

        public Dictionary<(int transCount, bool isHolding, int day), int> memo = new Dictionary<(int, bool, int), int>();

        public int dp(int[] prices, int transCount, bool isHolding, int day)
        {
            // base case
            if (day == prices.Length)
                return 0;
            if (transCount == 2)
                return 0;

            if (memo.ContainsKey((transCount, isHolding, day)))
                return memo[(transCount, isHolding, day)];

            int maxProfit = Int32.MinValue;
            if (!isHolding)
            {
                // If we are not holding stock, we can choose to buy
                int buy = dp(prices, transCount, true, day + 1) - prices[day]; // A purchase subtracts from our profit
                // Or not to buy
                int notBuy = dp(prices, transCount, false, day + 1);
                maxProfit = Math.Max(buy, notBuy);
            }
            else
            {
                // If we are holding stock, what if we choose to sell?
                int sell = dp(prices, transCount + 1, false, day + 1) + prices[day]; // A sell adds to our profit
                // Or not sell?
                int notSell = dp(prices, transCount, true, day + 1);
                maxProfit = Math.Max(sell, notSell);
            }

            memo[(transCount, isHolding, day)] = maxProfit;

            return maxProfit;
        }


        // We have two options to do today
        // We can buy stock, then look for a day to sell
        // Or we can skip today
        // We will take the maximum of both of those options

        // Option 1: Buy stock today and look for a day to sell for max profit
        // Must recurse to that day since we don't know the true profit of this decision
        // unless we recurse to that day and it will return the max profit for THAT day
        // and the transactions remaining

        //int profitIfBuy = 0;

        //for (int i = day + 1; i < prices.Length; i++)
        //{
        //    if (prices[i] > prices[day])
        //    {
        //        // Price is higher than today, see profit from the sale
        //        // Advance to day of sale
        //        int futureProfit = dp(prices, transCount + 1, i) + (prices[i] - prices[day]);
        //        profitIfBuy = Math.Max(profitIfBuy, futureProfit);
        //    }
        //}

        //int profitIfTodaySkipped = dp(prices, transCount, day + 1);

        //int maxProfit = Math.Max(profitIfBuy, profitIfTodaySkipped);
    }
}