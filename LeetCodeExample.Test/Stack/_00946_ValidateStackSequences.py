# Given two integer arrays pushed and popped each with distinct values, 
# return true if this could have been the result of a sequence of push and pop operations on an initially empty stack, or false otherwise.

class Solution:
    def validateStackSequences(self, pushed: List[int], popped: List[int]) -> bool:
        pushStack = []
        n = 0
        #print(popStack)
        for x in pushed:
            pushStack.append(x)
            #print("pushing " + str(pushStack[-1]) + " checking against " + str(popStack[-1]))
            while pushStack and pushStack[-1] == popped[n]:
                #print("popping " + str(pushStack[-1]))
                pushStack.pop()
                n = n + 1
        return not pushStack