# According to Wikipedia's article: "The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970."

# The board is made up of an m x n grid of cells, where each cell has an initial state: live (represented by a 1) or dead (represented by a 0). Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules (taken from the above Wikipedia article):

# Any live cell with fewer than two live neighbors dies as if caused by under-population.
# Any live cell with two or three live neighbors lives on to the next generation.
# Any live cell with more than three live neighbors dies, as if by over-population.
# Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
# The next state of the board is determined by applying the above rules simultaneously to every cell in the current state of the m x n grid board. In this process, births and deaths occur simultaneously.

# Given the current state of the board, update the board to reflect its next state.

# Note that you do not need to return anything.

from typing import List
from copy import deepcopy
class Solution:
    def gameOfLife(self, board: List[List[int]]) -> None:
        """
        Do not return anything, modify board in-place instead.
        """
        # Create a deep copy
        copy = deepcopy(board)
        dirs = [(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)]
        rows = len(board)
        cols = len(board[0])
        for r in range(rows):
            for c in range(cols):
                # Alive neighbor count
                count = 0
                for dir in dirs:
                    newR, newC = r + dir[0], c + dir[1]
                    if not (0 <= newR < rows and 0 <= newC < cols):
                        continue
                    if copy[newR][newC] == 1:
                        count += 1
                if copy[r][c] == 1:
                    if count < 2:
                        board[r][c] = 0
                    elif count > 3:
                        board[r][c] = 0
                else:
                    if count == 3:
                        board[r][c] = 1