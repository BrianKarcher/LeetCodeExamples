# You are given two 0-indexed integer arrays nums1 and nums2 of equal length n and a positive integer k. You must choose a subsequence of indices from nums1 of length k.

# For chosen indices i0, i1, ..., ik - 1, your score is defined as:

# The sum of the selected elements from nums1 multiplied with the minimum of the selected elements from nums2.
# It can defined simply as: (nums1[i0] + nums1[i1] +...+ nums1[ik - 1]) * min(nums2[i0] , nums2[i1], ... ,nums2[ik - 1]).
# Return the maximum possible score.

# A subsequence of indices of an array is a set that can be derived from the set {0, 1, ..., n-1} by deleting some or no elements.

# My (wrong) answer used a sliding window

# Official answer
from typing import List
import heapq
class Solution:
    def maxScore(self, nums1: List[int], nums2: List[int], k: int) -> int:
        arr3 = []
        for i in range(len(nums1)):
            arr3.append((nums2[i], nums1[i]))
        arr3.sort(reverse = True)
        heap = []
        # Init heap
        for i in range(k):
            heapq.heappush(heap, arr3[i][1])

        adds = sum(heap)
        ans = adds * arr3[k - 1][0]
        # Do sliding window
        for i in range(k, len(arr3)):
            adds += arr3[i][1]
            pop = heapq.heappushpop(heap, arr3[i][1])
            adds -= pop
            # print(f'idx: {r}, adds: {adds}, prod: {prod}')
            ans = max(ans, adds * arr3[i][0])
        return ans