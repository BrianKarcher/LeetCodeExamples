# Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

# The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the 
# frequency
#  of at least one of the chosen numbers is different.

# The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.
 
from typing import List
class Solution:
    def combinationSum(self, candidates: List[int], target: int) -> List[List[int]]:
        ans = []
        def rec(idx: int, lst: list, t):
            if t < 0:
                return
            if t == 0:
                ans.append(list(lst))
                return
            # We can repeat the same index infinitey times.
            # However, if we prevent the index from going backwards
            # We don't have to deal with duplicates. e.g. [3, 2] would
            # create output [[3, 2]] and not [[3, 2], [2, 3]]
            for i in range(idx, len(candidates)):
                candidate = candidates[i]
                lst.append(candidate)
                rec(i, lst, t - candidate)
                lst.pop()
        rec(0, [], target)
        return ans