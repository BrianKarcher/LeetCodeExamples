# A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

# Given a string s, return true if it is a palindrome, or false otherwise.

class Solution:
    def isPalindrome(self, s: str) -> bool:
        i1, i2 = 0, len(s) - 1
        valid = set()
        s = s.lower()
        # lowercase
        for i in range(26):
            valid.add(chr(ord('a') + i))
        # nums
        for i in range(10):
            valid.add(chr(ord('0') + i))

        while i1 < i2:
            # find next valid character
            while i1 < i2 and s[i1] not in valid:
                i1 += 1
            while i1 < i2 and s[i2] not in valid:
                i2 -= 1

            if s[i1] != s[i2]:
                return False
            i1 += 1
            i2 -= 1
        return True