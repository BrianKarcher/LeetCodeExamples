# Given the root of a binary search tree, and an integer k, return the kth smallest value (1-indexed) of all the values of the nodes in the tree.

from typing import Optional
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
class Solution:
    def kthSmallest(self, root: Optional[TreeNode], k: int) -> int:
        self.res = math.inf
        def recurse(node: Optional[TreeNode]):
            nonlocal k
            # has to be in order traversal
            if node is None:
                return
            if k < 0:
                return
            #print(f'Investigating {node.val}, current = {current}')
            recurse(node.left)           
            k -= 1
            if k == 0:
                #print(f'setting ans to {ans}')
                self.res = node.val
                return
            recurse(node.right)
        recurse(root)
        return self.res