# Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.

from typing import List
class Solution:
    def containsNearbyDuplicate(self, nums: List[int], k: int) -> bool:
        s = set()
        l = 0
        for r in range(len(nums)):
            if r - l > k:
                s.remove(nums[l])
                l += 1
            if nums[r] in s:
                return True
            s.add(nums[r])
        return False