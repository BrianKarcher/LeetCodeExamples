# Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

# Each row must contain the digits 1-9 without repetition.
# Each column must contain the digits 1-9 without repetition.
# Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
# Note:

# A Sudoku board (partially filled) could be valid but is not necessarily solvable.
# Only the filled cells need to be validated according to the mentioned rules.

from typing import List
class Solution:
    def isValidSudoku(self, board: List[List[str]]) -> bool:
        s = set()

        def check(ri, ci) -> bool:
            # nonlocal s

            # print(f'{ri} {ci} {board[ri][ci]}')
            if board[ri][ci] == '.':
                return True
            if board[ri][ci] in s:
                return False
            s.add(board[ri][ci])
            return True

        for r in range(9):
            s = set()
            for c in range(9):
                if not check(r, c):
                    return False

        for c in range(9):
            s = set()
            for r in range(9):
                if not check(r, c):
                    return False

        # print(f'checking subs')
        for r in range(0, 9, 3):
            for c in range(0, 9, 3):
                s = set()
                for sr in range(r, r + 3):
                    for sc in range(c, c + 3):
                        # print(f'{sr} {sc}')
                        if not check(sr, sc):
                            return False
        
        return True