# Suppose LeetCode will start its IPO soon. In order to sell a good price of its shares to Venture Capital, LeetCode would like to work on some projects to increase its capital before the IPO. Since it has limited resources, it can only finish at most k distinct projects before the IPO. Help LeetCode design the best way to maximize its total capital after finishing at most k distinct projects.
# You are given n projects where the ith project has a pure profit profits[i] and a minimum capital of capital[i] is needed to start it.
# Initially, you have w capital. When you finish a project, you will obtain its pure profit and the profit will be added to your total capital.
# Pick a list of at most k distinct projects from given projects to maximize your final capital, and return the final maximized capital.
# The answer is guaranteed to fit in a 32-bit signed integer.

from typing import List
import heapq
class Solution:
    def findMaximizedCapital(self, k: int, w: int, profits: List[int], capital: List[int]) -> int:
        combined = [] * len(profits)
        for i in range(len(profits)):
            combined.append((capital[i], profits[i]))
        # Sort so we only have to go through the list once
        # Sort by capital
        combined.sort()
        # Profits can only go higher, so let's have a pointer into sorted combined for the 
        # current position. This pointer can only move to the right as it adds items to the heap.
        # The heap can never grow larger than k.
        # Use a max-heap
        heap = []
        ptr = 0
        for i in range(k): #i < len(combined):
            # Add all projects to heap that we can afford
            while ptr < len(combined) and combined[ptr][0] <= w:
                heapq.heappush(heap, -combined[ptr][1])
                ptr += 1
            # Pluck most profitable project
            # print(f'{heap}')

            # We cannot afford more projects
            if not heap:
                return w
            w += -heapq.heappop(heap)
            k -= 1
        return w