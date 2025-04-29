# Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.

# Note: You can only move either down or right at any point in time.

from typing import List
import sys
class Solution:
    def minPathSum(self, grid: List[List[int]]) -> int:
        rows = len(grid)
        cols = len(grid[0])
        dp = [[sys.maxsize for _ in range(cols)] for _ in range(rows)]
        # Do top row
        dp[0][0] = grid[0][0]
        for c in range(1, cols):
            dp[0][c] = dp[0][c - 1] + grid[0][c]
        
        # Do left column
        for r in range(1, rows):
            dp[r][0] = dp[r - 1][0] + grid[r][0]
        
        for r in range(1, rows):
            for c in range(1, cols):
                dp[r][c] = min(dp[r - 1][c], dp[r][c - 1]) + grid[r][c]
        
        return dp[-1][-1]