using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    public class BestTimeToBuyStock_121_Test
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
            Assert.AreEqual(5, answer);
            answer = MaxProfit(new int[] { 5, 7, 1, 5, 3, 6, 4 });
            Assert.AreEqual(5, answer);
            answer = MaxProfit(new int[] { 7, 6, 4, 3, 1 });
            Assert.AreEqual(0, answer);
        }

        public int MaxProfit(int[] prices)
        {
            int lowestPriceYet = prices[0];
            // We can only do one single transaction in total and 
            // buy must happen before the sale.
            // So just keep track of the lowest price yet seen and take the difference
            // between that and that days price to find the profit.
            // Max profit wins
            int max = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                max = Math.Max(max, prices[i] - lowestPriceYet);
                lowestPriceYet = Math.Min(lowestPriceYet, prices[i]);
            }
            return max;
        }

        public int MaxProfit3(int[] prices)
        {
            int maxProfit = 0;
            int min = Int32.MaxValue;
            for (int i = 0; i < prices.Length; i++)
            {
                maxProfit = Math.Max(maxProfit, prices[i] - min);
                min = Math.Min(min, prices[i]);
            }
            return maxProfit;
        }

        public int MaxProfit2(int[] prices)
        {
            int currentMaxProfit = 0;

            int currentHighPrice = prices[prices.Length - 1];

            for (int i = prices.Length - 1; i >= 0; i--)
            {
                int price = prices[i];
                if (price > currentHighPrice)
                {
                    currentHighPrice = price;
                }
                if (currentHighPrice - price > currentMaxProfit)
                {
                    currentMaxProfit = currentHighPrice - price;
                }
            }
            return currentMaxProfit;
        }

        public int MaxProfit4(int[] prices)
        {
            int currentMaxProfit = 0;

            int currentLowPrice = Int32.MaxValue;
            int currentHighPrice = Int32.MinValue;

            for (int i = 0; i < prices.Length; i++)
            {
                int price = prices[i];
                if (price < currentLowPrice)
                {
                    currentLowPrice = price;
                    // Reset the High Price, you can only sell stock in the future so the previous high is irrelevant
                    currentHighPrice = price;
                }
                else if (price > currentHighPrice)
                {
                    currentHighPrice = price;
                    if (currentHighPrice - currentLowPrice > currentMaxProfit)
                    {
                        currentMaxProfit = currentHighPrice - currentLowPrice;
                    }
                }
            }
            return currentMaxProfit;
        }
    }
}