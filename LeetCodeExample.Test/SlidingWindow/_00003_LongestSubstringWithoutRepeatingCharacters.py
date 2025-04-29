# Given a string s, find the length of the longest  substring without repeating characters.

class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        chars = [None] * 128
        ans = 0
        l = 0
        for r in range(len(s)):
            index = chars[ord(s[r])]
            if index is not None and l <= index < r:
                l = index + 1
            ans = max(ans, r - l + 1)
            chars[ord(s[r])] = r
        return ans

class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        l = 0
        chars = set()
        length = 0
        for r in range(len(s)):
            if s[r] in chars:
                while l < r and s[l] != s[r]:
                    if s[l] in chars:
                        chars.remove(s[l])
                    l += 1
                if (s[l] == s[r]):
                    l += 1
            chars.add(s[r])
            length = max(length, r - l + 1)
        return length