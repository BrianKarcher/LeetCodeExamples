# Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. This matrix has the following properties:

# Integers in each row are sorted in ascending from left to right.
# Integers in each column are sorted in ascending from top to bottom.
from typing import List
class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        rows = len(matrix)
        cols = len(matrix[0])
        if rows < cols:
            print("searching by rows")
            for row in range(rows):
                l = 0
                r = cols - 1
                while l <= r:
                    mid = int((l + r) / 2)
                    val = matrix[row][mid]
                    if val == target:
                        return True
                    elif val < target:
                        l = mid + 1
                    else:
                        r = mid - 1
        else:
            print("searching by cols")
            for col in range(cols):
                l = 0
                r = rows - 1
                while l <= r:
                    mid = int((l + r) / 2)
                    val = matrix[mid][col]
                    if val == target:
                        return True
                    elif val < target:
                        l = mid + 1
                    else:
                        r = mid - 1

        return False