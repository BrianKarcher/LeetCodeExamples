# You are given an m x n integer matrix matrix with the following two properties:

# Each row is sorted in non-decreasing order.
# The first integer of each row is greater than the last integer of the previous row.
# Given an integer target, return true if target is in matrix or false otherwise.

# You must write a solution in O(log(m * n)) time complexity.

from typing import List
class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        rows = len(matrix)
        cols = len(matrix[0])
        # Find row
        l = 0
        r = rows - 1
        while l <= r:
            mid = (l + r ) // 2
            if target == matrix[mid][0]:
                return True
            elif target > matrix[mid][0]:
                l = mid + 1
            else:
                r = mid - 1
        
        row = r

        l = 0
        r = cols - 1
        while l <= r:
            mid = (l + r) // 2
            if target == matrix[row][mid]:
                return True
            elif target > matrix[row][mid]:
                l = mid + 1
            else:
                r = mid - 1
        return False