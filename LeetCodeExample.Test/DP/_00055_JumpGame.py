# You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.
# Return true if you can reach the last index, or false otherwise.


# O(n)
from typing import List
class Solution:
    def canJump(self, nums: List[int]) -> bool:
        lastPos = len(nums) - 1
        for i in range(len(nums) - 1, -1, -1):
            if nums[i] + i >= lastPos:
                lastPos = i
        return lastPos == 0
    

# O(n^2)
from typing import List
class Solution:
    def canJump(self, nums: List[int]) -> bool:
        if len(nums) == 1:
            return True
        dp = [False] * len(nums)
        dp[-1] = True
        for i in range(len(nums) - 2, -1, -1):
            for j in range(i + 1, min(len(nums) - 1, nums[i] + i) + 1):
                if dp[j]:
                    dp[i] = True
                    break
        # print(f'{dp}')
        return dp[0]