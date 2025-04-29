# Given the root of a binary tree, determine if it is a valid binary search tree (BST).

# A valid BST is defined as follows:

# The left subtree of a node contains only nodes with keys less than the node's key.
# The right subtree of a node contains only nodes with keys greater than the node's key.
# Both the left and right subtrees must also be binary search trees.

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
from typing import Optional
import sys
class Solution:
    def isValidBST(self, root: Optional[TreeNode]) -> bool:
        def rec(node: Optional[TreeNode], l: int, r: int):
            if not node:
                return True
            if not l <= node.val <= r:
                return False
            if not rec(node.left, l, node.val - 1):
                return False
            if not rec(node.right, node.val + 1, r):
                return False
            return True
        return rec(root, -sys.maxsize, sys.maxsize)