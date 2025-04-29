# Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane, return the maximum number of points that lie on the same straight line.

from typing import List
from collections import Counter
class Solution:
    def maxPoints(self, points: List[List[int]]) -> int:
        if len(points) == 1:
            return 1
        
        ans = 2

        # Two lines are the same if they have the same Y-intercept
        # EXCEPT for vertical lines, store vertical lines by their X intercept
        # Line equation: y = mx + b
        # So, to find Y intercept (b), b = y - mx

        # CORRECTION! Doing the calculation side of the outer For loop, we just need the slopes
        # from point i to the various points j
        # No need for Y-Int

        # For point pairs we need to compare all points against all points. O(n^2) :(
        for i in range(len(points)):
            slopes = Counter()
            for j in range(i + 1, len(points)):
                slopes[self.GetSlope(points[i], points[j])] += 1
            for slope, count in slopes.items():
                ans = max(ans, count + 1)

        # The reason for the +1 is because we counted the number of lines, not points.
        return ans
    
    def GetSlope(self, point1, point2):
        if point1[0] == point2[0]:
            return float('inf')
        else:
            return (point1[1] - point2[1]) / (point1[0] - point2[0])