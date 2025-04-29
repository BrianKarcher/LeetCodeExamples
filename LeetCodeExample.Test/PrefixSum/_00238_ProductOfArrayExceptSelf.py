# Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
# The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
# You must write an algorithm that runs in O(n) time and without using the division operation.

# Optimal - O(1) space
from typing import List
class Solution:
    def productExceptSelf(self, nums: List[int]) -> List[int]:
        ans = [1] * len(nums)
        # Left to right
        ans[0] = 1
        for i in range(1, len(nums)):
            ans[i] = nums[i - 1] * ans[i - 1]
        # print(ans)
        # Right to left
        m = 1
        for i in reversed(range(len(nums))):
            ans[i] = ans[i] * m
            m *= nums[i]
        return ans

from typing import List
class Solution:
    def productExceptSelf(self, nums: List[int]) -> List[int]:
        fromLeft = [1] * len(nums)
        fromLeft[0] = nums[0]
        for i in range(1, len(nums)):
            fromLeft[i] = fromLeft[i - 1] * nums[i]
        
        fromRight = [1] * len(nums)
        fromRight[-1] = nums[-1]
        for i in range(len(nums) - 2, -1, -1):
            fromRight[i] = fromRight[i + 1] * nums[i]
        
        ans = [0] * len(nums)
        for i in range(len(nums)):
            if i == 0:
                ans[i] = fromRight[i + 1]
            elif i == len(nums) - 1:
                ans[i] = fromLeft[i - 1]
            else:
                ans[i] = fromLeft[i - 1] * fromRight[i + 1]
        return ans