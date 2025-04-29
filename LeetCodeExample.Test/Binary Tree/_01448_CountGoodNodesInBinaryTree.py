# Given a binary tree root, a node X in the tree is named good if in the path from root to X there are no nodes with a value greater than X.
# Return the number of good nodes in the binary tree.

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
from typing import Optional
class Solution:
    def goodNodes(self, root: TreeNode) -> int:
        def rec(node: Optional[TreeNode], max_value) -> int:
            if node is None:
                return 0
            ans = 0
            # A good node is one in which the values reached so far are less than this
            # node's value
            if node.val >= max_value:
                ans += 1
            new_max = max(node.val, max_value)
            ans += rec(node.left, new_max)
            ans += rec(node.right, new_max)
            return ans
        return rec(root, float('-inf'))