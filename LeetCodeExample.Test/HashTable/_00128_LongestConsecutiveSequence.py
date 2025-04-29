# Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
# You must write an algorithm that runs in O(n) time.


# There's a better solution to this problem. It involves only starting from the left of a sequence and doesn't need a seen hashset.
# It also has much less code.
from typing import List
class Solution:
    def longestConsecutive(self, nums: List[int]) -> int:
        s = set()
        seen = set()
        for num in nums:
            s.add(num)
        
        ans = 0
        for num in nums:
            # We look for consecutive numbers in the hashset, and mark them as seen as we find them
            if num in seen:
                continue
            seen.add(num)
            count = 1
            # Go right
            current = num
            while current + 1 in s:
                count += 1
                current += 1
                seen.add(current)
            # Go left
            current = num
            while current - 1 in s:
                count += 1
                current -= 1
                seen.add(current)
            ans = max(ans, count)
        return ans