# Given two integers left and right that represent the range [left, right], return the bitwise AND of all numbers in this range, inclusive.

class Solution:
    def rangeBitwiseAnd(self, left: int, right: int) -> int:
        while left < right:
            # turn off rightmost 1-bit
            right = right & (right - 1)
        return right