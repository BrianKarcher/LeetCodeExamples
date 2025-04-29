# Given a string s which represents an expression, evaluate this expression and return its value. 
# The integer division should truncate toward zero.
# You may assume that the given expression is always valid. All intermediate results will be in the range of [-231, 231 - 1].
# Note: You are not allowed to use any built-in function which evaluates strings as mathematical expressions, such as eval().

ADD = '+'
SUB = '-'
MUL = '*'
DIV = '/'
OPERATIONS = {ADD, SUB, MUL, DIV}
MUL_DIV = {MUL, DIV}
from collections import deque
class Solution:
    def calculate(self, s: str) -> int:
        st = deque()
        calcs = {'+': lambda a, b: a + b,
                 '-': lambda a, b: a - b,
                 '*': lambda a, b: a * b,
                 '/': lambda a, b: a // b}

        def apply_mul_div(new: int) -> int:
            if st and st[-1] in MUL_DIV:
                # Follow order of operations, mul and div before add or sub
                op = st.pop()
                prev = int(st.pop())
                new = calcs[op](prev, new)
            return new

        operand = ''
        for c in s:
            if c == ' ':
                continue
            elif c in OPERATIONS:
                # The operand recording is complete
                new = int(operand)
                # Perform multiply and divide in-flight so at the end all we have in the stack is add and sub
                new = apply_mul_div(new)
                st.append(new)
                st.append(c)
                operand = ''
            else:
                operand += c
        new = int(operand)
        new = apply_mul_div(new)
        st.append(new)
        # print(st)
        # Do adds and subs
        while len(st) > 1:
            num1 = int(st.popleft())
            op = st.popleft()
            num2 = int(st.popleft())
            num3 = calcs[op](num1, num2)
            st.appendleft(num3)
            # print(st)
        return st[0]