# Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

# Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

# Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
# Return k.

from typing import List
class Solution:
    def removeDuplicates(self, nums: List[int]) -> int:
        ans = 0
        l = 0
        r = 0
        while l < len(nums) and r < len(nums):
        #for l in range(1, len(nums)):
            nums[l] = nums[r]
            l += 1
            r += 1
            ans += 1
            while r < len(nums) and nums[r] == nums[r - 1]:
                # find next unique value
                r += 1
        return ans