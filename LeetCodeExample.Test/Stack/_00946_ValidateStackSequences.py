# Given two integer arrays pushed and popped each with distinct values, 
# return true if this could have been the result of a sequence of push and pop operations on an initially empty stack, or false otherwise.

class Solution:
    def validateStackSequences(self, pushed: List[int], popped: List[int]) -> bool:
        pushStack = []
        popQueue = deque(popped)
        #print(popStack)
        for x in pushed:
            pushStack.append(x)
            #print("pushing " + str(pushStack[-1]) + " checking against " + str(popStack[-1]))
            while pushStack and popQueue and pushStack[-1] == popQueue[0]:
                #print("popping " + str(pushStack[-1]))
                pushStack.pop()
                popQueue.popleft()
        return not pushStack