# You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the start and the end of the ith interval and intervals is sorted in ascending order by starti. You are also given an interval newInterval = [start, end] that represents the start and end of another interval.
# Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have any overlapping intervals (merge overlapping intervals if necessary).
# Return intervals after the insertion.
# Note that you don't need to modify intervals in-place. You can make a new array and return it.

from typing import List
class Solution:
    def insert(self, intervals: List[List[int]], newInterval: List[int]) -> List[List[int]]:
        if not intervals:
            return [newInterval]
        START = 0
        END = 1
        
        ans = []
        i = 0
        # Do before
        while i < len(intervals) and intervals[i][END] < newInterval[START]:
            ans.append(intervals[i])
            i += 1
        
        # Do merge
        while i < len(intervals) and intervals[i][START] <= newInterval[END]:
            newInterval[START] = min(intervals[i][START], newInterval[START])
            newInterval[END] = max(intervals[i][END], newInterval[END])
            i += 1
        ans.append(newInterval)

        # Do after
        while i < len(intervals):
            ans.append(intervals[i])
            i += 1

        return ans
    

    
from typing import List
class Solution:
    def insert(self, intervals: List[List[int]], newInterval: List[int]) -> List[List[int]]:
        if len(intervals) == 0:
            return [newInterval]
        START = 0
        END = 1

        def search() -> int:
            # Find insertion point
            l = 0
            r = len(intervals) - 1
            while l <= r:
                mid = (l + r) // 2
                if intervals[mid][START] == newInterval[START]:
                    return mid
                if intervals[mid][END] < newInterval[START]:
                    l = mid + 1
                else:
                    r = mid - 1
            return l
        
        ans = []
        pos = search()
        # We are inserting the new interval at the sorted position
        intervals.insert(pos, newInterval)
        # Then we are merging any overlaps

        current = intervals[0]
        for i in range(1, len(intervals)):
            interval = intervals[i]
            if current[END] < interval[START]:
                # No overlap
                ans.append(current)
                current = interval
            else:
                current = [min(current[START], interval[START]), max(current[END], interval[END])]
        ans.append(current)
        return ans