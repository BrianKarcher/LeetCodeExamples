
from typing import List
class Solution:
    def subarraysDivByK(self, nums: List[int], k: int) -> int:
        counts = {0: 1} # Init dictionary with 1 at 0
        answer = 0
        prefixSum = 0
        for num in nums:
            prefixSum = (prefixSum + num % k + k) % k # the double modulo is in case
                                                      # prefixSum + num % is is negative
            answer += counts.get(prefixSum, 0)
            #print(prefixSum)
            counts[prefixSum] = counts.get(prefixSum, 0) + 1
        return answer