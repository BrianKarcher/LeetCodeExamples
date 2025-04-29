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
            # There are four ways a path can go through this node
            # Just the node, left to node, right to node, or left to node to right (travels though)
            # We need to test all three to find the max
            left = rec(node.left)
            right = rec(node.right)
            self.ans = max(self.ans, node.val, left + node.val, right + node.val, left + right + node.val)
            # As for returning a value to the calling node, we can only return on of three paths 
            # Just this node, left to node, or right to node. Note that we can't return left to node to right as that isn't a valid path 
            return max(node.val, left + node.val, right + node.val)
        rec(root)
        return self.ans