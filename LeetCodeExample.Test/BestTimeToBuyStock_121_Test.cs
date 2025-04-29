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