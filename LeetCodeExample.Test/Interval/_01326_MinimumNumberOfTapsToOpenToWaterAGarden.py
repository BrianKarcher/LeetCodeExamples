# There is a one-dimensional garden on the x-axis. The garden starts at the point 0 and ends at the point n. (i.e., the length of the garden is n).
# There are n + 1 taps located at points [0, 1, ..., n] in the garden.
# Given an integer n and an integer array ranges of length n + 1 where ranges[i] (0-indexed) means the i-th tap can water the area [i - ranges[i], i + ranges[i]] if it was open.
# Return the minimum number of taps that should be open to water the whole garden, If the garden cannot be watered return -1.

from typing import List
class Solution:
    def minTaps(self, n: int, ranges: List[int]) -> int:
        # Create intervals
        intervals = []
        for i in range(n + 1):
            if ranges[i] == 0:
                continue
            intervals.append([max(0, i - ranges[i]), i + ranges[i]])
        # print(f'{intervals}')
        if not intervals:
            return -1
        intervals.sort()
        # print(f'{intervals}')

        interval = intervals[0]
        i = 0
        ans = 1
        while i < len(intervals) and interval[1] <= n:
            # Merge intervals starting at same spot
            # if i < len(intervals) - 1:
            #     print(f'{interval} {intervals[i + 1]}')
            while i < len(intervals) - 1 and interval[0] == intervals[i + 1][0]:
                i += 1
                interval[1] = max(interval[1], intervals[i][1])
            # print(f'{interval} {i}')
            if interval[1] >= n:
                return ans
            # Find all intersecting intervals, get the one that goes furthest to the right
            newInterval = None
            while i < len(intervals) and intervals[i][0] <= interval[1]:
                # print(f'{intervals[i]}')
                # intersects.append(interval[i])
                if not newInterval or intervals[i][1] > newInterval[1]:
                    newInterval = intervals[i]
                i += 1
            if not newInterval:
                return -1
            # print(f'Setting new interval to {newInterval}')
            interval = newInterval
            ans += 1
        return ans if interval[1] >= n else -1