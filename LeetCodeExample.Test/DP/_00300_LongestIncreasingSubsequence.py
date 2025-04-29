# Given an integer array nums, return the length of the longest strictly increasing 
# subsequence
# .

from typing import List
class Solution:
    def lengthOfLIS(self, nums: List[int]) -> int:
        if len(nums) <= 1:
            return 1
        dp = [1] * len(nums)
        for i in range(len(nums) - 2, -1, -1):
            for j in range(i + 1, len(nums)):
                if nums[j] <= nums[i]:
                    continue
                dp[i] = max(dp[i], dp[j] + 1)

        ans = 0
        for d in dp:
            ans = max(ans, d)
        return ans