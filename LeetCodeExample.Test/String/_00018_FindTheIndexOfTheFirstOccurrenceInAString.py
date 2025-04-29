# Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

class Solution:
    def strStr(self, haystack: str, needle: str) -> int:
        def check(idx: int) -> bool:
            for i in range(len(needle)):
                if haystack[idx + i] != needle[i]:
                    return False
            return True
        
        for i in range(len(haystack) - len(needle) + 1):
            if check(i):
                return i
        return -1