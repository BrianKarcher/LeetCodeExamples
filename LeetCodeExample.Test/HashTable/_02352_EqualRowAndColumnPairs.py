# Given a 0-indexed n x n integer matrix grid, return the number of pairs (ri, cj) such that row ri and column cj are equal.
# A row and column pair is considered equal if they contain the same elements in the same order (i.e., an equal array).

from typing import List
from collections import Counter
class Solution:
    def equalPairs(self, grid: List[List[int]]) -> int:
        rowSet = Counter()
        for r in range(len(grid)):
            row = []
            for c in range(len(grid[r])):
                row.append(grid[r][c])
            rowSet[tuple(row)] += 1
        
        count = 0
        for c in range(len(grid[0])):
            column = []
            for r in range(len(grid)):
                column.append(grid[r][c])
            count += rowSet[tuple(column)]
        return count