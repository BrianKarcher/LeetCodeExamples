# You are given an integer array nums consisting of n elements, and an integer k.
# Find a contiguous subarray whose length is equal to k that has the maximum average value and return this value. Any answer with a calculation error less than 10-5 will be accepted.

from typing import List
class Solution:
    def findMaxAverage(self, nums: List[int], k: int) -> float:
        l, r, s = 0, 0, 0
        # fill sum
        while r < k:
            s += nums[r]
            r += 1
        ans = s
        # Sliding window
        while r < len(nums):
            # Move left pointer
            s -= nums[l]
            l += 1
            # Move right pointer
            s += nums[r]
            r += 1
            ans = max(ans, s)
        return ans / k