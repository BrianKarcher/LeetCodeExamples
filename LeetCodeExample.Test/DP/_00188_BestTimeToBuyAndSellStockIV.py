# You are given an integer array prices where prices[i] is the price of a given stock on the ith day, and an integer k.
# Find the maximum profit you can achieve. You may complete at most k transactions: i.e. you may buy at most k times and sell at most k times.
# Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).

from typing import List
class Solution:
    def maxProfit(self, k: int, prices: List[int]) -> int:
        BUY = 0
        SELL = 1
        # every k has a BUY and a SELL
        dp = [[-float('inf') for _ in range(k * 2)] for _ in range(len(prices))]
        dp[0][BUY] = -prices[0]
        for i in range(1, len(prices)):
            for j in range(0, k * 2, 2):
                # We either start at 0 or the previous SELL price
                startPrice = 0 if j == 0 else dp[i - 1][j - 1]
                dp[i][j + BUY] = max(dp[i - 1][j + BUY], startPrice - prices[i])
                dp[i][j + SELL] = max(dp[i - 1][j + SELL], dp[i - 1][j + BUY] + prices[i])

        ans = 0
        for i in range(1, len(prices)):
            for j in range(0, k * 2, 2):
                ans = max(ans, dp[i][j + SELL])

        return int(ans)