# Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.

# You must do it in place.

from typing import List
class Solution:
    def setZeroes(self, matrix: List[List[int]]) -> None:
        """
        Do not return anything, modify matrix in-place instead.
        """
        cols = set()
        rows = set()

        for row in range(len(matrix)):
            for col in range(len(matrix[0])):
                if matrix[row][col] == 0:
                    cols.add(col)
                    rows.add(row)
        
        for col in cols:
            for row in range(len(matrix)):
                matrix[row][col] = 0
        
        for row in rows:
            for col in range(len(matrix[0])):
                matrix[row][col] = 0