# 875

# Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. The guards have gone and will come back in h hours.
# Koko can decide her bananas-per-hour eating speed of k. Each hour, she chooses some pile of bananas and eats k bananas from that pile. If the pile has less than k bananas, she eats all of them instead and will not eat any more bananas during this hour.
# Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.
# Return the minimum integer k such that she can eat all the bananas within h hours.

import math
from typing import List
class Solution:
    def minEatingSpeed(self, piles: List[int], h: int) -> int:
        l = 1
        r = max(piles)
        # Binary search by number of bananas eaten per hour
        while l <= r:
            # mid is the amount of bananas eating this hour
            mid = (l + r) // 2
            chunks = 0
            # print(f'l: {l}, r: {r}, mid: {mid}')
            for pile in piles:
                chunks += math.ceil(pile / mid)
            # print(f'chunks: {chunks}')
            if chunks > h: # Eating too little? Eat more
                l = mid + 1
            else:
                r = mid - 1
        return l