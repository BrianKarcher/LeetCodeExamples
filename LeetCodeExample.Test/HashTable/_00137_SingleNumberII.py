# Given an integer array nums where every element appears three times except for one, which appears exactly once. Find the single element and return it.
# You must implement a solution with a linear runtime complexity and use only constant extra space.

class Solution:
    def singleNumber(self, nums: List[int]) -> int:

        # Initialize seen_once and seen_twice to 0
        seen_once = seen_twice = 0

        # Iterate through nums
        for num in nums:
            # Update using derived equations
            seen_once = (seen_once ^ num) & (~seen_twice)
            seen_twice = (seen_twice ^ num) & (~seen_once)

        # Return integer which appears exactly once
        return seen_once

# This is not the constant space solution.
from typing import List
from collections import Counter
class Solution:
    def singleNumber(self, nums: List[int]) -> int:
        counter = Counter(nums)
        for key,val in counter.items():
            if val == 1:
                return key