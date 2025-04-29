# You are given an array of strings tokens that represents an arithmetic expression in a Reverse Polish Notation.

# Evaluate the expression. Return an integer that represents the value of the expression.

# Note that:

# The valid operators are '+', '-', '*', and '/'.
# Each operand may be an integer or another expression.
# The division between two integers always truncates toward zero.
# There will not be any division by zero.
# The input represents a valid arithmetic expression in a reverse polish notation.
# The answer and all the intermediate calculations can be represented in a 32-bit integer.

from typing import List
class Solution:
    def evalRPN(self, tokens: List[str]) -> int:
        stack = []
        for token in tokens:
            stack.append(token if not token.replace('-', '').isdigit() else int(token))
            # print(stack)
            while stack and type(stack[-1]) == str:
                operand = stack.pop()
                first = int(stack.pop())
                second = int(stack.pop())
                match operand:
                    case '+':
                        stack.append(first + second)
                    case '-':
                        stack.append(second - first)
                    case '*':
                        stack.append(first * second)
                    case '/':
                        div = second / first
                        # Truncate towards zero.
                        stack.append(int(second / first))
        # The input tokens given guarantee that all that is left is the answer
        # This is the last remaining item
        return stack[0]