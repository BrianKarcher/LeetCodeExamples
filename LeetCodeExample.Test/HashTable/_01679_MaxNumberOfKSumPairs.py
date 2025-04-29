# You are given an integer array nums and an integer k.
# In one operation, you can pick two numbers from the array whose sum equals k and remove them from the array.
# Return the maximum number of operations you can perform on the array.

from typing import List
from collections import Counter
class Solution:
    def maxOperations(self, nums: List[int], k: int) -> int:
        counter = Counter()
        ans = 0
        for num in nums:
            corr = k - num
            if counter[corr] > 0:
                ans += 1
                counter[corr] -= 1
                # Notice that since we added this pair, we don't add this number to the counter
            else:
                counter[num] += 1
        return ans