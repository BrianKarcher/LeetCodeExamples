# Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.

# In other words, return true if one of s1's permutations is the substring of s2.

from collections import Counter
class Solution:
    def checkInclusion(self, s1: str, s2: str) -> bool:
        if len(s1) > len(s2):
            return False

        counter = Counter(s1)
        self.count = len(s1)

        def sub(char: str):
            if counter[char] > 0:
                self.count -= 1
            counter[char] -= 1

        def add(char: str):
            counter[char] += 1
            if counter[char] > 0:
                self.count += 1

        # Initialize sliding window
        for i in range(len(s1)):
            if s2[i] not in counter:
                continue
            sub(s2[i])
        if self.count == 0:
            return True
        l = 0
        for r in range(len(s1), len(s2)):
            # Add the left back to counter
            if s2[l] in counter:
                add(s2[l])
            l += 1
            # Subtract right from counter
            if s2[r] in counter:
                sub(s2[r])
            if self.count == 0:
                return True
        return False