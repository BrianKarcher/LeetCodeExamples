# Given an array of integers arr, return true if the number of occurrences of each value in the array is unique or false otherwise.

from collections import Counter
class Solution:
    def uniqueOccurrences(self, arr: List[int]) -> bool:
        counter = Counter(arr)
        occs = set()
        for k,v in counter.items():
            if v in occs:
                return False
            occs.add(v)
        return True