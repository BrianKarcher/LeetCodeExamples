# Given an m x n matrix board where each cell is a battleship 'X' or empty '.', return the number of the battleships on board.

# Battleships can only be placed horizontally or vertically on board. In other words, they can only be made of the shape 1 x k (1 row, k columns) or k x 1 (k rows, 1 column), where k can be of any size. At least one horizontal or vertical cell separates between two battleships (i.e., there are no adjacent battleships).



class Solution:
    def countBattleships(self, board: List[List[str]]) -> int:
        count = 0
        for r in range(len(board)):
            for c in range(len(board[0])):
                if board[r][c] == 'X':
                    if r == 0 and c == 0:
                        print('top-left')
                        count += 1
                        continue
                    if r == 0:
                        count += 1 if board[0][c - 1] == '.' else 0
                        continue
                    if c == 0:
                        count += 1 if board[r - 1][0] == '.' else 0
                        continue
                    count += 1 if board[r - 1][c] == '.' and board[r][c - 1] == '.' else 0
        return count
    

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