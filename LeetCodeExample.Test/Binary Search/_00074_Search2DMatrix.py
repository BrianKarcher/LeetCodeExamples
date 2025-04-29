# You are given an m x n integer matrix matrix with the following two properties:

# Each row is sorted in non-decreasing order.
# The first integer of each row is greater than the last integer of the previous row.
# Given an integer target, return true if target is in matrix or false otherwise.

# You must write a solution in O(log(m * n)) time complexity.



class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        # search rows
        l = 0
        r = len(matrix) - 1
        #print(f"target: {target}")
        #print(f"first search: l {l} r {r}")
        while l <= r:
            mid = int((l + r) / 2)
            print(f"mid {mid} = {matrix[mid][0]}")
            if matrix[mid][0] == target:
                #print("found")
                return True
            elif matrix[mid][0] < target:
                #print("moving right")
                l = mid + 1
            else:
                #print("moving left")
                r = mid - 1
                
            #print(f"l {l} r {r}")

        #if matrix[r][0] == target:
        #    return True
        if r < 0:
            r = 0
        row = r
        #print(f"row: {row}")
        # search cols.
        l = 0
        r = len(matrix[0]) - 1
        while l <= r:
            mid = int((l + r) / 2)
            #print(f"searching {row}, {mid}")
            if matrix[row][mid] == target:
                return True
            elif matrix[row][mid] < target:
                l = mid + 1
            else:
                r = mid - 1
           
        return False