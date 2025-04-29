# You are given a 0-indexed 2D matrix grid of size m x n, where (r, c) represents:

# A land cell if grid[r][c] = 0, or
# A water cell containing grid[r][c] fish, if grid[r][c] > 0.
# A fisher can start at any water cell (r, c) and can do the following operations any number of times:

# Catch all the fish at cell (r, c), or
# Move to any adjacent water cell.
# Return the maximum number of fish the fisher can catch if he chooses his starting cell optimally, or 0 if no water cell exists.

# An adjacent cell of the cell (r, c), is one of the cells (r, c + 1), (r, c - 1), (r + 1, c) or (r - 1, c) if it exists.

from typing import List
class Solution:
    def findMaxFish(self, grid: List[List[int]]) -> int:
        rows = len(grid)
        cols = len(grid[0])
        # print(f'rows {rows} cols {cols}')

        dirs = [[-1, 0], [1, 0], [0, 1], [0, -1]]

        def search(r: int, c: int) -> int:
            if not (0 <= r < rows and 0 <= c < cols):
                return 0
            if grid[r][c] == 0:
                return 0
            ans = grid[r][c]
            # print(f'{r}, {c}, {ans}')
            # Prevent backtracking
            grid[r][c] = 0
            for dir in dirs:
                nr, nc = r + dir[0], c + dir[1]
                # print(f'searching {nr}, {nc}')
                ans += search(nr, nc)
                # print(ans)
            # print(f'return {ans}')
            return ans

        rtn = 0
        for row in range(rows):
            for col in range(cols):
                rtn = max(rtn, search(row, col))
        return rtn