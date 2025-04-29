# Given the root of a binary tree and an integer targetSum, return true if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.
# A leaf is a node with no children.
# Definition for a binary tree node.

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
from typing import Optional
class Solution:
    def hasPathSum(self, root: Optional[TreeNode], targetSum: int) -> bool:
        def rec(node: Optional[TreeNode], sum: int) -> bool:
            if not node:
                return False
            # Ensure to only check on a leaf node
            if not node.left and not node.right and sum + node.val == targetSum:
                return True
            if rec(node.left, sum + node.val):
                return True
            return rec(node.right, sum + node.val)
        return rec(root, 0)