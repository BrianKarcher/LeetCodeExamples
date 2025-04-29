# Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

from typing import List
class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        ans = []
        def rec(open: int, close: int, string: str):
            if close == n:
                ans.append(string)
                return
            # Can we do an open?
            if open < n:
                rec(open + 1, close, string + '(')
            # Can we do a close?
            if open > close and close < n:
                rec(open, close + 1, string + ')')
        rec(0, 0, '')
        return ans