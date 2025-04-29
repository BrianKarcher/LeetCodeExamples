# Given an array of integers nums, calculate the pivot index of this array.
# The pivot index is the index where the sum of all the numbers strictly to the left of the index is equal to the sum of all the numbers strictly to the index's right.
# If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.
# Return the leftmost pivot index. If no such index exists, return -1.

class Solution(object):
    def pivotIndex(self, nums):
        S = sum(nums)
        leftsum = 0
        for i, x in enumerate(nums):
            if leftsum == (S - leftsum - x):
                return i
            leftsum += x
        return -1


from typing import List
class Solution:
    def pivotIndex(self, nums: List[int]) -> int:
        sumR = [0] * len(nums)
        for i in range(1, len(nums)):
            sumR[i] = sumR[i - 1] + nums[i - 1]
        sumL = [0] * len(nums)
        for i in range(len(nums) - 2, -1, -1):
            sumL[i] = sumL[i + 1] + nums[i + 1]
        for i in range(len(nums)):
            if sumR[i] == sumL[i]:
                return i
        return -1