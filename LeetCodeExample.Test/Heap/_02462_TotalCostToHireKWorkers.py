# You are given a 0-indexed integer array costs where costs[i] is the cost of hiring the ith worker.

# You are also given two integers k and candidates. We want to hire exactly k workers according to the following rules:

# You will run k sessions and hire exactly one worker in each session.
# In each hiring session, choose the worker with the lowest cost from either the first candidates workers or the last candidates workers. Break the tie by the smallest index.
# For example, if costs = [3,2,7,7,1,2] and candidates = 2, then in the first hiring session, we will choose the 4th worker because they have the lowest cost [3,2,7,7,1,2].
# In the second hiring session, we will choose 1st worker because they have the same lowest cost as 4th worker but they have the smallest index [3,2,7,7,2]. Please note that the indexing may be changed in the process.
# If there are fewer than candidates workers remaining, choose the worker with the lowest cost among them. Break the tie by the smallest index.
# A worker can only be chosen once.
# Return the total cost to hire exactly k workers.


# My solution
from typing import List
import heapq
class Solution:
    def totalCost(self, costs: List[int], k: int, candidates: int) -> int:
        l = 0
        r = len(costs) - 1
        heap = []
        # Init heap
        while l <= r and l < candidates:
            if l == r:
                heapq.heappush(heap, (costs[l], l))
            else:
                heapq.heappush(heap, (costs[l], l))
                heapq.heappush(heap, (costs[r], r))
            l += 1
            r -= 1
        
        ans = 0
        while k > 0 and l <= r:
            # Grab the cheapest
            cost, idx = heapq.heappop(heap)
            ans += cost
            k -= 1
            # We need to move one of the two pointers
            if idx < l:
                # Move the left pointer, add to heap
                heapq.heappush(heap, (costs[l], l))
                l += 1
            else:
                heapq.heappush(heap, (costs[r], r))
                r -= 1
        
        # Get any remaining k
        while k > 0:
            cost, idx = heapq.heappop(heap)
            ans += cost
            k -= 1
        
        return ans