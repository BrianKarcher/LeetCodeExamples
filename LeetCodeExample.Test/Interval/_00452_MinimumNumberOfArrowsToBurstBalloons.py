# There are some spherical balloons taped onto a flat wall that represents the XY-plane. The balloons are represented as a 2D integer array points where points[i] = [xstart, xend] denotes a balloon whose horizontal diameter stretches between xstart and xend. You do not know the exact y-coordinates of the balloons.

# Arrows can be shot up directly vertically (in the positive y-direction) from different points along the x-axis. A balloon with xstart and xend is burst by an arrow shot at x if xstart <= x <= xend. There is no limit to the number of arrows that can be shot. A shot arrow keeps traveling up infinitely, bursting any balloons in its path.

# Given the array points, return the minimum number of arrows that must be shot to burst all balloons.

from typing import List
class Solution:
    def findMinArrowShots(self, points: List[List[int]]) -> int:
        points.sort()
        arrows = 1
        right = points[0][1]
        for start, end in points:
            # Overlapping baloons can be shot with a single arrow
            # This problem has a condition for overlapping baloons - they all need
            # to overlap with each other to consume one arrow.
            # ex:
            # -----------------------------------     < 1 big baloon
            # -------    -------      -----------   < 3 smaller baloons
            # The above takes three arrows.
            # We need to adjust the right index for each baloon added to the overlap.
            # To the smaller of the two
            if start <= right:
                right = min(right, end)
            else:
                right = end
                arrows += 1
        return arrows