# Given strings s1, s2, and s3, find whether s3 is formed by an interleaving of s1 and s2.

# An interleaving of two strings s and t is a configuration where s and t are divided into n and m 
# substrings
#  respectively, such that:

# s = s1 + s2 + ... + sn
# t = t1 + t2 + ... + tm
# |n - m| <= 1
# The interleaving is s1 + t1 + s2 + t2 + s3 + t3 + ... or t1 + s1 + t2 + s2 + t3 + s3 + ...
# Note: a + b is the concatenation of strings a and b.

class Solution:
    def isInterleave(self, s1: str, s2: str, s3: str) -> bool:
        if len(s1) + len(s2) != len(s3):
            return False
        memo = [[None for _ in range(len(s2))] for _ in range(len(s1))]
        def dp(i1: int, i2: int, i3: int) -> bool:
            if i1 == len(s1):
                return s2[i2:] == s3[i3:]
            if i2 == len(s2):
                return s1[i1:] == s3[i3:]
            if memo[i1][i2] is not None:
                return memo[i1][i2]
            # print(f'{i1} {i2} {s1[i1]} {s2[i2]} {s3[i1+i2+1]}')
            ans = s1[i1] == s3[i3] and dp(i1 + 1, i2, i3 + 1) \
            or \
            s2[i2] == s3[i3] and dp(i1, i2 + 1, i3 + 1)
            memo[i1][i2] = ans
            return ans
        rtn = dp(0, 0, 0)
        # print(memo)
        return rtn