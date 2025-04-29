# Given an m x n matrix board where each cell is a battleship 'X' or empty '.', return the number of the battleships on board.

# Battleships can only be placed horizontally or vertically on board. In other words, they can only be made of the shape 1 x k (1 row, k columns) or k x 1 (k rows, 1 column), where k can be of any size. At least one horizontal or vertical cell separates between two battleships (i.e., there are no adjacent battleships).

class Solution:
    def countBattleships(self, board: List[List[str]]) -> int:
        count = 0
        for r in range(len(board)):
            for c in range(len(board[0])):
                if board[r][c] == 'X':
                    count += 1
                    # erase the battleship
                    # left
                    for i in range(c, 0, -1):
                        if board[r][i] == '.':
                            break
                        board[r][i] = '.'
                    # right
                    for i in range(c + 1, len(board[0]), 1):
                        if board[r][i] == '.':
                            break
                        board[r][i] = '.'
                    # up
                    for i in range(r - 1, 0, -1):
                        if board[i][c] == '.':
                            break
                        board[i][c] = '.'
                    # down
                    for i in range(r + 1, len(board), 1):
                        if board[i][c] == '.':
                            break
                        board[i][c] = '.'

        return count