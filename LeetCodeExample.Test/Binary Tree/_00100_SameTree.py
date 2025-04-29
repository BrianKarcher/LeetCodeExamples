# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
        
from typing import Optional
class Solution:
    def isSameTree(self, p: Optional[TreeNode], q: Optional[TreeNode]) -> bool:
        def recurse(nodeA: Optional[TreeNode], nodeB: Optional[TreeNode]) -> bool:
            if not nodeA and not nodeB:
                return True
            if nodeA and not nodeB:
                return False
            if not nodeA and nodeB:
                return False
            if nodeA.val != nodeB.val:
                return False
            
            if not recurse(nodeA.left, nodeB.left):
                return False
            if not recurse(nodeA.right, nodeB.right):
                return False
            return True
        return recurse(p, q)