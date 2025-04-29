# Given an integer array nums, return the length of the longest strictly increasing 
# subsequence
# .

from typing import List
import bisect
class Solution:
    def lengthOfLIS(self, nums: List[int]) -> int:
        sub = []
        for num in nums:
            mid = bisect.bisect_left(sub, num)
            if mid == len(sub):
                sub.append(num)
            else:
                sub[mid] = num
        return len(sub)
    
from typing import List
import bisect
class Solution:
    def lengthOfLIS(self, nums: List[int]) -> int:
        sub = []

        def search(num: int) -> int:
            l = 0
            r = len(sub) - 1
            while l < r:
                mid = (l + r) // 2
                if sub[mid] == num:
                    return mid
                elif sub[mid] < num:
                    l = mid + 1
                else:
                    r = mid
            return l

        for num in nums:
            mid = bisect.bisect_left(sub, num)
            if mid == len(sub):
                sub.append(num)
            else:
                sub[mid] = num
        return len(sub)

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