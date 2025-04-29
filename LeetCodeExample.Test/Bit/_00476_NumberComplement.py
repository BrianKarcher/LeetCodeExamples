# The complement of an integer is the integer you get when you flip all the 0's to 1's and all the 1's to 0's in its binary representation.

# For example, The integer 5 is "101" in binary and its complement is "010" which is the integer 2.
# Given an integer num, return its complement.

class Solution:
    def findComplement(self, num: int) -> int:
        orig = num
        ans = 0
        while num != 0:
            ans = ans << 1
            ans = ans | 1
            num = num >> 1
        return (orig ^ ans)