# Given an m x n matrix, return all elements of the matrix in spiral order.

from typing import List

# This is cleaner
from typing import List
class Solution:
    def spiralOrder(self, matrix: List[List[int]]) -> List[int]:
        ans = []
        # The matrix boundry
        l = 0
        u = 0
        d = len(matrix) - 1
        r = len(matrix[0]) - 1
        # The order here is critical - right, down, left, up
        dirs = [(1, 0), (0, 1), (-1, 0), (0, -1)]
        dir = 0
        # Position in the matrix
        x = l
        y = u
        while u <= d and l <= r:
            ans.append(matrix[y][x])
            # Change direction if we hit any boundry
            newX = x + dirs[dir][0]
            newY = y + dirs[dir][1]
            if newX > r or newX < l or newY > d or newY < u:
                # Collapse a boundry based on direction
                if dir == 0:
                    u += 1
                elif dir == 1:
                    r -= 1
                elif dir == 2:
                    d -= 1
                else:
                    l += 1
                dir += 1
                if dir > 3:
                    dir = 0
                newX = x + dirs[dir][0]
                newY = y + dirs[dir][1]
            x, y = newX, newY
        return ans

# Fist attempt
class Solution:
    def spiralOrder(self, matrix: List[List[int]]) -> List[int]:
        ans = []
        l = 0
        u = 0
        d = len(matrix) - 1
        r = len(matrix[0]) - 1
        while u <= d and l <= r:
            # Go right top side
            for col in range(l, r + 1):
                ans.append(matrix[u][col])
            u += 1
            if u > d:
                break
            # Go down right side
            for row in range(u, d + 1):
                ans.append(matrix[row][r])
            r -= 1
            if l > r:
                break
            # Go left bottom side
            for col in range(r, l - 1, -1):
                ans.append(matrix[d][col])
            d -= 1
            if u > d:
                break
            # Go up left side
            for row in range(d, u - 1, -1):
                ans.append(matrix[row][l])
            l += 1
        return ans