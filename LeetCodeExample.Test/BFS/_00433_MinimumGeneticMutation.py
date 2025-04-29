# A gene string can be represented by an 8-character long string, with choices from 'A', 'C', 'G', and 'T'.

# Suppose we need to investigate a mutation from a gene string startGene to a gene string endGene where one mutation is defined as one single character changed in the gene string.

# For example, "AACCGGTT" --> "AACCGGTA" is one mutation.
# There is also a gene bank bank that records all the valid gene mutations. A gene must be in bank to make it a valid gene string.

# Given the two gene strings startGene and endGene and the gene bank bank, return the minimum number of mutations needed to mutate from startGene to endGene. If there is no such a mutation, return -1.

# Note that the starting point is assumed to be valid, so it might not be included in the bank.

from typing import List
from collections import deque
class Solution:
    def minMutation(self, startGene: str, endGene: str, bank: List[str]) -> int:
        def diff(a: str, b: str) -> int:
            count = 0
            for i in range(8):
                if a[i] != b[i]:
                    count += 1
            return count
        
        if startGene == endGene:
            return 0
        q = deque()
        q.append(startGene)
        ans = 0
        seen = set()
        seen.add(startGene)
        while q:
            ans += 1
            count = len(q)
            for i in range(count):
                item = q.popleft()
                for b in bank:
                    if b in seen:
                        continue
                    if diff(item, b) == 1:
                        if b == endGene:
                            return ans
                        q.append(b)
                        seen.add(b)
        return -1