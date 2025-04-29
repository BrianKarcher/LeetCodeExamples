class Solution:
    def eraseOverlapIntervals(self, intervals: List[List[int]]) -> int:
        

# from typing import List
# class Solution:
#     def eraseOverlapIntervals(self, intervals: List[List[int]]) -> int:
#         if not intervals:
#             return 0
#         intervals.sort()
#         tempOverlapped: List[int] = []
#         overlaps: List[set] = []
#         for i in range(len(intervals)):
#             tempOverlapped = [item for item in tempOverlapped if intervals[item][1] > intervals[i][0]]
#             hash = set()
#             for temp in tempOverlapped:
#                 hash.add(temp)
#             overlaps.append(hash)
#             #overlaps[]
#             tempOverlapped.append(i)
        
#         overlaps.sort(reverse = True)
#         count = 0
#         # We greedily remove the intervals with the most overlaps first
#         for overlap in overlaps:
#             if not overlap:
#                 continue
#             count += 1
#             for item in overlap:
#                 overlaps[item].remove()