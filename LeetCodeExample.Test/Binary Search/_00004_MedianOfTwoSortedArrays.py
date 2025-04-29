# Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
# The overall run time complexity should be O(log (m+n)).

# This is not optimal. It runs in O(n + m) time, and uses O(n + m) space.
# It does not use Binary Search. It is a merge sort + find median.
from typing import List
class Solution:
    def findMedianSortedArrays(self, nums1: List[int], nums2: List[int]) -> float:
        merged = []
        i1 = 0
        i2 = 0
        while i1 < len(nums1) and i2 < len(nums2):
            if nums1[i1] < nums2[i2]:
                merged.append(nums1[i1])
                i1 += 1
            else:
                merged.append(nums2[i2])
                i2 += 1
        while i1 < len(nums1):
            merged.append(nums1[i1])
            i1 += 1
        while i2 < len(nums2):
            merged.append(nums2[i2])
            i2 += 1
        print(merged)
        mid = len(merged) // 2
        if len(merged) % 2 == 1: # Is odd
            return merged[mid]
        else:
            return (merged[mid - 1] + merged[mid ]) / 2