from collections import defaultdict
import sys
class Solution:
    def getMoneyAmount(self, n: int) -> int:
        #map = defaultdict(int)
        @lru_cache(None)
        def rec(l, r) -> int:
            if l >= r:
                return 0
            #if (l, r) in map:
            #    return map[(l, r)]
            val = sys.maxsize
            # find best number to pick. The number is a pivot point
            for i in range(l, r + 1):
                # left of pivot
                vall = rec(l, i - 1) + i # Cost on the left side, if pivot is not a secret number
                valr = rec(i + 1, r) + i # Cost on the right side, if pivot is not a secret number
                cost = max(vall, valr) # The cost is the maximum between the left side and the right side
                val = min(val, cost) # Choose pivot which will cause minimum cost
            #print(f'setting ({l},{r}) to {val}')
            #map[(l, r)] = val
            return val
        ans = rec(1,n)
        #for k,v in map:
        #    print(f"{k}, {v}")
        return ans