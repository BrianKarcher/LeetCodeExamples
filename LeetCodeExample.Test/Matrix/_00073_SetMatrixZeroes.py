# Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.

# You must do it in place.

# This uses constant space
from typing import List
class Solution:
    def setZeroes(self, matrix: List[List[int]]) -> None:
        """
        Do not return anything, modify matrix in-place instead.
        """
        rows = len(matrix)
        cols = len(matrix[0])
        # Use the first row and first column as markers
        firstRow = False
        firstCol = False
        for r in range(rows):
            if matrix[r][0] == 0:
                firstCol = True
        for c in range(cols):
            if matrix[0][c] == 0:
                firstRow = True
        
        for r in range(1, rows):
            for c in range(1, cols):
                if matrix[r][c] == 0:
                    matrix[0][c] = 0
                    matrix[r][0] = 0
        
        for r in range(1, rows):
            for c in range(1, cols):
                if not matrix[0][c] or not matrix[r][0]:
                    matrix[r][c] = 0

        if firstRow:
            for c in range(cols):
                matrix[0][c] = 0
        if firstCol:
            for r in range(rows):
                matrix[r][0] = 0



# This uses M + N space
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