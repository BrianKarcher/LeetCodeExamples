# You are given a sorted unique integer array nums.
# A range [a,b] is the set of all integers from a to b (inclusive).
# Return the smallest sorted list of ranges that cover all the numbers in the array exactly. That is, each element of nums is covered by exactly one of the ranges, and there is no integer x such that x is in one of the ranges but not in nums.
# Each range [a,b] in the list should be output as:

class Solution:
    def summaryRanges(self, nums: List[int]) -> List[str]:
        if nums == None:
            return None
        rtn = []
        r = 0
        while r < len(nums):
            start = nums[r]
            while r + 1 < len(nums) and nums[r] + 1 == nums[r + 1]:
                r += 1
            if start != nums[r]:
                rtn.append(f"{start}->{nums[r]}")
            else:
                rtn.append(f"{start}")
            r += 1
        return rtn