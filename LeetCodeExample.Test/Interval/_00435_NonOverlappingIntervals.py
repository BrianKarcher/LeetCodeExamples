# Given an array of intervals intervals where intervals[i] = [starti, endi], return the minimum number of intervals you need to remove to make the rest of the intervals non-overlapping.
# Note that intervals which only touch at a point are non-overlapping. For example, [1, 2] and [2, 3] are non-overlapping.

# Optimal Solution
class Solution:
    def eraseOverlapIntervals(self, intervals: List[List[int]]) -> int:
        intervals.sort(key = lambda x: x[1])
        ans = 0
        k = -inf
        
        for x, y in intervals:
            if x >= k:
                # Case 1
                k = y
            else:
                # Case 2
                ans += 1
        
        return ans

# My solution
from typing import List
class Solution:
    def eraseOverlapIntervals(self, intervals: List[List[int]]) -> int:
        sortedIntervals = []
        # We are sorting by the end of the interval
        # Makes it easier to find overlaps when going left to right
        for interval in intervals:
            sortedIntervals.append((interval[1], interval[0]))
        sortedIntervals.sort() # This makes it n log n
        # print(sortedIntervals)
        idx = 0
        # The pos will continue through the range to the right.
        pos = 0 # float('-inf')
        ans = 0
        while idx < len(sortedIntervals):
            # We found the next optimal interval (it ends earliest)
            pos = sortedIntervals[idx][0]
            idx += 1
            # Remove any interval that overlaps with it
            # Check for overlap if the start is before the other interval's end
            while idx < len(sortedIntervals) and sortedIntervals[idx][1] < pos:
                ans += 1
                idx += 1
        return ans