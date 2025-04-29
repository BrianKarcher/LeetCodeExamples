# Given a string s, sort it in decreasing order based on the frequency of the characters. The frequency of a character is the number of times it appears in the string.

# Return the sorted string. If there are multiple answers, return any of them.

from collections import defaultdict
class Solution:
    def frequencySort(self, s: str) -> str:
        dict = defaultdict(int)
        for c in s:
            dict[c] += 1
        sort = sorted(dict.items(), key = lambda x: -x[1])
        rtn = ''
        for k, v in sort:
            rtn += k * v
        return rtn