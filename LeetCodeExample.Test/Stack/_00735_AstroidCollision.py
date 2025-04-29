# We are given an array asteroids of integers representing asteroids in a row. The indices of the asteriod in the array represent their relative position in space.
# For each asteroid, the absolute value represents its size, and the sign represents its direction (positive meaning right, negative meaning left). Each asteroid moves at the same speed.
# Find out the state of the asteroids after all collisions. If two asteroids meet, the smaller one will explode. If both are the same size, both will explode. Two asteroids moving in the same direction will never meet.

from typing import List
class Solution:
    def asteroidCollision(self, asteroids: List[int]) -> List[int]:
        stack = []
        for ast in asteroids:
            if not stack or ast > 0:
                # print(f'adding {ast} 1')
                stack.append(ast)
                continue
            # going same direction
            if (ast < 0 and stack[-1] < 0) or (ast > 0 and stack[-1] > 0):
                # print(f'adding {ast} 2')
                stack.append(ast)
                continue
            destroyThis = False
            while stack and stack[-1] > 0:
                left = abs(stack[-1])
                right = abs(ast)
                if left == right:
                    # same size? Destroy both
                    destroyThis = True
                    pp = stack.pop()
                    # print(f'popping {pp} 3')
                    break
                elif left > right:
                    # print(f'exiting while 3.5')
                    destroyThis = True
                    break
                else:
                    stack.pop()
            if not destroyThis:
                # print(f'adding {ast} 4')
                stack.append(ast)
        return stack