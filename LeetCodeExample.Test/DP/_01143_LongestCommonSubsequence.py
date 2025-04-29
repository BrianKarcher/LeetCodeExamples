# Given two strings text1 and text2, return the length of their longest common subsequence. If there is no common subsequence, return 0.

# A subsequence of a string is a new string generated from the original string with some characters (can be none) deleted without changing the relative order of the remaining characters.

# For example, "ace" is a subsequence of "abcde".
# A common subsequence of two strings is a subsequence that is common to both strings.

class Solution:
    def longestCommonSubsequence(self, text1: str, text2: str) -> int:
        self.memo = [[-1 for i in range(len(text2))] for j in range(len(text1))]

        def lcs(n: int, m: int) -> int:
            if n < 0 or m < 0:
                return 0
            if self.memo[n][m] != -1:
                return self.memo[n][m]

            ans = 0
            if text1[n] == text2[m]:
                # Match, add one and continue to next
                ans = 1 + lcs(n - 1, m - 1)
            else:
                # No match, get best value if we exclude a character from the first
                # or second string
                left = lcs(n - 1, m)
                right = lcs(n, m - 1)
                ans = max(left, right)
            self.memo[n][m] = ans
            return ans
        
        return lcs(len(text1) - 1, len(text2) - 1)