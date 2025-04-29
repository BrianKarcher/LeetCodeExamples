# Given a n * n matrix grid of 0's and 1's only. We want to represent grid with a Quad-Tree.

# Return the root of the Quad-Tree representing grid.

# A Quad-Tree is a tree data structure in which each internal node has exactly four children. Besides, each node has two attributes:

# val: True if the node represents a grid of 1's or False if the node represents a grid of 0's. Notice that you can assign the val to True or False when isLeaf is False, and both are accepted in the answer.
# isLeaf: True if the node is a leaf node on the tree or False if the node has four children.
# class Node {
#     public boolean val;
#     public boolean isLeaf;
#     public Node topLeft;
#     public Node topRight;
#     public Node bottomLeft;
#     public Node bottomRight;
# }
# We can construct a Quad-Tree from a two-dimensional area using the following steps:

# If the current grid has the same value (i.e all 1's or all 0's) set isLeaf True and set val to the value of the grid and set the four children to Null and stop.
# If the current grid has different values, set isLeaf to False and set val to any value and divide the current grid into four sub-grids as shown in the photo.
# Recurse for each of the children with the proper sub-grid.

class Node:
    def __init__(self, val, isLeaf, topLeft, topRight, bottomLeft, bottomRight):
        self.val = val
        self.isLeaf = isLeaf
        self.topLeft = topLeft
        self.topRight = topRight
        self.bottomLeft = bottomLeft
        self.bottomRight = bottomRight

# This is optimal
from typing import List
class Solution:
    def construct(self, grid: List[List[int]]) -> 'Node':
        def rec(x1: int, y1: int, length: int) -> Node:
            if length == 1:
                return Node(grid[y1][x1], True, None, None, None, None)
            
            halfLength = length // 2
            topLeft = rec(x1, y1, halfLength)
            topRight = rec(x1 + halfLength, y1, halfLength)
            bottomLeft = rec(x1, y1 + halfLength, halfLength)
            bottomRight = rec(x1 + halfLength, y1 + halfLength, halfLength)
            # Is Leaf?
            if topLeft.isLeaf and topRight.isLeaf and bottomLeft.isLeaf and bottomRight.isLeaf \
                and topLeft.val == topRight.val == bottomLeft.val == bottomRight.val:
                return Node(topLeft.val, True, None, None, None, None)
            # Not a Leaf
            return Node(topLeft.val, False, topLeft, topRight, bottomLeft, bottomRight)
        return rec(0, 0, len(grid))
    
# The extra double for loops really slow it down
class Solution:
    def construct(self, grid: List[List[int]]) -> 'Node':
        def dfs(x1, y1, length) -> Node:
            # if x1 > x2 or y1 > y2:
            #     return None
            val = grid[y1][x1]
            isLeaf = True
            # check if a leaf
            for y in range(y1, y2 + 1):
                for x in range(x1, x2 + 1):
                    if grid[y][x] != val:
                        isLeaf = False
                        continue
                if not isLeaf:
                    continue
            if isLeaf:
                return Node(val, isLeaf, None, None, None, None)
            midX = int((x1 + x2) / 2)
            midY = int((y1 + y2) / 2)
            # Chop into quarters
            topLeft = dfs(x1, midX, y1, midY)
            topRight = dfs(midX + 1, x2, y1, midY)
            bottomLeft = dfs(x1, midX, midY + 1, y2)
            bottomRight = dfs(midX + 1, x2, midY + 1, y2)
            return Node(val, isLeaf, topLeft, topRight, bottomLeft, bottomRight)
        return dfs(0, len(grid[0]) - 1, 0, len(grid) - 1)