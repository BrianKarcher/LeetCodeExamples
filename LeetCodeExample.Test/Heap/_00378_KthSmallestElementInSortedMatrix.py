# Given an n x n matrix where each of the rows and columns is sorted in ascending order, return the kth smallest element in the matrix.

# Note that it is the kth smallest element in the sorted order, not the kth distinct element.

# You must find a solution with a memory complexity better than O(n2).

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