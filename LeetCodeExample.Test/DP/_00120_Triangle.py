# Given a triangle array, return the minimum path sum from top to bottom.

# For each step, you may move to an adjacent number of the row below. More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.

from typing import List
import sys
class Solution:
    def minimumTotal(self, triangle: List[List[int]]) -> int:
        dp = triangle[0]
        for i in range(1, len(triangle)):
            newRow = [sys.maxsize] * len(triangle[i])
            for j in range(len(newRow)):
                upLeft = sys.maxsize if j <= 0 else dp[j - 1]
                upRight = sys.maxsize if j >= len(dp) else dp[j]
                newRow[j] = min(upLeft, upRight) + triangle[i][j]
            dp = newRow
        return min(dp)