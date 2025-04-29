# You are given an m x n matrix board containing letters 'X' and 'O', capture regions that are surrounded:

# Connect: A cell is connected to adjacent cells horizontally or vertically.
# Region: To form a region connect every 'O' cell.
# Surround: The region is surrounded with 'X' cells if you can connect the region with 'X' cells and none of the region cells are on the edge of the board.
# A surrounded region is captured by replacing all 'O's with 'X's in the input matrix board.

from typing import List
class Solution:
    def solve(self, board: List[List[str]]) -> None:
        """
        Do not return anything, modify board in-place instead.
        """
        rows = len(board)
        cols = len(board[0])
        dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)]
        # "Lock" any region that has reached an edge
        def lock(row: int, col: int):
            board[row][col] = 'L'
            for dir in dirs:
                newR, newC = row + dir[0], col + dir[1]
                if newR < 0 or newR > rows - 1 or newC < 0 or newC > cols - 1 or board[newR][newC] != 'O':
                    continue
                lock(newR, newC)
        # Lock border regions
        for r in range(0, rows):
            if board[r][0] == 'O':
                lock(r, 0)
            if board[r][cols - 1] == 'O':
                lock(r, cols - 1)
        
        for c in range(0, cols):
            if board[0][c] == 'O':
                lock(0, c)
            if board[rows - 1][c] == 'O':
                lock(rows - 1, c)
        
        # Turn any O's into X's and L's into O's
        for r in range(0, rows):
            for c in range(0, cols):
                if board[r][c] == 'O':
                    board[r][c] = 'X'
                if board[r][c] == 'L':
                    board[r][c] = 'O'