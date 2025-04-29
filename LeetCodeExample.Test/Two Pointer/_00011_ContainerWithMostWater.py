# You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

# Find two lines that together with the x-axis form a container, such that the container contains the most water.

# Return the maximum amount of water a container can store.

# Notice that you may not slant the container.

class Solution:
    def maxArea(self, height: List[int]) -> int:
        lo = 0
        hi = len(height) - 1
        maxi = 0
        while lo <= hi:
            area = min(height[lo], height[hi]) * (hi - lo)
            maxi = max(maxi, area)
            if height[lo] < height[hi]:
                lo = lo + 1
            else:
                hi = hi - 1
        return maxi