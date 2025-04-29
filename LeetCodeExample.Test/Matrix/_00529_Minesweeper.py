# Let's play the minesweeper game (Wikipedia, online game)!

# You are given an m x n char matrix board representing the game board where:

# 'M' represents an unrevealed mine,
# 'E' represents an unrevealed empty square,
# 'B' represents a revealed blank square that has no adjacent mines (i.e., above, below, left, right, and all 4 diagonals),
# digit ('1' to '8') represents how many mines are adjacent to this revealed square, and
# 'X' represents a revealed mine.
# You are also given an integer array click where click = [clickr, clickc] represents the next click position among all the unrevealed squares ('M' or 'E').

# Return the board after revealing this position according to the following rules:

# If a mine 'M' is revealed, then the game is over. You should change it to 'X'.
# If an empty square 'E' with no adjacent mines is revealed, then change it to a revealed blank 'B' and all of its adjacent unrevealed squares should be revealed recursively.
# If an empty square 'E' with at least one adjacent mine is revealed, then change it to a digit ('1' to '8') representing the number of adjacent mines.
# Return the board when no more squares will be revealed.

from typing import List
class Solution:
    def updateBoard(self, board: List[List[str]], click: List[int]) -> List[List[str]]:
        rows = len(board)
        cols = len(board[0])
        dirs = [[-1, 0], [1, 0], [0, -1], [0, 1], [-1, -1], [1, -1], [-1, 1], [1, 1]]
        seen = set()
        def reveal(r: int, c: int):
            if r < 0 or c < 0 or r > rows - 1 or c > cols - 1:
                return
            if (r, c) in seen:
                return
            seen.add((r, c))
            # Already been pre-calculated, no need to continue
            if board[r][c].isdigit():
                return
            if board[r][c] == 'M':
                board[r][c] = 'X'
                return
            # Do adj mine count
            cnt = 0
            for dir in dirs:
                newr, newc = r + dir[0], c + dir[1]
                if newr < 0 or newc < 0 or newr > rows - 1 or newc > cols - 1:
                    continue
                if board[newr][newc] == 'M':
                    cnt += 1
            if cnt > 0:
                board[r][c] = str(cnt)
            else:
                board[r][c] = 'B'
                # Check all adjacent empty squares
                for dir in dirs:
                    reveal(r + dir[0], c + dir[1])

        reveal(click[0], click[1])
        return board