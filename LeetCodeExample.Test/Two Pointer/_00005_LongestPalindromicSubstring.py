# Given a string s, return the longest palindromic substring in s.

class Solution:
    def longestPalindrome(self, s: str) -> str:
        def pali_length(li: int, ri: int) -> int:
            # print(f'{li} {ri}')
            while li >= 0 and ri < len(s) and s[li] == s[ri]:
                li -= 1
                ri += 1
            return ri - li - 1 # We're out of bounds of the palindrome, subtract 1 to get back in bounds

        l = 0
        r = 0
        for i in range(len(s)):
            # Palindromes can have an odd or even number of characters, so the pivot point
            # may be a single character or two adjoining characters
            len1 = pali_length(i, i)
            len2 = pali_length(i, i + 1)
            maxi = max(len1, len2)
            if maxi > r - l:
                l = i - (maxi - 1) // 2
                r = i + maxi // 2
                # print(f'{i} {maxi} {l} {r}')
        return s[l:r+1]
    
####################################

class Solution:
    def longestPalindrome(self, s: str) -> str:
        def pali_length(li: int, ri: int) -> int:
            if s[li] != s[ri]:
                return 0
            while li >= 0 and ri <= len(s) - 1:
                if s[li] != s[ri]:
                    return ri - li - 1 # We're out of bounds of the palindrome, subtract 1 to get back in bounds
                li -= 1
                ri += 1
            return ri - li - 1
        maxLength = 0
        l = 0
        r = 0
        for i in range(len(s)):
            # Palindromes can have an odd or even number of characters, so the pivot point
            # may be a single character or two adjoining characters
            thisLength = pali_length(i, i)
            if thisLength > maxLength:
                maxLength = thisLength
                l = i - thisLength // 2
                r = i + thisLength // 2
                # print(f'Odd: {i} {thisLength} {l} {r}')

            thisLength = pali_length(i - 1, i)
            if thisLength > maxLength:
                maxLength = thisLength
                l = (i - 1 - thisLength // 2) + 1
                r = (i + thisLength // 2) - 1
                # print(f'Even: {i} {thisLength} {l} {r}')
        return s[l:r+1]