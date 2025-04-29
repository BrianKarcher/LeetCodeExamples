# Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.
# A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

from typing import List
class Solution:
    def letterCombinations(self, digits: str) -> List[str]:
        map = {'2': ['a', 'b', 'c'], '3': ['d', 'e', 'f'], '4': ['g', 'h', 'i'], '5': ['j', 'k', 'l'], '6': ['m', 'n', 'o'], '7': ['p', 'q', 'r', 's'], '8': ['t', 'u', 'v'], '9': ['w', 'x', 'y', 'z']}

        def rec(i: int, s: str, ans: List[str]):
            if i > len(digits) - 1:
                # print(f'{s}')
                ans.append(s)
                return
            for letter in map[digits[i]]:
                # print(f'{letter}')
                rec(i + 1, s + letter, ans)

        if not digits:
            return []
        ans = []
        rec(0, '', ans)
        return ans