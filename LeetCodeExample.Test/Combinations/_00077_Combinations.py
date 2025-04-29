# Given two integers n and k, return all possible combinations of k numbers chosen from the range [1, n].
# You may return the answer in any order.

from typing import List
class Solution:
    def combine(self, n: int, k: int) -> List[List[int]]:
        ans = []
        def rec(i: int, lst: list):
            # Base Case
            if i > n:
                return
            if len(lst) > k:
                return
            if len(lst) == k:
                ans.append(list(lst))
                return
            for j in range(i + 1, n + 1):
                lst.append(j)
                rec(j, lst)
                lst.pop()
        rec(0, [])
        return ans