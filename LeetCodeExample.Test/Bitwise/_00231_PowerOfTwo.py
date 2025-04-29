# Given an integer n, return true if it is a power of two. Otherwise, return false.

# An integer n is a power of two, if there exists an integer x such that n == 2x.

class Solution:
    def isPowerOfTwo(self, n: int) -> bool:
        val = 1
        for x in range(32):
            if val == n:
                return True
            elif val > n:
                return False
            #val = val * 2
            val = val << 1
        return False