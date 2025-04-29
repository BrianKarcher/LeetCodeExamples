# Given an array of strings strs, group the anagrams together. You can return the answer in any order.

# This is optimal because breaking a string into letter counts is faster than a sort (N vs N*logN)
from typing import List
from collections import defaultdict
class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        d = defaultdict(list[str])
        # Anagrams have the same letter counts
        # Dictionary key is the tuple of the letter counts
        for s in strs:
            letters = [0] * 26
            for c in s:
                letters[ord(c) - ord('a')] += 1
            d[tuple(letters)].append(s)
        return list(d.values())
    
####################

from typing import List
from collections import defaultdict
class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        ans = defaultdict(list)
        for s in strs:
            ans[tuple(sorted(s))].append(s)
        return list(ans.values())

################
# Initial naive solution
class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        if not str:
            return [[]]
        if len(strs) == 1:
            return [strs]
        # Map sorted items to their original indices
        map = [(''.join(sorted(strs[i])), i) for i in range(len(strs))]
        map.sort()
        # print(f'{map}')
        prev = None
        ans = []
        for (key, idx) in map:
            if key != prev:
                prev = key
                ans.append([])
            ans[-1].append(strs[idx])
        return ans