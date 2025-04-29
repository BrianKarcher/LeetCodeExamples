# You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

# Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

class Solution:
    def rob(self, nums: List[int]) -> int:
        if len(nums) == 1:
            return nums[0]
        if len(nums) == 2:
            return max(nums[0], nums[1])
        dp = [0] * len(nums)
        #dp = [[0 for i in range(2)] for i in range(len(nums))]
        #dp[0][0] = nums[0]
        #dp[1][0] = nums[1]
        #dp[1][1] = nums[0]
        dp[0] = nums[0]
        dp[1] = max(nums[0], nums[1])

        for i in range(2, len(nums)):
            dp[i] = max(dp[i - 2] + nums[i], dp[i - 1])
            #dp[i][0] = max(dp[i - 2][0], dp[i - 2][1]) + nums[i]
            #dp[i][1] = max(dp[i - 1][0], dp[i - 1][1])
        return dp[len(nums) - 1]