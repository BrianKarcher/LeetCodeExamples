# Given an integer n, return the number of prime numbers that are strictly less than n.

 

# Example 1:

# Input: n = 10
# Output: 4
# Explanation: There are 4 prime numbers less than 10, they are 2, 3, 5, 7.
# Example 2:

# Input: n = 0
# Output: 0
# Example 3:

# Input: n = 1
# Output: 0

import math
class Solution:
    def countPrimes(self, n: int) -> int:
        sqrt = int(math.sqrt(n))
        arr = [True] * n
        count = 0
        for i in range(2, n):
            if arr[i]:
                count += 1
                # flag multiples of this prime as not prime
                for mul in range(i + i, n, i):
                    arr[mul] = False
        return count