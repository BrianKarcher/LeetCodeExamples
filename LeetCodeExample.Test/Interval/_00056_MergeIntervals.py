# Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.

from typing import List
class Solution:
    def merge(self, intervals: List[List[int]]) -> List[List[int]]:
        if not intervals or len(intervals) == 1:
            return intervals

        START = 0
        END = 1
        ans = []
        intervals.sort()
        # print(f'{intervals}')
        current = intervals[0] # We only need to sort by START. END is not necessary since it will overlap if the START is the same.
        for i in range(1, len(intervals)):
            interval = intervals[i]
            if current[END] < interval[START]:
                ans.append(current)
                current = interval
            else:
                current[END] = max(current[END], interval[END])
        ans.append(current)
        return ans