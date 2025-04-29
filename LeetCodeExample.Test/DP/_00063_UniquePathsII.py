# You are given an m x n integer array grid. There is a robot initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.
# An obstacle and space are marked as 1 or 0 respectively in grid. A path that the robot takes cannot include any square that is an obstacle.
# Return the number of possible unique paths that the robot can take to reach the bottom-right corner.
# The testcases are generated so that the answer will be less than or equal to 2 * 109.

from typing import List
class Solution:
    def uniquePathsWithObstacles(self, obstacleGrid: List[List[int]]) -> int:
        rows = len(obstacleGrid)
        cols = len(obstacleGrid[0])

        # Make future calcs easier
        for r in range(rows):
            for c in range(cols):
                obstacleGrid[r][c] = 0 if obstacleGrid[r][c] == 1 else 1

        # Do top row
        for c in range(1, cols):
            obstacleGrid[0][c] = min(obstacleGrid[0][c], obstacleGrid[0][c - 1])
        # Do left column
        for r in range(1, rows):
            obstacleGrid[r][0] = min(obstacleGrid[r][0], obstacleGrid[r - 1][0])
        
        for r in range(1, rows):
            for c in range(1, cols):
                if obstacleGrid[r][c] != 0:
                    obstacleGrid[r][c] = obstacleGrid[r - 1][c] + obstacleGrid[r][c - 1]
        
        return obstacleGrid[-1][-1]
    

    

from typing import List
class Solution:
    def uniquePathsWithObstacles(self, obstacleGrid: List[List[int]]) -> int:
        rows = len(obstacleGrid)
        cols = len(obstacleGrid[0])

        dp = [[0 for _ in range(cols)] for _ in range(rows)]

        # Make future calcs easier
        for r in range(rows):
            for c in range(cols):
                obstacleGrid[r][c] = 0 if obstacleGrid[r][c] == 1 else 1

        dp[0][0] = obstacleGrid[0][0]
        # if rows == 1 and cols == 1:
        #     return obstacleGrid[0][0]

        # Do top row
        for c in range(1, cols):
            dp[0][c] = min(dp[0][c - 1], obstacleGrid[0][c])
        # Do left column
        for r in range(1, rows):
            dp[r][0] = min(dp[r - 1][0], obstacleGrid[r][0])
        
        for r in range(1, rows):
            for c in range(1, cols):
                if obstacleGrid[r][c] == 0:
                    dp[r][c] = 0
                else:
                    dp[r][c] = dp[r - 1][c] + dp[r][c - 1]
        
        return dp[-1][-1]