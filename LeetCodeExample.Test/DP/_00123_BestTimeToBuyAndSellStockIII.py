# You are given an array prices where prices[i] is the price of a given stock on the ith day.
# Find the maximum profit you can achieve. You may complete at most two transactions.
# Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).

from typing import List
class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        # Setting up a state machine for a 2D matrix dp
        BUY1 = 0
        SELL1 = 1 # Record the best possible profit after one sale here
        BUY2 = 2 # Money left after buying the second stock
        SELL2 = 3 # Record the best possible profit after two sales here
        # We go through each index and flow the "best at the time" results through the state machine one state at a time
        dp = [[-float('inf') for _ in range(4)] for _ in range(len(prices))]
        dp[0][BUY1] = -prices[0]
        for i in range(1, len(prices)):
            # Check sales first
            dp[i][BUY1] = max(dp[i - 1][BUY1], -prices[i])
            # If we find a better buy/sell combo, record it. Otherwise keep the previous.
            dp[i][SELL1] = max(dp[i - 1][SELL1], prices[i] + dp[i - 1][BUY1])
            # BUY2 is the optimal amount of money you have left after you have sold the first stock and bought the second
            dp[i][BUY2] = max(dp[i - 1][BUY2], dp[i - 1][SELL1] - prices[i])
            dp[i][SELL2] = max(dp[i - 1][SELL2], prices[i] + dp[i - 1][BUY2])

        # print(f'{dp}')
        
        maxProfit = 0
        for i in range(len(prices)):
            maxProfit = max(maxProfit, dp[i][SELL1], dp[i][SELL2])
        return maxProfit