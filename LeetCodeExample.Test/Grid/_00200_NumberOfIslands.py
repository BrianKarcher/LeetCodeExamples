# Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
# An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

from typing import List
class Solution:
    def numIslands(self, grid: List[List[str]]) -> int:
        cols = len(grid[0])
        rows = len(grid)
        dirs = ((-1, 0), (1, 0), (0, -1), (0, 1))
        def removeIsland(x: int, y: int):
            grid[y][x] = '0'
            # DFS
            for dir in dirs:
                newX = x + dir[0]
                newY = y + dir[1]
                if newX < 0 or newY < 0 or newX > cols - 1 or newY > rows - 1 or grid[newY][newX] == '0':
                    continue
                removeIsland(newX, newY)
        
        ans = 0
        for row in range(rows):
            for col in range(cols):
                if grid[row][col] == '1':
                    ans += 1
                    removeIsland(col, row)
        return ans