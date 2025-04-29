# Given an array nums of size n, return the majority element.

# The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.

class Solution:
    def majorityElement(self, nums: List[int]) -> int:
        candidate = -1
        votes = 0
        for num in nums:
            if votes == 0:
                candidate = num
                votes += 1
            else:
                if num == candidate:
                    votes += 1
                else:
                    votes -= 1
        return candidate


class Solution:
    def majorityElement(self, nums: List[int]) -> int:
        candidate = -1
        votes = 0
        for num in nums:
            if votes == 0:
                candidate = num
                votes += 1
            else:
                if num == candidate:
                    votes += 1
                else:
                    votes -= 1
        return candidate