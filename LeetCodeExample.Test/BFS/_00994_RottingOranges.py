# You are given an m x n grid where each cell can have one of three values:

# 0 representing an empty cell,
# 1 representing a fresh orange, or
# 2 representing a rotten orange.
# Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.

# Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.

from typing import List
from collections import deque
class Solution:
    def orangesRotting(self, grid: List[List[int]]) -> int:
        q = deque()
        rows = len(grid)
        cols = len(grid[0])
        fresh_count = 0
        # Queue up rotting oranges
        for r in range(rows):
            for c in range(cols):
                if grid[r][c] == 2:
                    q.append((r, c))
                if grid[r][c] == 1:
                    fresh_count += 1

        dirs = [(1, 0), (-1, 0), (0, 1), (0, -1)]
        minutes = 0
        while q:
            count = len(q)
            if fresh_count != 0:
                minutes += 1
            for i in range(count):
                item = q.popleft()
                for dir in dirs:
                    new_r, new_c = item[0] + dir[0], item[1] + dir[1]
                    # bounds check
                    if not (0 <= new_r <= rows - 1 and 0 <= new_c <= cols - 1):
                        continue
                    if grid[new_r][new_c] != 1:
                        continue
                    # make it rotten
                    grid[new_r][new_c] = 2
                    q.append((new_r, new_c))
                    fresh_count -= 1
        
        return -1 if fresh_count != 0 else minutes