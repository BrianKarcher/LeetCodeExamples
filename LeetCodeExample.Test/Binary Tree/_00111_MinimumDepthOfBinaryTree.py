# Given a binary tree, find its minimum depth.

# The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

# Note: A leaf is a node with no children.

from typing import Optional
import sys

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def minDepth(self, root: Optional[TreeNode]) -> int:
        if root is None:
            return 0
        min = sys.maxsize
        def recurse(node: Optional[TreeNode], depth: int):
            nonlocal min
            if node is None:
                return
            if depth > min:
                return
            
            if not node.left and not node.right:
                min = depth
                return
            
            recurse(node.left, depth + 1)
            recurse(node.right, depth + 1)
        recurse(root, 1)
        return min