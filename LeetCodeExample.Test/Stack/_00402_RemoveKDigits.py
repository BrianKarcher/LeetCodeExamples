#Given string num representing a non-negative integer num, and an integer k, return the smallest possible integer after removing k digits from num.

class Solution:
    def removeKdigits(self, num: str, k: int) -> str:
        stack = []
        for digit in num:
            while stack and k > 0 and stack[-1] > digit:
                k -= 1
                stack.pop()
            stack.append(digit)
        
        # If k > 0, remove remaining k digits from the end of the stack
        if k > 0:
            stack = stack[:-k]

        # remove leading zeroes

        rtn = ''.join(stack).lstrip('0')
        return rtn if rtn else "0"