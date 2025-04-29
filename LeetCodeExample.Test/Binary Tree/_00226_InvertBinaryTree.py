# Given the root of a binary tree, invert the tree, and return its root.

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
from typing import Optional
class Solution:
    def invertTree(self, root: Optional[TreeNode]) -> Optional[TreeNode]:
        if not root:
            return None
        def rec(node: Optional[TreeNode]):
            if not node:
                return
            node.left, node.right = node.right, node.left
            rec(node.left)
            rec(node.right)
        rec(root)
        return root