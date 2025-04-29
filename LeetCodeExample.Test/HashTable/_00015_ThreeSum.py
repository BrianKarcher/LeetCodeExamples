# Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
# Notice that the solution set must not contain duplicate triplets.

from typing import List
class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        ans = []
        def twoSum(i: int):
            seen = set()
            j = i + 1
            while j < len(nums):
                complement = -nums[i] - nums[j]
                if complement in seen:
                    ans.append([nums[i], nums[j], complement])
                    # Skip duplicates by incrementing j to the next numerical value
                    while j + 1 < len(nums) and nums[j] == nums[j + 1]:
                        j += 1
                seen.add(nums[j])
                j += 1
        nums.sort()
        for i in range(len(nums)):
            if nums[i] > 0:
                break
            if i == 0 or nums[i] != nums[i - 1]:
                twoSum(i)
        return ans