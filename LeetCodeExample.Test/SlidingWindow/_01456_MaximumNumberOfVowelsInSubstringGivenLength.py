# Given a string s and an integer k, return the maximum number of vowel letters in any substring of s with length k.
# Vowel letters in English are 'a', 'e', 'i', 'o', and 'u'.

class Solution:
    def maxVowels(self, s: str, k: int) -> int:
        m = 0
        vowels = {'a', 'e', 'i', 'o', 'u'}
        r, l = 0, 0
        while r < k:
            if s[r] in vowels:
                m += 1
            r += 1
        ans = m
        while r < len(s):
            if s[l] in vowels:
                m -= 1
            l += 1
            if s[r] in vowels:
                m += 1
            r += 1
            ans = max(ans, m)
        return ans
