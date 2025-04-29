# Given two integer arrays inorder and postorder where inorder is the inorder traversal of a binary tree and postorder is the postorder traversal of the same tree, construct and return the binary tree.

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
from typing import List, Optional
class Solution:
    def buildTree(self, inorder: List[int], postorder: List[int]) -> Optional[TreeNode]:
        self.poIndex = len(postorder) - 1
        self.map = {}
        for i in range(len(inorder)):
            self.map[inorder[i]] = i

        def rec(l: int, r: int) -> Optional[TreeNode]:
            if l > r:
                return None
            nodeVal = postorder[self.poIndex]
            node = TreeNode(nodeVal)
            self.poIndex -= 1
            node.right = rec(self.map[nodeVal] + 1, r)
            node.left = rec(l, self.map[nodeVal] - 1)
            return node
        return rec(0, len(inorder) - 1)