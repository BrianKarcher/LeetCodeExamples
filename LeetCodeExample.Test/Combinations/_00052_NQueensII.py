# The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.
# Given an integer n, return the number of distinct solutions to the n-queens puzzle.

# My attempt
class Solution:
    def totalNQueens(self, n: int) -> int:
        self.ans = 0
        def rec(depth: int, ul: set, u: set, ur: set):
            # Base case
            if depth >= n:
                self.ans += 1
                return
            for i in range(n):
                # Find x-intercepts for the three lines to check/add
                up = i
                upleft = i - depth
                upright = i + depth
                if up in u or upleft in ul or upright in ur:
                    continue
                u.add(up)
                ul.add(upleft)
                ur.add(upright)
                rec(depth + 1, ul, u, ur)
                u.remove(up)
                ul.remove(upleft)
                ur.remove(upright)
        rec(0, set(), set(), set())
        return self.ans