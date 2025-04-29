# Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
from typing import Optional
class Solution:
    def isSymmetric(self, root: Optional[TreeNode]) -> bool:
        def rec(left: Optional[TreeNode], right: Optional[TreeNode]) -> int:
            if left and not right:
                return False
            if right and not left:
                return False
            if not left and not right:
                return True
            if left.val != right.val:
                return False
            # Do the symmetric compare
            if not rec(left.left, right.right):
                return False
            if not rec(left.right, right.left):
                return False
            return True
        return rec(root.left, root.right)