# Given an array of integers heights representing the histogram's bar height where the width of each bar is 1, return the area of the largest rectangle in the histogram.

from typing import List
class Solution:
    def largestRectangleArea(self, heights: List[int]) -> int:
        maxArea = 0
        s = []
        s.append(-1)
        for i in range(len(heights)):
            # Have we gone down in height?
            while s[-1] != -1 and heights[s[-1]] >= heights[i]:
                currentSize = heights[s.pop()]
                currentWidth = i - s[-1] - 1
                maxArea = max(maxArea, currentSize * currentWidth)
            s.append(i)
        
        # scrub items from right
        while s[-1] != -1:
            currentSize = heights[s.pop()]
            currentWidth = len(heights) - s[-1] - 1
            maxArea = max(maxArea, currentSize * currentWidth)
        return maxArea

# Brute force. Works but gives TLE.
class Solution:
    def largestRectangleArea(self, heights: List[int]) -> int:
        maxArea = 0
        for i in range(len(heights)):
            size = heights[i]
            # find next smaller element on both sides
            li, ri = i, i
            # go left
            for j in range(i - 1, -1, -1):
                if heights[j] >= heights[i]:
                    li = j
                else:
                    break
            
            # go right
            for j in range(i + 1, len(heights)):
                if heights[j] >= heights[i]:
                    ri = j
                else:
                    break
            # print(f'{li}, {ri}, {size}')
            maxArea = max(maxArea, (ri - li + 1) * size)
        return maxArea