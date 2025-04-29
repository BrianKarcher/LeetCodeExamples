# Given an integer array nums, find the 
# subarray
#  with the largest sum, and return its sum.

from typing import List
import sys
class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        sum = 0
        ans = -sys.maxsize
        for num in nums:
            if sum < 0:
                sum = 0
            sum += num
            ans = max(ans, sum)
        return ans