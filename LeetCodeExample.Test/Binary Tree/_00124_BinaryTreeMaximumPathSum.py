# A path in a binary tree is a sequence of nodes where each pair of adjacent nodes in the sequence has an edge connecting them. A node can only appear in the sequence at most once. Note that the path does not need to pass through the root.
# The path sum of a path is the sum of the node's values in the path.
# Given the root of a binary tree, return the maximum path sum of any non-empty path.

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
from typing import Optional
import sys
class Solution:
    def maxPathSum(self, root: Optional[TreeNode]) -> int:
        self.ans = -sys.maxsize
        def rec(node: Optional[TreeNode]) -> int:
            if not node:
                return 0
            # Find the max path from the leaves to this node
            left = rec(node.left)
            right = rec(node.right)
            leftMid = left + node.val
            rightMid = right + node.val
            leftrightMid = left + right + node.val
            largest = max(node.val, leftMid, rightMid, leftrightMid)
            self.ans = max(self.ans, largest)
            return max(node.val, leftMid, rightMid)
        rec(root)
        return self.ans