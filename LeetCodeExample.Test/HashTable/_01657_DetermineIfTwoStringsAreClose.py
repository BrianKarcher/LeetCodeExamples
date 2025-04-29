# Two strings are considered close if you can attain one from the other using the following operations:

# Operation 1: Swap any two existing characters.
# For example, abcde -> aecdb
# Operation 2: Transform every occurrence of one existing character into another existing character, and do the same with the other character.
# For example, aacabb -> bbcbaa (all a's turn into b's, and all b's turn into a's)
# You can use the operations on either string as many times as necessary.

# Given two strings, word1 and word2, return true if word1 and word2 are close, and false otherwise.

# Slightly improved
from collections import Counter
class Solution:
    def closeStrings(self, word1: str, word2: str) -> bool:
        # String length different? Not close
        if len(word1) != len(word2):
            return False
        count1 = Counter(word1)
        count2 = Counter(word2)
        if len(count1.keys()) != len(count2.keys()):
            return False
        # Not close if character exists in one and not the other
        if count1.keys() != count2.keys():
            return False
        
        v1sorted = sorted(count1.values())
        v2sorted = sorted(count2.values())
        if v1sorted != v2sorted:
            return False
        return True


# First attempt
from collections import Counter
class Solution:
    def closeStrings(self, word1: str, word2: str) -> bool:
        # String length different? Not close
        if len(word1) != len(word2):
            return False
        count1 = Counter(word1)
        count2 = Counter(word2)
        if len(count1.keys()) != len(count2.keys()):
            return False
        for c in count1.keys():
            # Not close if character exists in one and not the other
            if count2[c] == 0:
                return False
        
        for c in count2.keys():
            # Not close if character exists in one and not the other
            if count1[c] == 0:
                return False
        
        v1sorted = sorted(count1.values())
        v2sorted = sorted(count2.values())
        for i in range(len(v1sorted)):
            if v1sorted[i] != v2sorted[i]:
                return False
        return True