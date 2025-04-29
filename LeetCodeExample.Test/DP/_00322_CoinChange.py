# You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.

# Return the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

# You may assume that you have an infinite number of each kind of coin.

from typing import List
import sys
class Solution:
    def coinChange(self, coins: List[int], amount: int) -> int:
        if amount == 0:
            return 0
        dp = [sys.maxsize] * (amount + 1)
        for c in coins:
            if c >= len(dp): continue
            dp[c] = 1
        for i in range(1, len(dp)):
            if dp[i] == sys.maxsize:
                continue
            # mins = sys.maxsize
            # calc = sys.maxsize
            for c in coins:
                if i + c >= len(dp):
                    continue
                # if dp[i - c] == 0:
                #     continue
                # print(f'{i} {c} {dp[i - c]}')
                dp[i + c] = min(dp[i + c], dp[i] + 1)

            # dp[i] = calc if calc != 0 else 0
        # print(f'{dp}')
        return dp[-1] if dp[-1] != sys.maxsize else -1