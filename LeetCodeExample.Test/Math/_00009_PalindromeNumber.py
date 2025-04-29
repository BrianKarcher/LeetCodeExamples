# Given an integer x, return true if x is a 
# palindrome
# , and false otherwise.

class Solution:
    def isPalindrome(self, x: int) -> bool:
        if x < 0:
            return False
        revert = 0
        copy = x
        while copy != 0:
            pluck = copy % 10
            revert = revert * 10 + pluck
            copy //= 10
        return revert == x