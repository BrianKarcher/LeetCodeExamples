# Given two integers a and b, return the sum of the two integers without using the operators + and -.

class Solution:
    def getSum(self, a: int, b: int) -> int:
        return (a^b) + ((a&b)<<1)