# Given the root of a binary tree, return the sum of all left leaves.

# A leaf is a node with no children. A left leaf is a leaf that is the left child of another node.

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
from typing import Optional
class Solution:
    def sumOfLeftLeaves(self, root: Optional[TreeNode]) -> int:
        def rec(isLeft: bool, node: Optional[TreeNode]) -> int:
            if node == None:
                return 0
            if isLeft and node.left == None and node.right == None:
                return node.val
            sum = 0
            sum += rec(True, node.left)
            sum += rec(False, node.right)
            return sum
        return rec(False, root)