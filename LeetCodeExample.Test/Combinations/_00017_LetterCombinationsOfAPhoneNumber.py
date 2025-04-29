# Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.
# A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

# A newer attempt.
from typing import List
class Solution:
    def letterCombinations(self, digits: str) -> List[str]:
        if len(digits) == 0:
            return []
        
        map = {'2': 'abc', '3': 'def', '4': 'ghi', '5': 'jkl', '6': 'mno', '7': 'pqrs', '8': 'tuv', '9': 'wxyz'}
        self.ans = []
        def rec(idx: int, lst: list[str]):
            if idx == len(digits):
                self.ans.append(''.join(lst))
                return
            
            for char in map[digits[idx]]:
                lst.append(char)
                rec(idx + 1, lst)
                lst.pop()
        
        rec(0, [])
        return self.ans

# An older attempt. It is worse than my new attempt due to the immutability of strings.
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