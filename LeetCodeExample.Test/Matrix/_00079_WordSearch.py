# Given an m x n grid of characters board and a string word, return true if word exists in the grid.
# The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.

from typing import List
class Solution:
    def exist(self, board: List[List[str]], word: str) -> bool:
        rows = len(board)
        cols = len(board[0])
        dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)]
        def rec(r: int, c: int, idx: int, visited: set) -> bool:
            # print(f'Checking {r} {c} {idx} {visited}')
            # Base case
            if board[r][c] != word[idx]:
                    return False
            if idx == len(word) - 1:
                return True
            visited.add((r, c))
            for dir in dirs:
                newR = dir[0] + r
                newC = dir[1] + c
                if not (0 <= newR < rows and 0 <= newC < cols):
                    continue
                if (newR, newC) in visited:
                    continue
                if rec(newR, newC, idx + 1, visited):
                    return True
            visited.remove((r, c))
            return False
        
        for row in range(rows):
            for col in range(cols):
                # print('New start')
                if rec(row, col, 0, set()):
                    return True
        return False