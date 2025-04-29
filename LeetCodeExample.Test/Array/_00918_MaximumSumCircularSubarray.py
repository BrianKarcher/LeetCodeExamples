# Given a circular integer array nums of length n, return the maximum possible sum of a non-empty subarray of nums.

# A circular array means the end of the array connects to the beginning of the array. Formally, the next element of nums[i] is nums[(i + 1) % n] and the previous element of nums[i] is nums[(i - 1 + n) % n].

# A subarray may only include each element of the fixed buffer nums at most once. Formally, for a subarray nums[i], nums[i + 1], ..., nums[j], there does not exist i <= k1, k2 <= j with k1 % n == k2 % n.

# Uses traditional Kadane's Algorith to find an inner max sum
# In case the max sum involves a cycle, we use a reverse Kadane's Algorithm to find the min sum and subtract that from the total sum to find
# the max sum subarray.
from typing import List
class Solution:
    def maxSubarraySumCircular(self, nums: List[int]) -> int:
        curMax = 0
        curMin = 0
        maxSum = nums[0]
        minSum = nums[0]
        totalSum = 0
        for num in nums:
            curMax = max(curMax, 0) + num
            maxSum = max(maxSum, curMax)

            curMin = min(curMin, 0) + num
            minSum = min(minSum, curMin)
            totalSum += num
        
        if minSum == totalSum:
            return maxSum

        return max(maxSum, totalSum - minSum)