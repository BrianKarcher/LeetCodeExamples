# The Hamming distance between two integers is the number of positions at which the corresponding bits are different.

# Given two integers x and y, return the Hamming distance between them.

class Solution:
    def hammingDistance(self, x: int, y: int) -> int:
        num = x ^ y
        ans = 0
        while num != 0:
            if num & 1 == 1:
                ans += 1
            num = num >> 1
        
        return ans