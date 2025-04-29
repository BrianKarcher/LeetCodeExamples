# Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.

from typing import List
from collections import deque
class Solution:
    def rotate(self, nums: List[int], k: int) -> None:
        """
        Do not return anything, modify nums in-place instead.
        """
        k %= len(nums)
        q = deque()
        # Fill up the queue to k
        for i in range(k):
            q.append(nums[i])
        count = 0
        i = k
        while count < len(nums):
            q.append(nums[i])
            nums[i] = q.popleft()
            i += 1
            count += 1
            if i >= len(nums):
                i = 0