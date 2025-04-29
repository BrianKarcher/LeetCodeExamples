# Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.

# Each letter in magazine can only be used once in ransomNote.

from collections import defaultdict
class Solution:
    def canConstruct(self, ransomNote: str, magazine: str) -> bool:
        dic = defaultdict(int)
        for c in magazine:
            dic[c] += 1
        
        for c in ransomNote:
            dic[c] -= 1
            if dic[c] < 0:
                return False
        return True