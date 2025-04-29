# Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
from typing import Optional, List
class Solution:
    def levelOrder(self, root: Optional[TreeNode]) -> List[List[int]]:
        self.ans = []
        def rec(node: Optional[TreeNode], level: int):
            if not node:
                return
            if level > len(self.ans) - 1:
                self.ans.append([])
            self.ans[level].append(node.val)
            rec(node.left, level + 1)
            rec(node.right, level + 1)
        if not root:
            return []
        rec(root, 0)
        return self.ans