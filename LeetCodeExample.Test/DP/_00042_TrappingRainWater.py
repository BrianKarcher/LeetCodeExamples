# Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.

class Solution:
    def trap(self, height: List[int]) -> int:
        left = [0] * len(height)
        right = [0] * len(height)

        maxl = 0
        for i in range(len(height)):
            maxl = max(maxl, height[i])
            left[i] = maxl

        maxr = 0
        for i in reversed(range(len(height))):
            maxr = max(maxr, height[i])
            right[i] = maxr

        area = 0
        for i in range(len(height)):
            area = area + (min(left[i], right[i]) - height[i])

        return area