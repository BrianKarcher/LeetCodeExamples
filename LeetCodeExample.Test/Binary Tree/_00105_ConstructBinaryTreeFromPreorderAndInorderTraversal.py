# Given two integer arrays preorder and inorder where preorder is the preorder traversal of a binary tree and inorder is the inorder traversal of the same tree, construct and return the binary tree.

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
from typing import List, Optional
class Solution:
    def buildTree(self, preorder: List[int], inorder: List[int]) -> Optional[TreeNode]:
        map = {}
        for i in range(len(inorder)):
            map[inorder[i]] = i
        self.index = 0
        def rec(l, r) -> TreeNode:
            if l > r:
                return None
            val = preorder[self.index]
            # print(f'{val} {r} {self.index}')
            node = TreeNode(val)
            self.index += 1
            node.left = rec(l, map[val] - 1)
            node.right = rec(map[val] + 1, r)
            return node
        return rec(0, len(inorder) - 1)