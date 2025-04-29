# Implement pow(x, n), which calculates x raised to the power n (i.e., xn).

# Copied from Leetcode :(
class Solution:
    def myPow(self, x: float, n: int) -> float:
        def rec(x: float, n: float) -> float:
            if n == 0:
                return 1
            if n < 0:
                return 1 / rec(x, n * -1)
            
            if n % 2 == 1:
                return x * rec(x * x, (n - 1) // 2)
            else:
                return rec(x * x, n // 2)
        return rec(x, n)