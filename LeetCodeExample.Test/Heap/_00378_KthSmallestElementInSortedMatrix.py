# Given an n x n matrix where each of the rows and columns is sorted in ascending order, return the kth smallest element in the matrix.

# Note that it is the kth smallest element in the sorted order, not the kth distinct element.

# You must find a solution with a memory complexity better than O(n2).

from typing import List
class Solution:
    def kthSmallest(self, matrix: List[List[int]], k: int) -> int:
        def countLessOrEqual(x) -> int:
            count = 0
            for row in range(len(matrix)):
                c = len(matrix) - 1
                # Can speed up by doing a binary search here
                # Might feel funny doing a binary search within a binary search
                while c >= 0 and matrix[row][c] > x:
                    c -= 1
                count += c + 1
            return count

        def bs() -> int:
            n = len(matrix)
            if n == 1 or k == 1:
                return matrix[0][0]
            # r starts as the largest value in the matrix, as defined by the problem
            l, r = matrix[0][0], matrix[n - 1][n - 1]
            # We do a binary search on VALUE, not indexes
            ans = -1
            while l <= r:
                mid = int(l + (r - l) / 2)
                #print(f'{l}, {r}, {mid}, count = {count}, dups = {dups}')
                if countLessOrEqual(mid) >= k:
                    ans = mid
                    r = mid - 1
                else:
                    l = mid + 1
            return ans
        return bs()
    
    
from typing import List
class Solution:
    def kthSmallest(self, matrix: List[List[int]], k: int) -> int:
        def bs() -> int:
            n = len(matrix)
            if n == 1 or k == 1:
                return matrix[0][0]
            # r starts as the largest value in the matrix, as defined by the problem
            l, r = matrix[0][0], matrix[n - 1][n - 1]
            # We do a binary search on VALUE, not indexes
            mid = 0
            while l <= r:
                count = 0
                dups = 0
                mid = int(l + (r - l) / 2)
                for row in range(n):
                    for col in range(n):
                        if matrix[row][col] <= mid:
                            count += 1
                            if matrix[row][col] == mid:
                                dups += 1
                #print(f'{l}, {r}, {mid}, count = {count}, dups = {dups}')
                if k >= count - max(0, dups - 1) and k <= count:
                    # mid may not be in the matrix, so
                    # find number closest to mid, but not bigger than mid
                    #print(f'found, mid = {mid}')
                    break
                elif count > k:
                    r = mid - 1
                else:
                    l = mid + 1
            rtn = matrix[0][0]
            for row in range(n):
                for col in range(n):
                    if matrix[row][col] <= mid:
                        rtn = max(rtn, matrix[row][col])
            return rtn
        return bs()
    

from typing import List
import heapq
class Solution:
    def kthSmallest(self, matrix: List[List[int]], k: int) -> int:
        heap = []
        heapq.heappush(heap, (matrix[0][0], 0, 0))
        count = 0
        size = len(matrix)
        mem = set()
        while True:
            count += 1
            val = heapq.heappop(heap)
            #print(f'Popping {val[0]}, {val[1]}, {val[2]}')
            if count == k:
                return val[0]
            row = val[1]
            col = val[2]
            if col + 1 < size:
                #print(f'Adding {matrix[row][col + 1]}, {row},{col + 1}')
                if not (row, col + 1) in mem:
                    heapq.heappush(heap, (matrix[row][col + 1], row, col + 1))
                    mem.add((row, col + 1))
            if row + 1 < size:
                if not (row + 1, col) in mem:
                    #print(f'Adding {matrix[row + 1][col]}, {row + 1},{col}')
                    heapq.heappush(heap, (matrix[row + 1][col], row + 1, col))
                    mem.add((row + 1, col))