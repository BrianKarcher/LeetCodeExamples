# Given an array of positive integers nums and a positive integer target, return the minimal length of a 
# subarray
#  whose sum is greater than or equal to target. If there is no such subarray, return 0 instead.


class Solution:
    def minSubArrayLen(self, target: int, nums: List[int]) -> int:
        sum = 0
        small = 999999
        l = 0
        for r in range(len(nums)):
            sum += nums[r]
            while sum >= target:
                small = min(small, r - l + 1)
                sum -= nums[l]
                l += 1
        return small if small != 999999 else 0



from typing import List
import sys
class Solution:
    def minSubArrayLen(self, target: int, nums: List[int]) -> int:
        sums = []
        sums.append(0)
        sums.append(nums[0])
        for i in range(1, len(nums)):
            sums.append(sums[-1] + nums[i])
        #print(f'{sums}')
        ans = sys.maxsize
        i1 = 0
        for i2 in range(len(sums)):
            while sums[i2] - sums[i1] >= target:
                #print(f'{sums[i2] - sums[i1]}')
                ans = min(ans, i2 - i1)
                i1 += 1
            #print(f'{i1} {i2}')

        return 0 if ans == sys.maxsize else ans