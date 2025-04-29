# For two strings s and t, we say "t divides s" if and only if s = t + t + t + ... + t + t (i.e., t is concatenated with itself one or more times).
# Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.

class Solution:
    def gcdOfStrings(self, str1: str, str2: str) -> str:
        def isPrefix(prefix: str, s: str) -> bool:
            # print(f'len prefix = {len(prefix)}, len(s) = {len(s)}')
            if len(s) % len(prefix) != 0:
                return False
            i = 0
            while i < len(s):
                sub = s[i: i + len(prefix)]
                # print(f'sub: {sub}')
                if sub != prefix:
                    return False
                i += len(prefix)
            return True
        smaller = str1 if len(str1) < len(str2) else str2
        for i in range(len(smaller) - 1, -1, -1):
            prefix = smaller[0:i + 1]
            # print(f'prefix: {prefix}')
            if isPrefix(prefix, str1) and isPrefix(prefix, str2):
                return prefix
        return ''