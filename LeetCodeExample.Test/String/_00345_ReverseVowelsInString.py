# Given a string s, reverse only all the vowels in the string and return it.
# The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.

# Better solution
class Solution:
    def reverseVowels(self, s: str) -> str:
        VOWELS: set = { "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" }

        characters: list[str] = list(s)
        left, right = 0, len(characters) - 1
        while left < right:
            left_value, right_value = characters[left], characters[right]
            if left_value in VOWELS and right_value in VOWELS:
                characters[left], characters[right] = characters[right], characters[left]
                left += 1
                right -= 1
            elif left_value in VOWELS and right_value not in VOWELS:
                right -= 1
            elif left_value not in VOWELS and right_value in VOWELS:
                left += 1
            else:
                left += 1
                right -= 1
        
        return "".join(characters)
    
# My solution
class Solution:
    def reverseVowels(self, s: str) -> str:
        vowels = {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'}
        lst = []
        # Record the vowels in order
        for c in s:
            if c in vowels:
                lst.append(c)
        ans = ''
        # Go through the string, and reverse the vowels
        for c in s:
            if c in vowels:
                ans += lst.pop()
            else:
                ans += c
        return ans