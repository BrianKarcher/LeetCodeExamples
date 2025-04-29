# Given an array nums of distinct integers, return all the possible 
# permutations
# . You can return the answer in any order.

from typing import List
class Solution:
    def permute(self, nums: List[int]) -> List[List[int]]:
        ans = []
        def rec(lst: list, seen: set):
            if len(lst) == len(nums):
                ans.append(list(lst))
                return
            for num in nums:
                if num in seen:
                    continue
                seen.add(num)
                lst.append(num)
                rec(lst, seen)
                seen.remove(num)
                lst.pop()
        
        rec([], set())
        return ans