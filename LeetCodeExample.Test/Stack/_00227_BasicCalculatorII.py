# Given a string s which represents an expression, evaluate this expression and return its value. 
# The integer division should truncate toward zero.
# You may assume that the given expression is always valid. All intermediate results will be in the range of [-231, 231 - 1].
# Note: You are not allowed to use any built-in function which evaluates strings as mathematical expressions, such as eval().

# Optimal, O(1) memory:
class Solution:
    def calculate(self, s: str) -> int:
        operand = ''
        lastNumber = 0
        result = 0
        prevOperation = '+'
        for i in range(len(s)):
            c = s[i]
            if c.isdigit():
                operand += c
            if not c.isdigit() and not c == ' ' or i == len(s) - 1:
                # The operand recording is complete
                currentNumber = int(operand)
                # Perform multiply and divide in-flight so at the end all we have in the stack is add and sub
                # print(f'prevOperation: {prevOperation}')
                if prevOperation == '*':
                    lastNumber = lastNumber * currentNumber
                elif prevOperation == '/':
                    lastNumber = int(lastNumber / currentNumber)
                elif prevOperation == '-' or prevOperation == '+':
                    result += lastNumber
                    lastNumber = currentNumber if prevOperation == '+' else -currentNumber
                operand = ''
                # print(f'setting prevOperation to {c}')
                prevOperation = c
        result += lastNumber
        # All that are left are adds, just add them up
        return result


# A little more optimized
ADD = '+'
SUB = '-'
MUL = '*'
DIV = '/'
OPERATIONS = {ADD, SUB, MUL, DIV}
MUL_DIV = {MUL, DIV}
class Solution:
    def calculate(self, s: str) -> int:
        st = []
        calcs = {'+': lambda a, b: a + b,
                 '-': lambda a, b: a - b,
                 '*': lambda a, b: a * b,
                 '/': lambda a, b: int(a / b)}

        operand = ''
        prevOperation = '+'
        for i in range(len(s)):
            c = s[i]
            if c.isdigit():
                operand += c
            if not c.isdigit() and not c == ' ' or i == len(s) - 1:
                # The operand recording is complete
                currentNumber = int(operand)
                # Perform multiply and divide in-flight so at the end all we have in the stack is add and sub
                # print(f'prevOperation: {prevOperation}')
                if prevOperation in {'*', '/'}:
                    prevNumber = st.pop()
                    # print(f'{prevOperation}, {prevNumber}, {currentNumber}')
                    # print(f'adding {calcs[prevOperation](prevNumber, currentNumber)}')
                    st.append(calcs[prevOperation](prevNumber, currentNumber))
                elif prevOperation == '-':
                    # Convert subtractions to adding a negative number.
                    # e.g. a - b = a + (-b)
                    # This will help later when we pull the number from the stack.
                    # print(f'adding {-currentNumber}')
                    st.append(-currentNumber)
                else:
                    # print(f'adding {currentNumber}')
                    st.append(currentNumber)
                operand = ''
                prevOperation = c
        # print(st)
        # All that are left are adds, just add them up
        return sum(st)
    

# My original solution:


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