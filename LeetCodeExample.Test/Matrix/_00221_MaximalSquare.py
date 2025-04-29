# Given an m x n binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.

from typing import List
class Solution:
    def maximalSquare(self, matrix: List[List[str]]) -> int:
        rows = len(matrix)
        cols = len(matrix[0])
        dp = [[0 for _ in range(cols)] for _ in range(rows)]
        ans = 0
        # Do top row
        for c in range(cols):
            dp[0][c] = int(matrix[0][c])
            ans = max(ans, dp[0][c])
        # Do left column
        for r in range(rows):
            dp[r][0] = int(matrix[r][0])
            ans = max(ans, dp[r][0])

        # Do middle
        for r in range(1, rows):
            for c in range(1, cols):
                if matrix[r][c] == '0':
                    continue
                dp[r][c] = min(dp[r - 1][c], dp[r][c - 1], dp[r - 1][c - 1]) + 1
                ans = max(ans, dp[r][c])
        
        return ans ** 2