# Write an algorithm to determine if a number n is happy.

# A happy number is a number defined by the following process:

# Starting with any positive integer, replace the number by the sum of the squares of its digits.
# Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
# Those numbers for which this process ends in 1 are happy.
# Return true if n is a happy number, and false if not.

class Solution:
    def isHappy(self, n: int) -> bool:
        sum = n
        s = set()
        s.add(n)
        while n != 1:
            sum = 0
            while n != 0:
                digit = n % 10
                digit **= 2
                sum += digit
                n //= 10
            if sum in s: # Cycle check
                return False
            s.add(sum)
            n = sum
        return True