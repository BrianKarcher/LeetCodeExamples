# Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

# You have the following three operations permitted on a word:

# Insert a character
# Delete a character
# Replace a character

import sys
class Solution:
    def minDistance(self, word1: str, word2: str) -> int:
        memo = [[sys.maxsize for _ in range(len(word2) + 1)] for _ in range(len(word1) + 1)]
        def dp(i1: int, i2: int) -> int:
            # If the end of either word is reached, "INSERT" all chars from other word is base case
            if i1 == 0:
                return i2
            elif i2 == 0:
                return i1

            if memo[i1][i2] != sys.maxsize:
                return memo[i1][i2]
            
            ans = sys.maxsize
            # Match, just continue?
            if word1[i1 - 1] == word2[i2 - 1]:
                ans = min(ans, dp(i1 - 1, i2 - 1))
            else:
                replace = dp(i1 - 1, i2 - 1) # REPLACE
                delete = dp(i1 - 1, i2) # DELETE
                insert = dp(i1, i2 - 1) # INSERT
                ans = min(replace, delete, insert) + 1
            memo[i1][i2] = ans
            return ans
        return dp(len(word1), len(word2))