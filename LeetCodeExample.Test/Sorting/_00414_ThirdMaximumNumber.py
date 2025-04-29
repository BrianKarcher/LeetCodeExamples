# Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

class Solution:
    def thirdMax(self, nums: List[int]) -> int:
        nums.sort(reverse = True)
        hash = set()
        for i in range(len(nums)):
            hash.add(nums[i])
            if len(hash) == 3:
                return nums[i]
        return nums[0]