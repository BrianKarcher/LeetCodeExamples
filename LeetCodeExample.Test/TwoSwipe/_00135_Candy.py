# There are n children standing in a line. Each child is assigned a rating value given in the integer array ratings.

# You are giving candies to these children subjected to the following requirements:

# Each child must have at least one candy.
# Children with a higher rating get more candies than their neighbors.
# Return the minimum number of candies you need to have to distribute the candies to the children.

from typing import List
class Solution:
    def candy(self, ratings: List[int]) -> int:
        ans = [1] * len(ratings)
        # from left to right
        for i in range(1, len(ratings)):
            if ratings[i] > ratings[i - 1]:
                ans[i] = ans[i - 1] + 1
        # from right to left
        for i in range(len(ratings) - 2, -1, -1):
            #print(f'checking {i}')
            if ratings[i] > ratings[i + 1]:
                n = max(ans[i], ans[i + 1] + 1)
                #print(f'set {i} to {n}')
                ans[i] = n

        rtn = 0
        for item in ans:
            #print(item)
            rtn += item
        return rtn