# 1318

# Given 3 positives numbers a, b and c. Return the minimum flips required in some bits of a and b to make ( a OR b == c ). (bitwise OR operation).
# Flip operation consists of change any single bit 1 to 0 or change the bit 0 to 1 in their binary representation.

# My solution
class Solution:
    def minFlips(self, a: int, b: int, c: int) -> int:
        ans = 0
        while c != 0 or b != 0 or a != 0:
            a_bit = a & 1
            b_bit = b & 1
            c_bit = c & 1
            # Handle various scenarios
            if c_bit == 0:
                # We need to switch both bits to zero if either are one
                if a_bit == 1:
                    ans += 1
                if b_bit == 1:
                    ans += 1
            else: # c_bit == 1
                # If either A AND B are 0, then we need to switch one.
                # Otherwise, we are good
                if a_bit == 0 and b_bit == 0:
                    ans += 1
            c >>= 1
            b >>= 1
            a >>= 1
        return ans