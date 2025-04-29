# Given an integer array nums, return true if there exists a triple of indices (i, j, k) such that i < j < k and nums[i] < nums[j] < nums[k]. If no such indices exists, return false.

from typing import List
class Solution:
    def increasingTriplet(self, nums: List[int]) -> bool:
        first = float("inf")
        second = float("inf")
        for n in nums:
            if n < first:
                first = n
            elif first < n < second:
                second = n
            elif n > second:
                return True
        return False