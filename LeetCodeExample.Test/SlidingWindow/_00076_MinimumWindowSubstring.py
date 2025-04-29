# Given two strings s and t of lengths m and n respectively, return the minimum window 
# substring
#  of s such that every character in t (including duplicates) is included in the window. If there is no such substring, return the empty string "".

# The testcases will be generated such that the answer is unique.

from collections import defaultdict
import sys
class Solution:
    def minWindow(self, s: str, t: str) -> str:
        chars = defaultdict(int)
        # indiv = set()
        count = len(t)
        for c in t:
            chars[c] += 1
            # indiv.add(c)

        # allUsed = False
        l = 0
        ans = ""
        length = sys.maxsize
        for r in range(len(s)):
            # subtract r from dict if exists
            if s[r] in chars:
                chars[s[r]] -= 1
                # if count >= 0:
                #     count -= 1
                if chars[s[r]] >= 0:
                    # We only account for actual characters removed. Going into the negative
                    # doesn't affect the count of characters that can still be plucked
                    # If we don't do this check, then if t is "aac" but s is "aaa", the 3 a's would cause the counter to go to zero
                    # when a c is actually still available to be plucked.
                    count -= 1
            if count == 0:
                # all letters have been used
                while count == 0 and l <= r:
                    if r - l < length:
                        ans = s[l:r+1]
                        length = len(ans)
                    # Pluck an L
                    if s[l] in chars:
                        chars[s[l]] += 1
                        if chars[s[l]] > 0:
                            count += 1
                    l += 1
        return ans