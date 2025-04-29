# You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed. All houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. Meanwhile, adjacent houses have a security system connected, and it will automatically contact the police if two adjacent houses were broken into on the same night.

# Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

class Solution:
    def rob(self, nums: List[int]) -> int:
        def doRob(start, end):
            memo = [0] * (end - start + 1)
            # One extra space used to remove edge cases and if statements
            memo[0] = 0
            memo[1] = nums[start]
            for i in range(2, end - start + 1):
                memo[i] = max(memo[i - 1], memo[i - 2] + nums[start + i - 1])
            return memo[-1]
        
        if len(nums) == 1:
            return nums[0]

        return max(doRob(0, len(nums) - 1), doRob(1, len(nums)))