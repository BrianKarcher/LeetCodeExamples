using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    public class MaxStockProfit_122_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            int answer;
            answer = MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 });
            Assert.AreEqual(7, answer);
            answer = MaxProfit(new int[] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(4, answer);
            answer = MaxProfit(new int[] { 7, 6, 4, 3, 1 });
            Assert.AreEqual(0, answer);
        }

        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            int buyPrice = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                // Profit to be made? Make it!
                if (prices[i] > buyPrice)
                {
                    profit += prices[i] - buyPrice;
                    buyPrice = prices[i];
                }
                buyPrice = Math.Min(buyPrice, prices[i]);
            }
            return profit;
        }

        public int MaxProfit2(int[] prices)
        {
            int currentProfit = 0;
            bool wantToBuy = true;

            int purchasePrice = 0;

            // Don't calculate the last day
            for (int i = 0; i < prices.Length - 1; i++)
            {
                int price = prices[i];
                // Need to buy and tomorrow's price is higher than today? Buy!
                if (wantToBuy && prices[i + 1] > prices[i])
                {
                    purchasePrice = prices[i];
                    wantToBuy = false;
                }
                else if (wantToBuy == false && prices[i + 1] < prices[i])
                {
                    // Holding shares and prices tomorrow are going down, sell to lock in gains
                    currentProfit += prices[i] - purchasePrice;
                    wantToBuy = true;
                }
            }

            // Still holding shares? Sell the last bit
            if (wantToBuy == false)
            {
                currentProfit += prices[prices.Length - 1] - purchasePrice;
            }
            return currentProfit;
        }
    }
}