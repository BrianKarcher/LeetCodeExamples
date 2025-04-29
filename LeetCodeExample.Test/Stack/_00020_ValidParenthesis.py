# Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

# An input string is valid if:

# Open brackets must be closed by the same type of brackets.
# Open brackets must be closed in the correct order.
# Every close bracket has a corresponding open bracket of the same type.

class Solution:
    def isValid(self, s: str) -> bool:
        stack = []
        # dic pairing closing parenthesis with their opening
        closingdic = {'}': '{', ')': '(', ']': '['}
        for c in s:
            if c in closingdic:
                if len(stack) == 0 or stack[-1] != closingdic[c]:
                    return False
                # Pop the opening parenthesis
                stack.pop()
            else:
                # Append opening parenthesis
                stack.append(c)
        return len(stack) == 0