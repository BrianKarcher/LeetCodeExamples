# Given a binary array nums, you should delete one element from it.
# Return the size of the longest non-empty subarray containing only 1's in the resulting array. Return 0 if there is no such subarray.

from typing import List
class Solution:
    def longestSubarray(self, nums: List[int]) -> int:
        k = 1
        ans = 0
        l = 0
        for r in range(len(nums)):
            if nums[r] == 0:
                k -= 1
                while k < 0:
                    if nums[l] == 0:
                        k += 1
                    l += 1
            ans = max(ans, (r - l) + (0 if k == 0 else 1))
            # print(f'{l} {r} {k} {ans}')
        if ans == len(nums):
            # Must delete something, delete a 1
            return ans - 1
        return ans
