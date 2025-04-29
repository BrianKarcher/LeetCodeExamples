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
        def rec(node: Optional[TreeNode], val: int) -> bool:
            if not node:
                return False
            node_val = node.val + val
            if node.left == node.right == None:
                return targetSum == node_val
            return rec(node.left, node_val) or rec(node.right, node_val)
        return rec(root, 0)
    


# Old try
class Solution:
    def hasPathSum(self, root: Optional[TreeNode], targetSum: int) -> bool:
        def rec(node: Optional[TreeNode], sum: int) -> bool:
            if not node:
                return False
            sum += node.val
            # Ensure to only check on a leaf node
            if not node.left and not node.right and sum == targetSum:
                return True
            if rec(node.left, sum):
                return True
            return rec(node.right, sum)
        return rec(root, 0)