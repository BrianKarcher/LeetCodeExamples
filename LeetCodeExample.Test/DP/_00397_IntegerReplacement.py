# Given a positive integer n, you can apply one of the following operations:

# If n is even, replace n with n / 2.
# If n is odd, replace n with either n + 1 or n - 1.
# Return the minimum number of operations needed for n to become 1.

class Solution:
    def integerReplacement(self, n: int) -> int:
        map = {}
        def recurse(n) -> int:
            if n == 1:
                return 0
            
            if n in map:
                return map[n]
            
            val = -1
            if n % 2 == 0:
                val = recurse(n / 2) + 1
            else:
                val = min(recurse(n - 1), recurse(n + 1)) + 1

            map[n] = val
            return val
        
        return recurse(n)