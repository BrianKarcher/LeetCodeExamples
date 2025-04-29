# You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
# You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.

from typing import List
class Solution:
    def rotate(self, matrix: List[List[int]]) -> None:
        """
        Do not return anything, modify matrix in-place instead.
        """
        r = len(matrix[0]) - 1
        d = len(matrix) - 1
        u = 0
        l = 0
        while l < r:
            for i in range(r - l):
                top = matrix[u][l + i]
                bottom = matrix[d][r - i]
                left = matrix[d - i][l]
                right = matrix[u + i][r]
                matrix[u + i][r] = top
                matrix[d][r - i] = right
                matrix[d - i][l] = bottom
                matrix[u][l + i] = left
            r -= 1
            l += 1
            d -= 1
            u += 1