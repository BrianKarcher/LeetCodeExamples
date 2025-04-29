# Given a string s, reverse only all the vowels in the string and return it.
# The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.

class Solution:
    def reverseVowels(self, s: str) -> str:
        vowels = {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'}
        lst = []
        # Record the vowels in order
        for c in s:
            if c in vowels:
                lst.append(c)
        # Vowel index
        vi = len(lst) - 1
        ans = ''
        # Go through the string, and reverse the vowels
        for c in s:
            if c in vowels:
                ans += lst[vi]
                vi -= 1
            else:
                ans += c
        return ans