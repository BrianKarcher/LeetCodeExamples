# Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

# Implement the MinStack class:

# MinStack() initializes the stack object.
# void push(int val) pushes the element val onto the stack.
# void pop() removes the element on the top of the stack.
# int top() gets the top element of the stack.
# int getMin() retrieves the minimum element in the stack.
# You must implement a solution with O(1) time complexity for each function.

# This solution uses two stacks, saves space by using a counter for the min stack
class MinStack:

    def __init__(self):
        self.stack = []
        self.minstack = []

    def push(self, val: int) -> None:
        # Always add to main stack
        self.stack.append(val)
        if not self.minstack or val < self.minstack[-1][0]:
            # We store the value, and the count of times we have seen it
            self.minstack.append([val, 1])
        elif self.minstack[-1][0] == val:
            self.minstack[-1][1] += 1

    def pop(self) -> None:
        if self.minstack[-1][0] == self.stack[-1]:
            self.minstack[-1][1] -= 1
        if self.minstack[-1][1] == 0:
            self.minstack.pop()
        self.stack.pop()

    def top(self) -> int:
        return self.stack[-1]

    def getMin(self) -> int:
        return self.minstack[-1][0]
    

###################################

from collections import deque
import sys
class MinStack:

    def __init__(self):
        self.st = deque()
        self.min = sys.maxsize

    def push(self, val: int) -> None:
        minVal = val if not self.st else min(val, self.st[-1][1])
        self.st.append((val, minVal))

    def pop(self) -> None:
        self.st.pop()

    def top(self) -> int:
        return self.st[-1][0]

    def getMin(self) -> int:
        return self.st[-1][1]